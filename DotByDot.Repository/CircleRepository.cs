using DotByDot.Core.Domain.Models;
using DotByDot.Data;
using Microsoft.EntityFrameworkCore;
using System.Drawing;

namespace DotByDot.Repository
{
    public class CircleRepository : ICircleRepository
    {
        private readonly DotByDotContext _dotByDotContext;

        public CircleRepository(DotByDotContext context)
        {
            _dotByDotContext = context;
        }

        public async Task<int> CreateAsync(CircleSet item)
        {
            await _dotByDotContext.CircleSets.AddAsync(item);
            await _dotByDotContext.SaveChangesAsync();

            return item.Id;
        }

        public async Task<CircleSet?> GetAsync(int id)
        {
            return await _dotByDotContext.CircleSets
                .Include(x=>x.Circles)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<CircleSet?> AddAsync(int id, Circle circle)
        {
            var circleSet = await _dotByDotContext.CircleSets.FindAsync(id);

            if (circleSet != null)
            {
                circle.CircleSetId = id;
                await _dotByDotContext.Circles.AddAsync(circle);
                await _dotByDotContext.SaveChangesAsync();
            }

            return circleSet;
        }
    }
}
