namespace UltraNuke.Barasingha.PermissionManagement.API.Application.Commands
{
    using MediatR;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using UltraNuke.Barasingha.PermissionManagement.Domain.AggregatesModel;
    using UltraNuke.CommonMormon.DDD;

    public class CreateMenuCommandHandler
        : IRequestHandler<CreateMenuCommand, Guid>
    {
        private readonly IRepository repository;

        public CreateMenuCommandHandler(IRepository repository)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<Guid> Handle(CreateMenuCommand param, CancellationToken cancellationToken)
        {
            IList<Menu> menus = await repository.Query<Menu>().ToListAsync();
            menus = TreeUtil.Traverse<Menu>(menus, menus);
            var parentNode = menus.Where(w => w.Id == param.ParentNodeId).Single();

            var menu = Menu.Create(parentNode, param.No, param.Icon, param.Name, param.NavigateUrl, param.ComponentPath, param.Description);
            repository.Entry(menu);
            await repository.SaveAsync();

            return menu.Id;
        }
    }
}
