using MediatR;
using Otto.users.DTOs;

namespace Otto.users.Queries
{
    public class GetUserByIdQuery : IRequest<User>
    {
        public string Id { get; }
        public GetUserByIdQuery(string id)
        {
            Id = id;
        }
    }
}
