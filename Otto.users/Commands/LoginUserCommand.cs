using MediatR;
using Otto.users.DTOs;
using System.Text.Json.Serialization;

namespace Otto.users.Commands
{
    public class LoginUserCommand : IRequest<User>
    {
        [JsonPropertyName("userMail")]
        public string Mail { get; set; }
        [JsonPropertyName("userPass")]
        public string Pass { get; set; }
    }
}
