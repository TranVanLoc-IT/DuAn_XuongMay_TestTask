using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XuongMayNhom8.Repositories.Configuration;

namespace XuongMayNhom8.Repositories.Repositories.AuthRepository
{
    public interface IAuthRepository
    {
        string AuthenticateUser(UserLogin userLogin);
    }
}
