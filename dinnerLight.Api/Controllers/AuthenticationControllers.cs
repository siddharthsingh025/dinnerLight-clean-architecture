using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dinnerLight.Application.Services.Authentication;
using dinnerLight.Contract.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace dinnerLight.Api.Controllers;

[ApiController]
[Route("auth")]
public class AuthenticationControllers : ControllerBase
{
    private readonly IAuthenticationService _authService;

    public AuthenticationControllers(IAuthenticationService authService)
    {
        _authService = authService;
    }

    [HttpPost("register")]
    public IActionResult Register(RegisterRequest request)
    {

        var authResult = _authService.Register(
            request.FirstName,
            request.LastName,
             request.Email,
              request.Password);

        var response = new AuthenticationResponse(
            authResult.Id,
             authResult.FirstName,
              authResult.LastName,
               authResult.Email,
               authResult.Token);
               
        return Ok(response);

    }

    [HttpPost("login")]
    public IActionResult Login(LoginRequest request)
    {
        return Ok(request);
    }

}
