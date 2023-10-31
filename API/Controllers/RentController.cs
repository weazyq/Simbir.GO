using Domain.Rents;
using Domain.Services;
using Domain.Transports;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Tools.Result;

namespace API.Controllers;

public class RentController : Controller
{
    private readonly IRentService _rentService;

    public RentController(IRentService rentService)
    {
        _rentService = rentService;
    }

    [Authorize]
    [HttpGet("Rent")]
    public DataResult<Rent> Info([FromQuery] Int64 rentId)
    {
        Int64 userId = Int64.Parse(User.FindFirstValue("Id")!);
        return _rentService.Info(rentId, userId);
    }

    [Authorize]
    [HttpGet("Rent/MyHistory")]
    public Rent[] GetAccountRentHistory()
    {
        Int64 userId = Int64.Parse(User.FindFirstValue("Id")!);

        return _rentService.GetAccountRentHistory(userId);
    }

    [Authorize]
    [HttpGet("Rent/TransportHistory")]
    public DataResult<Rent[]> GetTransportRentHistory([FromQuery] Int64 transportId)
    {
        Int64 userId = Int64.Parse(User.FindFirstValue("Id")!);

        return _rentService.GetTransportRentHistory(transportId, userId);
    }
}
