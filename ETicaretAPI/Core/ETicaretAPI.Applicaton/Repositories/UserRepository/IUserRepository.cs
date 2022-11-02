using ETicaretAPI.Applicaton.Features.Commands.User.CreateUser;
using ETicaretAPI.Applicaton.Features.Commands.User.LoginUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Applicaton.Repositories.UserRepository
{
    public interface IUserRepository
    {

        public Task<bool> AddUserAsync(CreateUserCommandRequest request);

        public Task<bool> LoginUser(LoginUserCommandRequest request);
    }
}
