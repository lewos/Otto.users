using MediatR;
using Otto.users.DTOs;

namespace Otto.users.Queries
{
    public class GetAllUsersQuery : IRequest<List<User>>
    {
    }
}
