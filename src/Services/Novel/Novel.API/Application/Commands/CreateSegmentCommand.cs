﻿using MediatR;
using UltraNuke.Barasingha.Novel.API.Application.Commands;
using UltraNuke.Barasingha.Novel.API.Application.DTO;

namespace UltraNuke.Barasingha.Novel.API.Application.Commands
{
    public class CreateSegmentCommand : SegmentCommandBase, IRequest<SegmentDTO>
    {
    }

}
