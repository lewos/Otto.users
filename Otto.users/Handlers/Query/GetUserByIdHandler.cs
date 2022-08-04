using MediatR;
using Otto.users.DTOs;
using Otto.users.Queries;
using Otto.users.Repositories;

namespace Otto.users.Handlers.Query
{
    public class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, User>
    {
        private readonly IUsersRepository _usersRepository;
        public GetUserByIdHandler(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }
        public async Task<User> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var userDto = await _usersRepository.GetUserByIdAsync(request.Id);
            //var officesResponse = _mapperMapOfficesDtosToOfficesResponse(officesDtos);
            return userDto == null ? null : userDto;
        }
    }
}
