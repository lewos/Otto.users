using MediatR;
using Otto.users.DTOs;
using Otto.users.Queries;
using Otto.users.Repositories;

namespace Otto.users.Handlers.Query
{
    public class GetAllUsersHandler : IRequestHandler<GetAllUsersQuery, List<User>>
    {
        private readonly IUsersRepository _userRepository;
        public GetAllUsersHandler(IUsersRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<List<User>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var usersDtos = await _userRepository.GetUsersAsync();
            //var officesResponse = _mapperMapOfficesDtosToOfficesResponse(officesDtos);
            return usersDtos;
        }
    }
}
