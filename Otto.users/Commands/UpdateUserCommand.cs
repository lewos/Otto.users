using MediatR;
using Otto.users.DTOs;

namespace Otto.users.Commands
{
    public class UpdateUserCommand : User, IRequest<bool>
    {
    }
}
