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
    /// 作品分卷
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class SegmentsController : ControllerBase
    {
        private readonly SegmentQueries segmentQueries;
        private readonly MediatR.IMediator mediator;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="segmentQueries"></param>
        /// <param name="mediator"></param>
        public SegmentsController(SegmentQueries segmentQueries, MediatR.IMediator mediator)
        {
            this.segmentQueries = segmentQueries ?? throw new ArgumentNullException(nameof(segmentQueries));
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        /// <summary>
        /// 获取作品分卷列表
        /// </summary>
        /// <returns>作品分卷集合</returns>
        [HttpGet]
        public ActionResult<PaginatedItems<SegmentDTO>> Query(int pageIndex, int pageSize)
        {
            return segmentQueries.Query(pageIndex, pageSize).Result;
        }

        /// <summary>
        /// 获取作品分卷详情
        /// </summary>
        /// <param name="id">作品分卷ID</param>
        /// <returns>作品分卷</returns>
        [HttpGet("{id}")]
        public ActionResult<SegmentDTO> Get(Guid id)
        {
            var segment = segmentQueries.Get(id).Result;
            if (segment == null)
            {
                return NotFound();
            }
            return segment;
        }

        /// <summary>
        /// 创建作品分卷
        /// </summary>
        /// <param name="param">参数</param>
        /// <returns>作品分卷对象</returns>
        [HttpPost]
        public async Task<ActionResult<SegmentDTO>> Create(CreateSegmentCommand param)
        {
            var ret = await mediator.Send(param);
            return CreatedAtAction(nameof(Get), new { id = ret.Id }, ret);
        }

        /// <summary>
        /// 更新作品分卷
        /// </summary>
        /// <param name="id">作品分卷ID</param>
        /// <param name="param">参数</param>
        /// <returns>作品分卷对象</returns>
        [HttpPut("{id}")]
        public async Task<ActionResult<SegmentDTO>> Update(Guid id, UpdateSegmentCommand param)
        {
            param.Id = id;
            var ret = await mediator.Send(param);
            return CreatedAtAction(nameof(Get), new { id = ret.Id }, ret);
        }

        /// <summary>
        /// 删除作品分卷
        /// </summary>
        /// <param name="id">作品分卷ID</param>
        /// <returns>作品分卷对象</returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var param = new DeleteSegmentCommand { Id = id };
            var ret = await mediator.Send(param);
            if (!ret)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
