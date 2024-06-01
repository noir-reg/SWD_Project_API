using BusinessObjects.DTOs;
using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interface;

public interface IAccountRepository
{
    public AccountResponse GetAccountById(int id);
    public bool CreateAccount(CreateAccountRequest createAccountRequest);
    public bool UpdateAccount(UpdateAccountRequest updateAccountRequest);
    public GetAccountsResponse GetAccounts(AccountFilter accountFilter,Pagination? pagination);
    public List<AccountRole> GetAccountRoles();
    public bool UpdateAccountPoint(int accountId,int point);
}