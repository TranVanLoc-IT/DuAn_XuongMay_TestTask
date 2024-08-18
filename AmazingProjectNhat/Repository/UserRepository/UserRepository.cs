using AmazingProjectNhat.Entity;

namespace AmazingProjectNhat.Repository.UserRepository
{
    public class UserRepository : IUserRepository
    {
        public List<User> GetUsers()
        {
            List<User> users = new List<User>();
            users.Add(new User
            {
                Name = "Admin",
                Id = "1",
                Password = "123",
                Role = "Admin",
                Username = "admin"
            });
            users.Add(new User
            {
                Name = "Manager",
                Id = "2",
                Password = "123",
                Role = "Manager",
                Username = "manager"
            });

            return users;
        }
    }
}
