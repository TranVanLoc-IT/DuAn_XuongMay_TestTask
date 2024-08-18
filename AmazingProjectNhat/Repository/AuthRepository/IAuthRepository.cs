using AmazingProjectNhat.Entity;

namespace AmazingProjectNhat.Repository.AuthRepository
{
    public interface IAuthRepository
    {
        string AuthenticateUser(UserLogin userLogin);
    }
}
