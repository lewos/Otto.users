using MongoDB.Driver;
using Otto.users.DTOs;

namespace Otto.users.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly IMongoCollection<User> _users;

        public UsersRepository(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _users = database.GetCollection<User>(settings.UsersCollectionName);
        }

        public async Task<List<User>> GetUsersAsync()
        {
            var users = await _users.FindAsync(User => true);
            return users.ToList();
        }

        public async Task<User> GetUserByIdAsync(string id)
        {
            var user = await _users.FindAsync(User => User.Id == id);
            return user.FirstOrDefault();
        }

        public async Task<User> GetUserByMailPassAsync(string mail, string pass)
        {
            var user = await _users.FindAsync(User => User.Mail == mail && User.Pass == pass);
            return user.FirstOrDefault();
        }

        public async Task<User> CreateUserAsync(User user)
        {

            await _users.InsertOneAsync(user);
            var auxUser = await _users.FindAsync(User =>
                    User.Mail == user.Mail &&
                    User.Name == user.Name &&
                    User.Rol == user.Rol);
            var algo = auxUser.ToList();
            return algo[0];
        }

        public async Task<bool> UpdateUserAsync(string id, User user)
        {
            var response = await _users.ReplaceOneAsync(User => User.Id == id, user);
            return response.ModifiedCount > 0;
        }

        public async Task<bool> DeleteUserAsync(string id)
        {
            var response = await _users.DeleteOneAsync(User => User.Id == id);
            return response.DeletedCount > 0;
        }
    }
}
