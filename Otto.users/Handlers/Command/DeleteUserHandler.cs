using MediatR;
using Otto.users.Commands;
using Otto.users.Repositories;

namespace Otto.users.Handlers.Command
{
    public class DeleteUserHandler : IRequestHandler<DeleteUserCommand, bool>
    {
        private readonly IUsersRepository _usersRepository;

        public DeleteUserHandler(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }
        public async Task<bool> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var userDto = await _usersRepository.DeleteUserAsync(request.Id);
            //var officesResponse = _mapperMapOfficesDtosToOfficesResponse(officesDtos);
            return userDto;
        }
    }
}
