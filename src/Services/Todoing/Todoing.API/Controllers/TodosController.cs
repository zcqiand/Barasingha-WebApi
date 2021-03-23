using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using UltraNuke.Barasingha.Todoing.API.Application.Commands;
using UltraNuke.Barasingha.Todoing.API.Application.DTO;
using UltraNuke.Barasingha.Todoing.API.Application.Queries;
using UltraNuke.CommonMormon.Utils.WebApi;


namespace UltraNuke.Barasingha.Todoing.API.Controllers
{
    /// <summary>
    /// 待办事项
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class TodosController : ControllerBase
    {
        private readonly TodoQueries todoQueries;
        private readonly MediatR.IMediator mediator;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="todoQueries"></param>
        /// <param name="mediator"></param>
        public TodosController(TodoQueries todoQueries, MediatR.IMediator mediator)
        {
            this.todoQueries = todoQueries ?? throw new ArgumentNullException(nameof(todoQueries));
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        /// <summary>
        /// 获取待办事项列表
        /// </summary>
        /// <returns>待办事项集合</returns>
        [HttpGet]
        public ActionResult<PaginatedItems<TodoDTO>> Query(int pageIndex, int pageSize)
        {
            return todoQueries.Query(pageIndex, pageSize).Result;
        }

        /// <summary>
        /// 获取待办事项详情
        /// </summary>
        /// <param name="id">待办事项ID</param>
        /// <returns>待办事项</returns>
        [HttpGet("{id}")]
        public ActionResult<TodoDTO> Get(Guid id)
        {
            var todo = todoQueries.Get(id).Result;
            if (todo == null)
            {
                return NotFound();
            }
            return todo;
        }

        /// <summary>
        /// 创建待办事项
        /// </summary>
        /// <param name="param">参数</param>
        /// <returns>待办事项对象</returns>
        [HttpPost]
        public async Task<ActionResult<TodoDTO>> Create(CreateTodoCommand param)
        {
            var ret = await mediator.Send(param);
            return CreatedAtAction(nameof(Get), new { id = ret.Id }, ret);
        }

        /// <summary>
        /// 更新待办事项
        /// </summary>
        /// <param name="id">待办事项ID</param>
        /// <param name="param">参数</param>
        /// <returns>待办事项对象</returns>
        [HttpPut("{id}")]
        public async Task<ActionResult<TodoDTO>> Update(Guid id, UpdateTodoCommand param)
        {
            param.Id = id;
            var ret = await mediator.Send(param);
            return CreatedAtAction(nameof(Get), new { id = ret.Id }, ret);
        }

        /// <summary>
        /// 删除待办事项
        /// </summary>
        /// <param name="id">待办事项ID</param>
        /// <returns>待办事项对象</returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var param = new DeleteTodoCommand { Id = id };
            var ret = await mediator.Send(param);
            if (!ret)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
