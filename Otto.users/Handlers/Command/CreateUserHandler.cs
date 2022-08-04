using MediatR;
using Otto.users.Commands;
using Otto.users.DTOs;
using Otto.users.Repositories;

namespace Otto.users.Handlers.Command
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, User>
    {
        private readonly IUsersRepository _usersRepository;

        public CreateUserHandler(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }
        public async Task<User> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var userDto = await _usersRepository.CreateUserAsync(request);
            //var officesResponse = _mapperMapOfficesDtosToOfficesResponse(officesDtos);
            return userDto;
        }
    }
}
