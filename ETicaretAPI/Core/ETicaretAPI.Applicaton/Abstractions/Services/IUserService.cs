using ETicaretAPI.Applicaton.DTOs;
using ETicaretAPI.Applicaton.Features.Commands.User.CreateUser;
using ETicaretAPI.Applicaton.Features.Commands.User.LoginUser;
using ETicaretAPI.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Applicaton.Abstractions.Services
{
    public interface IUserService
    {
        Task<bool> CreateUserAsync(CreateUserCommandRequest Request);

        Task<LoginUserCommandResponse> LoginUser(LoginUserCommandRequest request);

        Task UpdateRefreshToken(string refreshToken, AppUser user);
    }
}
