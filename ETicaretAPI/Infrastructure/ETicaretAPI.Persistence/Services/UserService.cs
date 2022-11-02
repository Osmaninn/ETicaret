using ETicaretAPI.Applicaton.Abstractions.Services;
using ETicaretAPI.Applicaton.Abstractions.Token;
using ETicaretAPI.Applicaton.DTOs;
using ETicaretAPI.Applicaton.Features.Commands.User.CreateUser;
using ETicaretAPI.Applicaton.Features.Commands.User.LoginUser;
using ETicaretAPI.Applicaton.Repositories.UserRepository;
using ETicaretAPI.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;

namespace ETicaretAPI.Persistence.Services
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;
        private UserManager<AppUser> _userManager;
        private SignInManager<AppUser> _signInManager;
        private ITokenHandler _tokenHandler;

        public UserService(IUserRepository userRepository,
            UserManager<AppUser> userManager, 
            SignInManager<AppUser> signInManager,
            ITokenHandler tokenHandler)
        {
            _userRepository = userRepository;
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenHandler = tokenHandler;
        }

        public async Task<bool> CreateUserAsync(CreateUserCommandRequest request)
        {
            return (await _userRepository.AddUserAsync(request)); 
        }

        public async Task<LoginUserCommandResponse> LoginUser(LoginUserCommandRequest request)
        {
            AppUser user = await _userManager.FindByNameAsync(request.UserNameOrEmail);
            if (user == null)
            {
                user = await _userManager.FindByEmailAsync(request.UserNameOrEmail);
            }

            if (user == null)
            {
                throw new Exception("Kullanıcı adı hatalı...");
            }

            SignInResult result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);
            //yetkiler belirlenir. 
            if (result.Succeeded)
            {
                Token token = _tokenHandler.CreateAccessToken();
                //UpdateRefreshToken(token.RefreshToken, user);
                await _userManager.UpdateAsync(user);
                return new LoginUserSuccessCommandResponse() {
                    Token = token
                };
            }
            return new LoginUserErrorCommandResponse() {
                Message = "Kullanıcı hatası"
            };
        }

        public async Task UpdateRefreshToken(string refreshToken, AppUser user)
        {

            if (user != null)
            {
                //user.RefreshToken = refreshToken;
                user.UserName = "deneme";
                //user.RefreshTokenEndTime = user.RefreshTokenEndTime?.AddSeconds(5);
                await _userManager.UpdateAsync(user);
            }
            else throw new Exception("refresh token hata");
            
        }
    }
}
