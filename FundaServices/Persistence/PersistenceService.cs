using EFCore.BulkExtensions;
using Microsoft.EntityFrameworkCore;
using PropertyServices.Persistence.Entities;
using PropertyServices.Search.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PropertyServices.Persistence
{
    public class PersistenceService : IPersistenceService
    {
        private readonly FundaDbContext _context;

        public PersistenceService(FundaDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<List<MakelaarDto>> GetTop10Makelaars(SearchOptions options)
        {
            return await (
                    from p in _context.Properties
                    join m in _context.Makelaars on p.MakelaarId equals m.MakelaarId
                    where p.City == options.City && 
                        (!options.HasGarden || p.HasGarden == options.HasGarden) // only filter by Garden if it's selected, otherwise ignore (don't exclude properties that have gardens)
                    group m by new { m.MakelaarId, m.Name } into g
                    orderby g.Count() descending
                    select new MakelaarDto(g.Key.MakelaarId, g.Key.Name, g.Count())
                )
                .Take(10)
                .ToListAsync();
        }

        /// <summary>
        /// Imports properties to DB
        /// </summary>
        /// <param name="properties">Real estate properties</param>
        public async Task ImportProperties(List<Property> properties)
        {
            // bulk insert because we expect a large amount of properties
            if (properties.Count == 0)
            {
                return;
            }

            var propertyIds = properties.Select(x => x.PropertyId).Distinct().ToList();
            var existingProperties = await _context.Properties.Where(x => propertyIds.Contains(x.PropertyId)).ToListAsync();

            IList<Property> newProperties = properties.Where(x => !existingProperties.Exists(p => p.PropertyId == x.PropertyId)).ToList();

            if (!newProperties.Any())
            {
                return;
            }

            await _context.BulkInsertAsync(newProperties);
        }

        public async Task ImportOrUpdateMakelaars(List<Makelaar> makelaars)
        {
            // classic EF upsert
            if (makelaars.Count <= 0)
            {
                return;
            }

            var makelaarIds = makelaars.Select(x => x.MakelaarId).Distinct().ToList();
            var existingMakelaars = await _context.Makelaars.Where(x => makelaarIds.Contains(x.MakelaarId)).ToListAsync();

            foreach (var makelaar in makelaars)
            {
                var existingEntity = existingMakelaars.FirstOrDefault(x => x.MakelaarId == makelaar.MakelaarId);

                if (existingEntity != null)
                {
                    if (!string.Equals(existingEntity.Name, makelaar.Name))
                    {
                        existingEntity.Name = makelaar.Name;
                    }
                }
                else
                {
                    _context.Makelaars.Add(makelaar);
                }
            }

            await _context.SaveChangesAsync();
        }
    }
}
