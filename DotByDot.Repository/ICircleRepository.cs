using DotByDot.Core.Domain.Models;
using System.Security.Principal;

namespace DotByDot.Repository
{
    public interface ICircleRepository
    {
        public Task<CircleSet?> GetAsync(int id);

        public Task<int> CreateAsync(CircleSet item);

        public Task<CircleSet?> AddAsync(int id, Circle circle);
    }
}
