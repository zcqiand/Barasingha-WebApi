using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UltraNuke.Barasingha.PermissionManagement.API.Application.Commands;
using UltraNuke.Barasingha.PermissionManagement.API.Application.DTO;
using UltraNuke.Barasingha.PermissionManagement.API.Application.Queries;
using UltraNuke.CommonMormon.Utils.WebApi;


namespace UltraNuke.Barasingha.Roleing.API.Controllers
{
    /// <summary>
    /// 角色
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly RoleQueries roleQueries;
        private readonly MediatR.IMediator mediator;

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="roleQueries"></param>
        /// <param name="mediator"></param>
        public RolesController(RoleQueries roleQueries, MediatR.IMediator mediator)
        {
            this.roleQueries = roleQueries ?? throw new ArgumentNullException(nameof(roleQueries));
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        /// <summary>
        /// 获取角色列表
        /// </summary>
        /// <returns>角色集合</returns>
        [HttpGet]
        public ActionResult<PaginatedItems<RoleForQueryDTO>> Query(string name, int pageIndex, int pageSize)
        {
            return roleQueries.Query(name, pageIndex, pageSize).Result;
        }

        /// <summary>
        /// 获取所有角色列表
        /// </summary>
        /// <returns>角色集合</returns>
        [Route("all")]
        [HttpGet]
        public ActionResult<List<RoleForQueryDTO>> QueryAll()
        {
            return roleQueries.QueryAll().Result;
        }

        /// <summary>
        /// 获取角色详情
        /// </summary>
        /// <param name="id">角色ID</param>
        /// <returns>角色</returns>
        [HttpGet("{id}")]
        public ActionResult<RoleForGetDTO> Get(Guid id)
        {
            var role = roleQueries.Get(id).Result;
            if (role == null)
            {
                return NotFound();
            }
            return role;
        }

        /// <summary>
        /// 创建角色
        /// </summary>
        /// <param name="param">参数</param>
        /// <returns>角色对象</returns>
        [HttpPost]
        public async Task<ActionResult<Guid>> Create(CreateRoleCommand param)
        {
            var ret = await mediator.Send(param);
            return ret;
        }

        /// <summary>
        /// 更新角色
        /// </summary>
        /// <param name="id">角色ID</param>
        /// <param name="param">参数</param>
        /// <returns>角色对象</returns>
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(Guid id, UpdateRoleCommand param)
        {
            param.Id = id;
            var ret = await mediator.Send(param);
            if (!ret)
            {
                return BadRequest();
            }
            return Ok();
        }

        ///// <summary>
        ///// 设置权限
        ///// </summary>
        ///// <param name="id">角色ID</param>
        ///// <param name="param">参数</param>
        ///// <returns>角色对象</returns>
        //[HttpPut("{id}/SetPermission")]
        //public async Task<ActionResult<RoleDTO>> SetPermission(Guid id, SetPermissionCommand param)
        //{
        //    param.Id = id;
        //    var ret = await mediator.Send(param);
        //    return CreatedAtAction(nameof(Get), new { id = ret.Id }, ret);
        //}

        /// <summary>
        /// 删除角色
        /// </summary>
        /// <param name="id">角色ID</param>
        /// <returns>角色对象</returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var param = new DeleteRoleCommand { Id = id };
            var ret = await mediator.Send(param);
            if (!ret)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}
