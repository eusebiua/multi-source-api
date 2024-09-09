using MultiSource.Domain.Data.Entities;

namespace MultiSource.Domain.Repositories;

public interface ITourRepository
{
    Task<IEnumerable<Tour>> GetTours();
}
