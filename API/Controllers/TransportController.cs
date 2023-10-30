using Domain.Services;
using Domain.Transports;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Tools.Result;

namespace API.Controllers
{
    public class TransportController : Controller
    {
        private readonly ITransportService _transportService;

        public TransportController(ITransportService transportService) 
        {
            _transportService = transportService;
        }

        [HttpGet("Transport")]
        public DataResult<Transport> Get([FromQuery] Int64 id)
        {
            Transport? transport = _transportService.Get(id);
            if (transport is null) return DataResult<Transport>.Fail("Указанный автомобиль удалён или не существует");

            return DataResult<Transport>.Success(transport);
        }

        [Authorize]
        [HttpPost("Transport")]
        public Result Save([FromBody] TransportBlank blank)
        {
            Int64 userId = Int64.Parse(User.FindFirstValue("Id")!);
            return _transportService.Save(blank, userId);
        }

        [Authorize]
        [HttpPut("Transport")]
        public Result Update([FromQuery] Int64 id, [FromBody] TransportBlank blank)
        {
            Int64 userId = Int64.Parse(User.FindFirstValue("Id")!);
            return _transportService.Update(id, blank, userId);
        }

        [Authorize]
        [HttpDelete("Transport")]
        public Result Delete([FromQuery] Int64 id)
        {
            Int64 userId = Int64.Parse(User.FindFirstValue("Id")!);
            return _transportService.Delete(id, userId);
        }
    }
}
