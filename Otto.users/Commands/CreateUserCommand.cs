using MediatR;
using Otto.users.DTOs;

namespace Otto.users.Commands
{
    public class CreateUserCommand : User, IRequest<User>
    {
    }
}
