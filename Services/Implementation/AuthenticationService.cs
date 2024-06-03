using BusinessObjects.DTOs;
using Repositories.Interface;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implementation
{
    public class AuthenticationService : IAuthenticationService
    {   private readonly IAuthenticationRepository _repository;
        public AuthenticationService(IAuthenticationRepository repository)
        {
            _repository = repository;
        }

        public LoginResponse Login(LoginRequest loginRequest)
        {
            return _repository.Login(loginRequest);
        }

        public LoginResponse LoginWithGoogle(string email, string fullName, string googleToken)
        {
            return _repository.LoginWithGoogle(email, fullName, googleToken);
        }

        public bool Register(RegisterRequest registerRequest)
        {
            return _repository.Register(registerRequest);
        }
    }
}
