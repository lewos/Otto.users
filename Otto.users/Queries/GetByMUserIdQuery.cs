using MediatR;
using Otto.users.DTOs;

namespace Otto.users.Queries
{
    public class GetByMUserIdQuery : IRequest<User>
    {
        public string Id { get; }
        public GetByMUserIdQuery(string id)
        {
            Id = id;
        }
    }
}
