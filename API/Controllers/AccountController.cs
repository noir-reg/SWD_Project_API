using BusinessObjects.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Interface;

namespace API.Controllers
{
    [Route("api/accounts")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }
        [HttpPost("get-accounts")]
        public IActionResult GetAccounts(int? page, int? size, AccountFilter accountFilter)
        {

            return Ok(_accountService.GetAccounts(accountFilter, new Pagination
            {
                Page = page,
                Size = size
            }
           ));
        }
        [HttpPost("create-account")]
        public IActionResult CreateAccount(CreateAccountRequest createAccountRequest)
        {

            if (_accountService.CreateAccount(createAccountRequest))
                return Ok("Create account successfully");
            return BadRequest("Can not create account");
        }
        [HttpPut("update-account")]
        public IActionResult UpdateAccount(UpdateAccountRequest updateAccountRequest)
        {

            if (_accountService.UpdateAccount(updateAccountRequest))
                return Ok("Update account successfully");
            return BadRequest("Can not update account");
        }
        [HttpGet("get-account-by-id")]
        public IActionResult GetAccountById(int accountId)
        {
            return Ok(_accountService.GetAccountById(accountId));
        }
        [HttpGet("get-account-roles")]
        public IActionResult GetAccountRoles()
        {
            return Ok(_accountService.GetAccountRoles());
        }
        [HttpGet("update-account-point")]
        public IActionResult UpdateAccountPoint(int accountId, int point)
        {
            if (_accountService.UpdateAccountPoint(accountId, point))
                return Ok("Update successfully");
            return BadRequest("Can not update");
        }
    }
}
