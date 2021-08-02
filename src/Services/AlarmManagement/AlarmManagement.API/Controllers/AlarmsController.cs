using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using UltraNuke.Barasingha.AlarmManagement.API.Application.Commands;
using UltraNuke.Barasingha.AlarmManagement.API.Application.DTO;
using UltraNuke.Barasingha.AlarmManagement.API.Application.Queries;
using UltraNuke.CommonMormon.Utils.WebApi;

namespace UltraNuke.Barasingha.AlarmManagement.API.Controllers
{
    /// <summary>
    /// 报警
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AlarmsController : ControllerBase
    {
        private readonly AlarmQueries alarmQueries;
        private readonly MediatR.IMediator mediator;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="alarmQueries"></param>
        /// <param name="mediator"></param>
        public AlarmsController(AlarmQueries alarmQueries, MediatR.IMediator mediator)
        {
            this.alarmQueries = alarmQueries ?? throw new ArgumentNullException(nameof(alarmQueries));
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        /// <summary>
        /// 获取报警列表
        /// </summary>
        /// <returns>报警集合</returns>
        [HttpGet]
        public ActionResult<PaginatedItems<AlarmForQueryDTO>> Query(Guid? levelId, Guid? categoryId, string name, int pageIndex, int pageSize)
        {
            return alarmQueries.Query(levelId, categoryId, name, pageIndex, pageSize).Result;
        }

        /// <summary>
        /// 获取报警详情
        /// </summary>
        /// <param name="id">报警ID</param>
        /// <returns>报警</returns>
        [HttpGet("{id}")]
        public ActionResult<AlarmForGetDTO> Get(Guid id)
        {
            var ret = alarmQueries.Get(id).Result;
            if (ret == null)
            {
                return NotFound();
            }
            return ret;
        }

        /// <summary>
        /// 新报警
        /// </summary>
        /// <param name="param">参数</param>
        /// <returns>报警ID</returns>
        [HttpPost]
        public async Task<ActionResult<Guid>> Create(CreateAlarmCommand param)
        {
            var ret = await mediator.Send(param);
            return ret;
        }

        /// <summary>
        /// 认领报警
        /// </summary>
        /// <param name="id">报警ID</param>
        /// <param name="param">参数</param>
        [HttpPut("{id}/claim")]
        public async Task<ActionResult> Claim(Guid id, ClaimAlarmCommand param)
        {
            param.Id = id;
            var ret = await mediator.Send(param);
            if (!ret)
            {
                return BadRequest();
            }
            return Ok();
        }

        /// <summary>
        /// 关闭报警
        /// </summary>
        /// <param name="id">报警ID</param>
        /// <param name="param">参数</param>
        [HttpPut("{id}/close")]
        public async Task<ActionResult> Close(Guid id, CloseAlarmCommand param)
        {
            param.Id = id;
            var ret = await mediator.Send(param);
            if (!ret)
            {
                return BadRequest();
            }
            return Ok();
        }

        /// <summary>
        /// 删除报警
        /// </summary>
        /// <param name="id">报警ID</param>
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var param = new DeleteAlarmCommand { Id = id };
            var ret = await mediator.Send(param);
            if (!ret)
            {
                return BadRequest();
            }
            return Ok();
        }
    }
}
