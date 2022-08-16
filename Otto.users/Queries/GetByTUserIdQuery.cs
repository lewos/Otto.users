using MediatR;
using Otto.users.DTOs;

namespace Otto.users.Queries
{ 
    public class GetByTUserIdQuery : IRequest<User>
    {
        public string Id { get; }
        public GetByTUserIdQuery(string id)
        {
            Id = id;
        }
    }
}
