using MediatR;

namespace Otto.users.Commands
{
    public class DeleteUserCommand : IRequest<bool>
    {
        public string Id { get; }
        public DeleteUserCommand(string id)
        {
            Id = id;
        }
    }
}
