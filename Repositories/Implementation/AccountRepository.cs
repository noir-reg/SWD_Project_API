using BusinessObjects.DTOs;
using BusinessObjects.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Numerics;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Implementation
{
    public class AccountRepository : IAccountRepository
    {
        private readonly MilkShopContext _context = new();
        public bool CreateAccount(CreateAccountRequest createAccountRequest)
        {
            _context.Accounts.Add(new Account
            {
                Address = createAccountRequest.Address,
                Birthday = createAccountRequest.Birthday,
                Email = createAccountRequest.Email,
                Fullname = createAccountRequest.Fullname,
                Gender = createAccountRequest.Gender,
                IsActive = true,
                Password = createAccountRequest.Password,
                Phone = createAccountRequest.Phone,
                Point = null,
                Roleid = createAccountRequest.Roleid
            });

            if (_context.SaveChanges() >= 1)
                return true;
            return false;
        }

        public AccountResponse GetAccountById(int id)
        {
            return _context.Accounts.Where(x => x.Id == id).Include(x => x.Role).Select(x => new AccountResponse
            {
                Address = x.Address,
                Birthday = x.Birthday,
                Email = x.Email,
                Fullname = x.Fullname,
                Gender = x.Gender,
                Id = x.Id,
                IsActive = x.IsActive,
                Phone = x.Phone,
                Point = x.Point,
                Role = x.Role.Name,
                Roleid = x.Roleid
            }).FirstOrDefault();
        }
        public List<AccountRole> GetAccountRoles()
        {
            return _context.Roles.Select(x => new AccountRole
            {
                Name = x.Name,
                Roleid = x.Roleid
            }).ToList();
        }
        public GetAccountsResponse GetAccounts(AccountFilter accountFilter, Pagination? pagination)
        {
            accountFilter.NameOrEmailSearchKeyWord ??= string.Empty;
            var list = _context.Accounts.Include(x => x.Role).
                  Where(x => (x.Email.Contains(accountFilter.NameOrEmailSearchKeyWord)
                  || x.Fullname.Contains(accountFilter.NameOrEmailSearchKeyWord))
                  && (accountFilter.IsActive == null || x.IsActive == accountFilter.IsActive)
                  && (accountFilter.RoleId == null || x.Roleid == accountFilter.RoleId))
                  .Select(x => new AccountResponse
                  {
                      Address = x.Address,
                      Birthday = x.Birthday,
                      Email = x.Email,
                      Fullname = x.Fullname,
                      Gender = x.Gender,
                      Id = x.Id,
                      IsActive = x.IsActive,
                      Phone = x.Phone,
                      Point = x.Point,
                      Role = x.Role.Name,
                      Roleid = x.Roleid
                  });
            if (pagination == null || pagination.Page == null || pagination.Size == null)
            {
                return new GetAccountsResponse
                {
                    Accounts = list.ToList(),
                    Page = 1,
                    Size = list.Count(),
                    Total = list.Count()
                };
            }
            var paginationList = list.Skip((int)((pagination.Page - 1) * pagination.Size)).Take((int)pagination.Size).ToList();

            return new GetAccountsResponse
            {
                Accounts = paginationList,
                Page = pagination.Page,
                Size = pagination.Size,
                Total = list.Count()
            };

        }

        public bool UpdateAccount(UpdateAccountRequest updateAccountRequest)
        {
            var acc = _context.Accounts.Where(x => x.Id == updateAccountRequest.Id).FirstOrDefault();
            if (acc == null)
                return false;
            acc.Address = updateAccountRequest.Address == null ? acc.Address : updateAccountRequest.Address;
            acc.Birthday = updateAccountRequest.Birthday == null ? acc.Birthday : updateAccountRequest.Birthday;
            acc.Fullname = updateAccountRequest.Fullname == null ? acc.Fullname : updateAccountRequest.Fullname;
            acc.Gender = updateAccountRequest.Gender == null ? acc.Gender : updateAccountRequest.Gender;
            acc.IsActive = (bool)(updateAccountRequest.IsActive == null ? acc.IsActive : updateAccountRequest.IsActive);
            acc.Password = updateAccountRequest.Password;
            acc.Phone = updateAccountRequest.Phone;
            if (_context.SaveChanges() >= 1)
                return true;
            return false;

        }

        public bool UpdateAccountPoint(int accountId, int point)
        {
            var acc = _context.Accounts.Where(x => x.Id == accountId).FirstOrDefault();
            acc.Point = point;
            if (_context.SaveChanges() >= 1)
                return true;
            return false;
        }
    }
}
