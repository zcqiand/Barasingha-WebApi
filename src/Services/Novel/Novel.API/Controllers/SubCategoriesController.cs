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
    /// 作品小类
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class SubCategoriesController : ControllerBase
    {
        private readonly SubCategoryQueries subCategoryQueries;
        private readonly MediatR.IMediator mediator;

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="subCategoryQueries"></param>
        /// <param name="mediator"></param>
        public SubCategoriesController(SubCategoryQueries subCategoryQueries, MediatR.IMediator mediator)
        {
            this.subCategoryQueries = subCategoryQueries ?? throw new ArgumentNullException(nameof(subCategoryQueries));
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        /// <summary>
        /// 获取作品小类列表
        /// </summary>
        /// <returns>作品小类集合</returns>
        [HttpGet]
        public ActionResult<PaginatedItems<SubCategoryDTO>> Query(int pageIndex, int pageSize)
        {
            return subCategoryQueries.Query(pageIndex, pageSize).Result;
        }

        /// <summary>
        /// 获取所有作品小类列表
        /// </summary>
        /// <returns>作品小类集合</returns>
        [Route("all")]
        [HttpGet]
        public ActionResult<List<SubCategoryDTO>> QueryAll()
        {
            return subCategoryQueries.QueryAll().Result;
        }

        /// <summary>
        /// 获取作品小类详情
        /// </summary>
        /// <param name="id">作品小类ID</param>
        /// <returns>作品小类</returns>
        [HttpGet("{id}")]
        public ActionResult<SubCategoryDTO> Get(Guid id)
        {
            var subCategory = subCategoryQueries.Get(id).Result;
            if (subCategory == null)
            {
                return NotFound();
            }
            return subCategory;
        }

        /// <summary>
        /// 创建作品小类
        /// </summary>
        /// <param name="param">参数</param>
        /// <returns>作品小类对象</returns>
        [HttpPost]
        public async Task<ActionResult<SubCategoryDTO>> Create(CreateSubCategoryCommand param)
        {
            var ret = await mediator.Send(param);
            return CreatedAtAction(nameof(Get), new { id = ret.Id }, ret);
        }

        /// <summary>
        /// 更新作品小类
        /// </summary>
        /// <param name="id">作品小类ID</param>
        /// <param name="param">参数</param>
        /// <returns>作品小类对象</returns>
        [HttpPut("{id}")]
        public async Task<ActionResult<SubCategoryDTO>> Update(Guid id, UpdateSubCategoryCommand param)
        {
            param.Id = id;
            var ret = await mediator.Send(param);
            return CreatedAtAction(nameof(Get), new { id = ret.Id }, ret);
        }

        /// <summary>
        /// 删除作品小类
        /// </summary>
        /// <param name="id">作品小类ID</param>
        /// <returns>作品小类对象</returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var param = new DeleteSubCategoryCommand { Id = id };
            var ret = await mediator.Send(param);
            if (!ret)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
