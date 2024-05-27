﻿using BusinessObjects.DTOs;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Interface;

namespace API.Controllers
{
    [Route("api/authentication")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;
        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }
        [HttpPost("login")]
        public IActionResult Login(LoginRequest loginRequest)
        {
            if (_authenticationService.Login(loginRequest) != null)
                return Ok(_authenticationService.Login(loginRequest));
            return BadRequest("Invalid login");
        }
        [HttpPost("register")]
        public IActionResult Register(RegisterRequest registerRequest)
        {
            if (_authenticationService.Register(registerRequest))
                return Ok("Register successfully");
            return BadRequest("Can not register");
        }
    }
}
