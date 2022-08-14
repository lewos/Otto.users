using MediatR;
using Otto.users.Commands;
using Otto.users.DTOs;
using Otto.users.Repositories;

namespace Otto.users.Handlers.Command
{
    public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, bool>
    {
        private readonly IUsersRepository _usersRepository;

        public UpdateUserHandler(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }
        public async Task<bool> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var res = await _usersRepository.UpdateUserAsync(request.Id,request);
            //var officesResponse = _mapperMapOfficesDtosToOfficesResponse(officesDtos);
            return res;
        }
    }
}
