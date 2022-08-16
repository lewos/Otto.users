using MediatR;
using Otto.users.DTOs;
using Otto.users.Queries;
using Otto.users.Repositories;

namespace Otto.users.Handlers.Query
{
    public class GetByTUserIdHandler : IRequestHandler<GetByTUserIdQuery, User>
    {
        private readonly IUsersRepository _usersRepository;
        public GetByTUserIdHandler(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }
        public async Task<User> Handle(GetByTUserIdQuery request, CancellationToken cancellationToken)
        {
            var userDto = await _usersRepository.GetByTUserIdAsync(request.Id);
            //var officesResponse = _mapperMapOfficesDtosToOfficesResponse(officesDtos);
            return userDto == null ? null : userDto;
        }
    }
}
