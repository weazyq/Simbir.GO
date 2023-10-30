using Domain.Transports;
using Tools.Result;

namespace Domain.Services;

public interface ITransportService
{
    public Result Save(TransportBlank blank, Int64 userId);
    public Transport? Get(Int64 id);
    public Result Update(Int64 id, TransportBlank blank, Int64 userId);
    public Result Delete(Int64 id, Int64 userId);
}
