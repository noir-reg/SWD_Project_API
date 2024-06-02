using BusinessObjects.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interface
{
    public interface IAuthenticationService
    {
        public LoginResponse Login(LoginRequest loginRequest);  
        public bool Register(RegisterRequest registerRequest);
        public LoginResponse LoginWithGoogle(string email, string fullName);
    }
}
