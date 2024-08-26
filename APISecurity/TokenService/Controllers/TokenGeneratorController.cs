using Microsoft.AspNetCore.Mvc;
using TokenService.Models;
using TokenService.Services;

namespace TokenService.Controllers
{
    [ApiController]
    //[Route("[controller]")]
    public class TokenGeneratorController : ControllerBase
    {
       
        private readonly ILogger<TokenGeneratorController> _logger;
        private readonly ITokenGenerator generatorService;
        private readonly IAuthenticationService service;
        public TokenGeneratorController(ILogger<TokenGeneratorController> logger, ITokenGenerator generator,IAuthenticationService service)
        {
            _logger = logger;
            generatorService = generator;
            this.service = service;
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login(LoginModel model) 
        {
          TokenResponseData responseData = new TokenResponseData();
          AppUser user= service.AuthenticateUser(model.Email, model.Password);
            if (user == null)
            {
                responseData.Error = "Invalid Id or Password";
            }
            else
            {
                responseData = generatorService.GenerateToken(user, new string[] { user.Role });
            }
            return Ok(responseData);
        }

        [HttpPost]
        [Route("GetToken")]
        public IActionResult GetToken(TokenRequestData model)
        {
            TokenResponseData responseData;
            try
            {
                responseData=generatorService.GenerateToken(model.User, model.Role);
            }
            catch (Exception ex) 
            {
                responseData = new TokenResponseData();
                responseData.Error=ex.Message;

            }
            return Ok(responseData);
        }
    }
}
