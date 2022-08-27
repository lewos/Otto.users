using MediatR;
using Otto.users.Commands;
using Otto.users.DTOs;
using Otto.users.Repositories;

namespace Otto.users.Handlers.Command
{
    public class LoginUserHandler : IRequestHandler<LoginUserCommand, User>
    {
        private readonly IUsersRepository _usersRepository;

        public LoginUserHandler(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }
        public async Task<User> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var userDto = await _usersRepository.GetUserByMailPassAsync(request.Mail, request.Pass);
            //var officesResponse = _mapperMapOfficesDtosToOfficesResponse(officesDtos);
            if (string.IsNullOrEmpty(userDto.Pass))
                userDto.Pass = "";
            return userDto;
        }
    }
}
