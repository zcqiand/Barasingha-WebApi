using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UltraNuke.Barasingha.PermissionManagement.API.Application.Commands;
using UltraNuke.Barasingha.PermissionManagement.API.Application.DTO;
using UltraNuke.Barasingha.PermissionManagement.API.Application.Queries;


namespace UltraNuke.Barasingha.PermissionManagement.API.Controllers
{
    /// <summary>
    /// 菜单
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class MenusController : ControllerBase
    {
        private readonly MenuQueries menuQueries;
        private readonly MediatR.IMediator mediator;

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="menuQueries"></param>
        /// <param name="mediator"></param>
        public MenusController(MenuQueries menuQueries, MediatR.IMediator mediator)
        {
            this.menuQueries = menuQueries ?? throw new ArgumentNullException(nameof(menuQueries));
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        /// <summary>
        /// 获取树形表格菜单列表
        /// </summary>
        /// <returns>菜单集合</returns>
        [HttpGet]
        [Route("treeTable")]
        public ActionResult<List<MenuForGetTreeTableDTO>> GetTreeTable()
        {
            return menuQueries.GetTreeTable().Result;
        }

        /// <summary>
        /// 获取树形下拉框菜单列表
        /// </summary>
        /// <returns>菜单集合</returns>
        [HttpGet]
        [Route("treeSelect")]
        public ActionResult<List<MenuForGetTreeSelectDTO>> GetTreeSelect()
        {
            return menuQueries.GetTreeSelect().Result;
        }

        /// <summary>
        /// 获取菜单详情
        /// </summary>
        /// <param name="id">菜单ID</param>
        /// <returns>菜单</returns>
        [HttpGet("{id}")]
        public ActionResult<MenuForGetDTO> Get(Guid id)
        {
            var menu = menuQueries.Get(id).Result;
            if (menu == null)
            {
                return NotFound();
            }
            return menu;
        }

        /// <summary>
        /// 创建菜单
        /// </summary>
        /// <param name="param">参数</param>
        /// <returns>菜单对象</returns>
        [HttpPost]
        public async Task<ActionResult<Guid>> Create(CreateMenuCommand param)
        {
            var ret = await mediator.Send(param);
            return ret;
        }

        /// <summary>
        /// 更新菜单
        /// </summary>
        /// <param name="id">菜单ID</param>
        /// <param name="param">参数</param>
        /// <returns>菜单对象</returns>
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(Guid id, UpdateMenuCommand param)
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
        /// 删除菜单
        /// </summary>
        /// <param name="id">菜单ID</param>
        /// <returns>菜单对象</returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var param = new DeleteMenuCommand { Id = id };
            var ret = await mediator.Send(param);
            if (!ret)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}
