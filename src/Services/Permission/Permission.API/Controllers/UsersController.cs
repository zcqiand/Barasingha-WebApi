using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UltraNuke.Barasingha.Permission.API.Application.Commands;
using UltraNuke.Barasingha.Permission.API.Application.DTO;
using UltraNuke.Barasingha.Permission.API.Application.Queries;
using UltraNuke.CommonMormon.Utils.WebApi;


namespace UltraNuke.Barasingha.Permission.API.Controllers
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
        public ActionResult<PaginatedItems<UserDTO>> Query(string nickName, int pageIndex, int pageSize)
        {
            return userQueries.Query(nickName, pageIndex, pageSize).Result;
        }

        /// <summary>
        /// 获取所有用户列表
        /// </summary>
        /// <returns>用户集合</returns>
        [Route("all")]
        [HttpGet]
        public ActionResult<List<UserDTO>> QueryAll()
        {
            return userQueries.QueryAll().Result;
        }

        /// <summary>
        /// 获取用户详情
        /// </summary>
        /// <param name="id">用户ID</param>
        /// <returns>用户</returns>
        [HttpGet("{id}")]
        public ActionResult<UserDTO> Get(Guid id)
        {
            var user = userQueries.Get(id).Result;
            if (user == null)
            {
                return NotFound();
            }
            return user;
        }

        /// <summary>
        /// 用户登录
        /// </summary>
        [Route("login")]
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<TokenDTO>> Login(string username, string password)
        {
            var param = new DeleteUserCommand { UserName = username, Password = password };
            var ret = await mediator.Send(param);
            return Ok(ret);
        }

        /// <summary>
        /// 创建用户
        /// </summary>
        /// <param name="param">参数</param>
        /// <returns>用户对象</returns>
        [HttpPost]
        public async Task<ActionResult<UserDTO>> Create(CreateUserCommand param)
        {
            var ret = await mediator.Send(param);
            return CreatedAtAction(nameof(Get), new { id = ret.Id }, ret);
        }

        /// <summary>
        /// 更新用户
        /// </summary>
        /// <param name="id">用户ID</param>
        /// <param name="param">参数</param>
        /// <returns>用户对象</returns>
        [HttpPut("{id}")]
        public async Task<ActionResult<UserDTO>> Update(Guid id, UpdateUserCommand param)
        {
            param.Id = id;
            var ret = await mediator.Send(param);
            return CreatedAtAction(nameof(Get), new { id = ret.Id }, ret);
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
            return NoContent();
        }
    }
}
