using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UltraNuke.Barasingha.Novel.API.Application.Commands;
using UltraNuke.Barasingha.Novel.API.Application.DTO;
using UltraNuke.Barasingha.Novel.API.Application.Queries;
using UltraNuke.CommonMormon.Utils.WebApi;


namespace UltraNuke.Barasingha.Novel.API.Controllers
{
    /// <summary>
    /// 作品大类
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class MainCategoriesController : ControllerBase
    {
        private readonly MainCategoryQueries mainCategoryQueries;
        private readonly MediatR.IMediator mediator;

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="mainCategoryQueries"></param>
        /// <param name="mediator"></param>
        public MainCategoriesController(MainCategoryQueries mainCategoryQueries, MediatR.IMediator mediator)
        {
            this.mainCategoryQueries = mainCategoryQueries ?? throw new ArgumentNullException(nameof(mainCategoryQueries));
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        /// <summary>
        /// 获取作品大类列表
        /// </summary>
        /// <returns>作品大类集合</returns>
        [HttpGet]
        public ActionResult<PaginatedItems<MainCategoryDTO>> Query(string name, int pageIndex, int pageSize)
        {
            return mainCategoryQueries.Query(name, pageIndex, pageSize).Result;
        }

        /// <summary>
        /// 获取树形作品大类列表
        /// </summary>
        /// <returns>作品小类集合</returns>
        [Route("select")]
        [HttpGet]
        public ActionResult<List<MainCategoryForGetSelectDTO>> QuerySelect()
        {
            return mainCategoryQueries.QuerySelect().Result;
        }

        /// <summary>
        /// 获取作品大类详情
        /// </summary>
        /// <param name="id">作品大类ID</param>
        /// <returns>作品大类</returns>
        [HttpGet("{id}")]
        public ActionResult<MainCategoryDTO> Get(Guid id)
        {
            var mainCategory = mainCategoryQueries.Get(id).Result;
            if (mainCategory == null)
            {
                return NotFound();
            }
            return mainCategory;
        }

        /// <summary>
        /// 创建作品大类
        /// </summary>
        /// <param name="param">参数</param>
        /// <returns>作品大类对象</returns>
        [HttpPost]
        public async Task<ActionResult<Guid>> Create(CreateMainCategoryCommand param)
        {
            var ret = await mediator.Send(param);
            return ret;
        }

        /// <summary>
        /// 更新作品大类
        /// </summary>
        /// <param name="id">作品大类ID</param>
        /// <param name="param">参数</param>
        /// <returns>作品大类对象</returns>
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(Guid id, UpdateMainCategoryCommand param)
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
        /// 删除作品大类
        /// </summary>
        /// <param name="id">作品大类ID</param>
        /// <returns>作品大类对象</returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var param = new DeleteMainCategoryCommand { Id = id };
            var ret = await mediator.Send(param);
            if (!ret)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}
