using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UltraNuke.Barasingha.PermissionManagement.API.Application.Commands;
using UltraNuke.Barasingha.PermissionManagement.API.Application.DTO;
using UltraNuke.Barasingha.PermissionManagement.API.Application.Queries;
using UltraNuke.CommonMormon.Utils.WebApi;


namespace UltraNuke.Barasingha.PermissionManagement.API.Controllers
{
    /// <summary>
    /// 用户
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserQueries userQueries;
        private readonly MediatR.IMediator mediator;

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="userQueries"></param>
        /// <param name="mediator"></param>
        public UsersController(UserQueries userQueries, MediatR.IMediator mediator)
        {
            this.userQueries = userQueries ?? throw new ArgumentNullException(nameof(userQueries));
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        /// <summary>
        /// 获取用户列表
        /// </summary>
        /// <returns>用户集合</returns>
        [HttpGet]
        public ActionResult<PaginatedItems<UserForQueryDTO>> Query(string nickName, int pageIndex, int pageSize)
        {
            return userQueries.Query(nickName, pageIndex, pageSize).Result;
        }

        /// <summary>
        /// 获取所有用户列表
        /// </summary>
        /// <returns>用户集合</returns>
        [Route("all")]
        [HttpGet]
        public ActionResult<List<UserForQueryDTO>> QueryAll()
        {
            return userQueries.QueryAll().Result;
        }

        /// <summary>
        /// 获取用户详情
        /// </summary>
        /// <param name="id">用户ID</param>
        /// <returns>用户</returns>
        [HttpGet("{id}")]
        public ActionResult<UserForGetDTO> Get(Guid id)
        {
            var user = userQueries.Get(id).Result;
            if (user == null)
            {
                return NotFound();
            }
            return user;
        }

        /// <summary>
        /// 注册用户
        /// </summary>
        /// <param name="param">参数</param>
        /// <returns>用户ID</returns>
        [HttpPost("signup")]
        public async Task<ActionResult<Guid>> Signup(SignupCommand param)
        {
            var ret = await mediator.Send(param);
            return ret;
        }

        /// <summary>
        /// 更新用户
        /// </summary>
        /// <param name="id">用户ID</param>
        /// <param name="param">参数</param>
        /// <returns>用户对象</returns>
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(Guid id, UpdateUserCommand param)
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
        /// 删除用户
        /// </summary>
        /// <param name="id">用户ID</param>
        /// <returns>用户对象</returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var param = new DeleteUserCommand { Id = id };
            var ret = await mediator.Send(param);
            if (!ret)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}
