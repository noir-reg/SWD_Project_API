using BusinessObjects.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interface
{
    public interface IAuthenticationRepository
    {
        public LoginResponse Login(LoginRequest loginRequest);      
        public LoginResponse LoginWithGoogle(string email,string fullName);      
        public bool Register(RegisterRequest registerRequest);      
    }
}
