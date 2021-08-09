using MediatR;
using System;

namespace UltraNuke.Barasingha.Novel.API.Application.Commands
{
    public class DeleteChapterCommand : IRequest<bool>
    {

        /// <summary>
        /// 主键
        /// </summary>
        public Guid Id { get; set; }
    }

}
