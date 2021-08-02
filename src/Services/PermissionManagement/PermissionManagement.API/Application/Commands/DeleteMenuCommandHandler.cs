namespace UltraNuke.Barasingha.PermissionManagement.API.Application.Commands
{
    using MediatR;
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using UltraNuke.Barasingha.PermissionManagement.Domain.AggregatesModel;
    using UltraNuke.CommonMormon.DDD;

    public class DeleteMenuCommandHandler
        : IRequestHandler<DeleteMenuCommand, bool>
    {
        private readonly IRepository repository;

        public DeleteMenuCommandHandler(IRepository repository)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<bool> Handle(DeleteMenuCommand param, CancellationToken cancellationToken)
        {
            var menu = await repository.GetAsync<Menu>(param.Id);
            menu.Delete();
            repository.Entry(menu);
            await repository.SaveAsync();
            return true;
        }
    }
}
