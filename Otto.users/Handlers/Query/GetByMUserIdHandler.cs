using MediatR;
using Otto.users.DTOs;
using Otto.users.Queries;
using Otto.users.Repositories;

namespace Otto.users.Handlers.Query
{

    public class GetByMUserIdHandler : IRequestHandler<GetByMUserIdQuery, User>
    {
        private readonly IUsersRepository _usersRepository;
        public GetByMUserIdHandler(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }
        public async Task<User> Handle(GetByMUserIdQuery request, CancellationToken cancellationToken)
        {
            var userDto = await _usersRepository.GetByMUserIdAsync(request.Id);
            //var officesResponse = _mapperMapOfficesDtosToOfficesResponse(officesDtos);
            return userDto == null ? null : userDto;
        }
    }
}
