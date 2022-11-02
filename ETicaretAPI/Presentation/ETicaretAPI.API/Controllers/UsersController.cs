using ETicaretAPI.Applicaton.Abstractions.Services;
using ETicaretAPI.Applicaton.Features.Commands.User.CreateUser;
using ETicaretAPI.Applicaton.Features.Commands.User.LoginUser;
using ETicaretAPI.Applicaton.ViewModels.User;
using ETicaretAPI.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IMediator _mediator;
        private UserManager<AppUser> _userManager;

        public UsersController(IMediator mediator, UserManager<AppUser> userManager)
        {
            _mediator = mediator;
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreateUserCommandRequest request)
        {
            await _mediator.Send(request);
            return Ok();
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Login(LoginUserCommandRequest request)
        {
            LoginUserCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
