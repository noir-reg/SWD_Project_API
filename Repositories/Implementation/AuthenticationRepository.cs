using BusinessObjects.DTOs;
using BusinessObjects.Models;
using Google.Apis.Auth;
using Microsoft.Data.SqlClient.Server;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace Repositories.Implementation
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        private readonly MilkShopContext _context = new();
        private readonly IConfiguration _config;
        public AuthenticationRepository(IConfiguration config)
        {
            _config = config;
        }
        public LoginResponse Login(LoginRequest loginRequest)
        {
            var acc = _context.Accounts.Include(x => x.Role).FirstOrDefault(x => (x.Email.ToLower().Equals(loginRequest.email.ToLower()) || x.Phone.Equals(loginRequest.email)) && x.Password.Equals(loginRequest.password) && x.IsActive);
            if (acc != null)
            {
                JWTUtils jwt = new(_config);
                var token = jwt.GenerateToken(acc.Role.Name);
                return new LoginResponse
                {
                    Id = acc.Id,
                    Password = acc.Password,
                    Email = acc.Email,
                    Fullname = acc.Fullname,
                    Birthday = acc.Birthday,
                    Roleid = acc.Roleid,
                    Address = acc.Address,
                    IsActive = acc.IsActive,
                    Gender = acc.Gender,
                    Point = acc.Point,
                    Phone = acc.Phone,
                    Role = acc.Role.Name,
                    AccessToken = token
                };
            }
            return null;
        }

        public LoginResponse LoginWithGoogle(string email, string fullName, string googleToken)
        {
            try
            {
                var payload = GoogleJsonWebSignature.ValidateAsync(googleToken);               
            }
            catch (InvalidJwtException)
            {               
                return null;
            }
            var acc = _context.Accounts.Include(x => x.Role).FirstOrDefault(x => x.Email.ToLower().Equals(email.ToLower())&&x.Roleid==1);
            if (acc != null)
            {
                JWTUtils jwt = new(_config);
                var token = jwt.GenerateToken(acc.Role.Name);
                return new LoginResponse
                {
                    Id = acc.Id,
                    Password = acc.Password,
                    Email = acc.Email,
                    Fullname = acc.Fullname,
                    Birthday = acc.Birthday,
                    Roleid = acc.Roleid,
                    Address = acc.Address,
                    IsActive = acc.IsActive,
                    Gender = acc.Gender,
                    Point = acc.Point,
                    Phone = acc.Phone,
                    Role = acc.Role.Name,
                    AccessToken = token
                };
            }
            else
            {
                _context.Accounts.Add(new Account
                {
                    IsActive = true,
                    Email = email,
                    Fullname = fullName,
                    Point = 0,
                    Roleid = 1
                });
                if (_context.SaveChanges() >= 1)
                {
                    var newAcc = _context.Accounts.Include(x => x.Role).FirstOrDefault(x => x.Email.ToLower().Equals(email.ToLower()));
                    JWTUtils jwt = new(_config);
                    var token = jwt.GenerateToken(newAcc.Role.Name);
                    return new LoginResponse
                    {
                        Id = newAcc.Id,
                        Password = newAcc.Password,
                        Email = newAcc.Email,
                        Fullname = newAcc.Fullname,
                        Birthday = newAcc.Birthday,
                        Roleid = newAcc.Roleid,
                        Address = newAcc.Address,
                        IsActive = newAcc.IsActive,
                        Gender = newAcc.Gender,
                        Point = newAcc.Point,
                        Phone = newAcc.Phone,
                        Role = newAcc.Role.Name,
                        AccessToken = token
                    };
                }
                return null;
            }
        }

        public bool Register(RegisterRequest registerRequest)
        {
            var check = _context.Accounts.FirstOrDefault(x => x.Email.ToLower().Equals(registerRequest.Email.ToLower()));
            if (check != null)
                return false;
            _context.Accounts.Add(new Account
            {
                Address = registerRequest.Address,
                IsActive = true,
                Birthday = registerRequest.Birthday,
                Email = registerRequest.Email,
                Fullname = registerRequest.Fullname,
                Gender = registerRequest.Gender,
                Password = registerRequest.Password,
                Phone = registerRequest.Phone,
                Point = 0,
                Roleid = 1
            });
            var result = _context.SaveChanges();
            if (result >= 1)
                return true;
            return false;
        }
    }
}
