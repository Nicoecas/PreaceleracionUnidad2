
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PracticaBlog.Data.Interfaces;
using PracticaBlog.Dtos;
using PracticaBlog.Entities;
using PracticaBlog.Services.Interfaces;
using System.Threading.Tasks;

namespace PracticaBlog.Controllers
{
[Route("api/[controller]")]
[ApiController]

    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _repo;
        private readonly ITokenService _tokenService;
        private readonly IMapper mapper;

        public AuthController(IAuthRepository _repo, ITokenService _tokenService, IMapper mapper)
        {
            this.mapper = mapper;
            this._repo = _repo;
            this._tokenService = _tokenService;
        }
        [HttpPost("Register")]
        public async Task<IActionResult> Register(UserDbRegisterDto usuarioDto)
        {
            usuarioDto.EmailAddress = usuarioDto.EmailAddress.ToLower();
            if(await _repo.ExistUser(usuarioDto.EmailAddress))
            {
                return BadRequest("Correo ya registrado");
            }
            var usuarioNuevo = mapper.Map<UserDb>(usuarioDto);
            var usuarioCreado = await _repo.Register(usuarioNuevo, usuarioDto.Password);
            return Ok(usuarioCreado);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(UserDbLoginDto userLoginDto)
        {
            var usuarioFromRepo = await _repo.Login(userLoginDto.EmailAdress, userLoginDto.Password);
            if (usuarioFromRepo == null)
            {
                return Unauthorized();
            }
            var token = _tokenService.CreateToken(usuarioFromRepo);
            return Ok(new
            {
                token = token,
                usuarioFromRepo = usuarioFromRepo
            });
        }
    }
}
 