using MediatR;
using Otto.users.Commands;
using Otto.users.DTOs;
using Otto.users.Repositories;
using System.Net;
using System.Net.Mail;

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

            //Mandar mail
            SendMail(userDto);
            
            return userDto;
        }

        private void SendMail(User userDto)
        {
            try
            {
                var toMail = userDto.Mail;
                var fromMail = "otto.mail.soporte@gmail.com";
                var subject = "Usuario Otto";                
                var pass = Environment.GetEnvironmentVariable("MAIL_PASS");

                var body = $" usuario: {userDto.Mail} " +
                          $" contraseña: {userDto.Pass}";

                var smtpClient = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential(fromMail, pass),
                    EnableSsl = true,
                };

                smtpClient.Send(fromMail, toMail, subject, body);
            }
            catch (Exception ex )
            {
                Console.WriteLine(ex);
            }
           
        }
    }
}
