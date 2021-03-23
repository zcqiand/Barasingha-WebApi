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
    /// 作品章节
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ChaptersController : ControllerBase
    {
        private readonly ChapterQueries chapterQueries;
        private readonly MediatR.IMediator mediator;

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="chapterQueries"></param>
        /// <param name="mediator"></param>
        public ChaptersController(ChapterQueries chapterQueries, MediatR.IMediator mediator)
        {
            this.chapterQueries = chapterQueries ?? throw new ArgumentNullException(nameof(chapterQueries));
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        /// <summary>
        /// 获取作品章节列表
        /// </summary>
        /// <returns>作品章节集合</returns>
        [HttpGet]
        public ActionResult<PaginatedItems<ChapterDTO>> Query(DateTime startUpdateTime, DateTime endUpdateTime, string name, int pageIndex, int pageSize)
        {
            return chapterQueries.Query(startUpdateTime, endUpdateTime, name, pageIndex, pageSize).Result;
        }

        /// <summary>
        /// 获取作品章节详情
        /// </summary>
        /// <param name="id">作品章节ID</param>
        /// <returns>作品章节</returns>
        [HttpGet("{id}")]
        public ActionResult<ChapterDTO> Get(Guid id)
        {
            var chapter = chapterQueries.Get(id).Result;
            if (chapter == null)
            {
                return NotFound();
            }
            return chapter;
        }

        /// <summary>
        /// 创建作品章节
        /// </summary>
        /// <param name="param">参数</param>
        /// <returns>作品章节对象</returns>
        [HttpPost]
        public async Task<ActionResult<ChapterDTO>> Create(CreateChapterCommand param)
        {
            var ret = await mediator.Send(param);
            return CreatedAtAction(nameof(Get), new { id = ret.Id }, ret);
        }

        /// <summary>
        /// 更新作品章节
        /// </summary>
        /// <param name="id">作品章节ID</param>
        /// <param name="param">参数</param>
        /// <returns>作品章节对象</returns>
        [HttpPut("{id}")]
        public async Task<ActionResult<ChapterDTO>> Update(Guid id, UpdateChapterCommand param)
        {
            param.Id = id;
            var ret = await mediator.Send(param);
            return CreatedAtAction(nameof(Get), new { id = ret.Id }, ret);
        }

        /// <summary>
        /// 删除作品章节
        /// </summary>
        /// <param name="id">作品章节ID</param>
        /// <returns>作品章节对象</returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var param = new DeleteChapterCommand { Id = id };
            var ret = await mediator.Send(param);
            if (!ret)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
