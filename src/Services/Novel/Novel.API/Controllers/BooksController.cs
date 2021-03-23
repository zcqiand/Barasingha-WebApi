using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using UltraNuke.Barasingha.Novel.API.Application.Commands;
using UltraNuke.Barasingha.Novel.API.Application.DTO;
using UltraNuke.Barasingha.Novel.API.Application.Queries;
using UltraNuke.CommonMormon.Utils.WebApi;


namespace UltraNuke.Barasingha.Novel.API.Controllers
{
    /// <summary>
    /// 作品
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BookQueries bookQueries;
        private readonly MediatR.IMediator mediator;

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="bookQueries"></param>
        /// <param name="mediator"></param>
        public BooksController(BookQueries bookQueries, MediatR.IMediator mediator)
        {
            this.bookQueries = bookQueries ?? throw new ArgumentNullException(nameof(bookQueries));
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        /// <summary>
        /// 获取作品列表
        /// </summary>
        /// <returns>作品集合</returns>
        [HttpGet]
        public ActionResult<PaginatedItems<BookDTO>> Query(int pageIndex, int pageSize)
        {
            return bookQueries.Query(pageIndex, pageSize).Result;
        }

        /// <summary>
        /// 获取作品详情
        /// </summary>
        /// <param name="id">作品ID</param>
        /// <returns>作品</returns>
        [HttpGet("{id}")]
        public ActionResult<BookDTO> Get(Guid id)
        {
            var book = bookQueries.Get(id).Result;
            if (book == null)
            {
                return NotFound();
            }
            return book;
        }

        /// <summary>
        /// 创建作品
        /// </summary>
        /// <param name="param">参数</param>
        /// <returns>作品对象</returns>
        [HttpPost]
        public async Task<ActionResult<BookDTO>> Create(CreateBookCommand param)
        {
            var ret = await mediator.Send(param);
            return CreatedAtAction(nameof(Get), new { id = ret.Id }, ret);
        }

        /// <summary>
        /// 更新作品
        /// </summary>
        /// <param name="id">作品ID</param>
        /// <param name="param">参数</param>
        /// <returns>作品对象</returns>
        [HttpPut("{id}")]
        public async Task<ActionResult<BookDTO>> Update(Guid id, UpdateBookCommand param)
        {
            param.Id = id;
            var ret = await mediator.Send(param);
            return CreatedAtAction(nameof(Get), new { id = ret.Id }, ret);
        }

        /// <summary>
        /// 删除作品
        /// </summary>
        /// <param name="id">作品ID</param>
        /// <returns>作品对象</returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var param = new DeleteBookCommand { Id = id };
            var ret = await mediator.Send(param);
            if (!ret)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
