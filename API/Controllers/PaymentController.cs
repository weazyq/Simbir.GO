using Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Tools.Result;

namespace API.Controllers;

public class PaymentController : Controller
{
    private readonly IPaymentService _paymentService;

    public PaymentController(IPaymentService paymentService)
    {
        _paymentService = paymentService;
    }

    [Authorize]
    [HttpPost("Hesoyam")]
    public Result Hesoyam([FromQuery] Int64 accountId)
    {
        Int64 userId = Int64.Parse(User.FindFirstValue("Id")!);
        return _paymentService.Hesoyam(accountId, userId, User.IsInRole("Admin"));
    }
}
