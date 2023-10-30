using Domain.Transports;
using Tools.Result;

namespace Services.Transports.Repositories;

public interface ITransportRepository
{
    public Result Save(TransportBlank blank, Int64 userId);
    public Transport? Get(Int64 id);
    public Transport? GetByOwner(Int64 id);
    public Result Update(Int64 id, TransportBlank blank, Int64 userId);
    public Result Delete(Int64 id);
}
