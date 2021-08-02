namespace UltraNuke.Barasingha.PermissionManagement.API.Application.Commands
{
    using AutoMapper;
    using MediatR;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using UltraNuke.Barasingha.PermissionManagement.API.Application.DTO;
    using UltraNuke.Barasingha.PermissionManagement.API.Application.Commands;
    using UltraNuke.Barasingha.PermissionManagement.Domain.AggregatesModel;
    using UltraNuke.CommonMormon.DDD;

    public class CreateMenuCommandHandler
        : IRequestHandler<CreateMenuCommand, MenuDTO>
    {
        private readonly IRepository repository;
        private readonly IMapper mapper;

        public CreateMenuCommandHandler(IRepository repository, IMapper mapper)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<MenuDTO> Handle(CreateMenuCommand param, CancellationToken cancellationToken)
        {
            IList<Menu> menus = await repository.Query<Menu>().ToListAsync();
            menus = TreeUtil.Traverse<Menu>(menus, menus);
            var parentNode = menus.Where(w => w.Id == param.ParentNodeId).Single();

            var menu = Menu.Create(parentNode, param.No, param.Icon, param.Name, param.NavigateUrl, param.ComponentPath, param.Description);
            repository.Entry(menu);
            await repository.SaveAsync();

            var menuForDTO = mapper.Map<MenuDTO>(menu);
            return menuForDTO;
        }
    }
}
