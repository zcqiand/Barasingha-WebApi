﻿using MediatR;
using UltraNuke.Barasingha.PermissionManagement.API.Application.DTO;

namespace UltraNuke.Barasingha.PermissionManagement.API.Application.Commands
{
    public class CreateUserCommand : UserCommandBase, IRequest<UserDTO>
    {
    }

}
