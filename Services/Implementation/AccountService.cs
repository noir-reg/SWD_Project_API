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
    public class AccountService : IAccountService
    {  private readonly IAccountRepository _repository;
        public AccountService(IAccountRepository repository)
        {
            _repository = repository;
        }

        public bool CreateAccount(CreateAccountRequest createAccountRequest)
        {
            return _repository.CreateAccount(createAccountRequest);
        }

        public AccountResponse GetAccountById(int id)
        {
            return _repository.GetAccountById(id);
        }

        public List<AccountRole> GetAccountRoles()
        {
            return _repository.GetAccountRoles();
        }

        public GetAccountsResponse GetAccounts(AccountFilter accountFilter, Pagination? pagination)
        {
            return _repository.GetAccounts(accountFilter, pagination);
        }

        public bool UpdateAccount(UpdateAccountRequest updateAccountRequest)
        {
            return _repository.UpdateAccount(updateAccountRequest);
        }

        public bool UpdateAccountPoint(int accountId, int point)
        {
           return _repository.UpdateAccountPoint(accountId, point);
        }
    }
}
