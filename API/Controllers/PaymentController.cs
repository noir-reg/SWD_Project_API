﻿
using BusinessObjects.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace API.Controllers;

[Route("api/payments")]
[ApiController]
public class PaymentController : ControllerBase
{
    private readonly IPaymentService _paymentService;
    public PaymentController(IPaymentService paymentService)
    {
        _paymentService = paymentService;
    }
    [HttpPost]
    public ActionResult<PaymentResponse> Processpayment([FromBody] PaymentRequest paymentRequest)
    {
        var result = _paymentService.ProcessPayment(paymentRequest);
        if (result.isSuccess)
            return Ok(result);
        else return BadRequest(result);
    }
    [HttpGet]
    public ActionResult<List<PaymentInfo>> GetAllPaymentInfor()
    {
        var result = _paymentService.GetAllPaymentInfo();
        return Ok(result);
    }
    [HttpGet("paymentId")]
    public ActionResult<PaymentInfo> GetPaymentInfor(string paymentId)
    {
        var result = _paymentService.GetPaymentInfo(paymentId);
        return Ok(result);
    }
}
