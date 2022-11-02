using ETicaretAPI.Applicaton.Features.Commands.User.CreateUser;
using ETicaretAPI.Applicaton.Features.Commands.User.LoginUser;
using ETicaretAPI.Applicaton.Repositories.UserRepository;
using ETicaretAPI.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistence.Repositories.UserRepository
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<AppUser> _userManager;

        public UserRepository(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<bool> AddUserAsync(CreateUserCommandRequest request)
        {
            await _userManager.CreateAsync(new()
            {
                Id = Guid.NewGuid().ToString(),
                UserName = request.UserName,
                Email = request.Email,
            },request.Password);
            return new();
        }

        public Task<bool> LoginUser(LoginUserCommandRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
