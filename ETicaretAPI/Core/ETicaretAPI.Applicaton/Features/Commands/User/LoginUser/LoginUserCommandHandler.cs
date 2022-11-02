using ETicaretAPI.Applicaton.Abstractions.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Applicaton.Features.Commands.User.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommandRequest, LoginUserCommandResponse>
    {
        private IUserService _userService;

        public LoginUserCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<LoginUserCommandResponse> Handle(LoginUserCommandRequest request, CancellationToken cancellationToken)
        {
            return (await _userService.LoginUser(request));
            
        }
    }
}
