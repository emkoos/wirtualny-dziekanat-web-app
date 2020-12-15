using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using WirtualnyDziekanat.Domain.Entities;
using WirtualnyDziekanat.Domain.Repositories;
using WirtualnyDziekanat.Infrastructure.Data;
using System.Threading.Tasks;

namespace WirtualnyDziekanat.Infrastructure.Repositories
{
    public class InformationRepository : IInformationRepository
    {
        private readonly AppDbContext _context;

        public InformationRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Information> GetAsync(Guid id)
            => await Task.FromResult(_context.Information.SingleOrDefault(x => x.Id == id));
        
        public async Task<IEnumerable<Information>> BrowseAsync(string title = "")
        {
            var informations = _context.Information.AsEnumerable();
            if (!string.IsNullOrWhiteSpace(title))
            {
                informations = informations.Where(i => i.Title.ToLowerInvariant()
                                           .Contains(title.ToLowerInvariant()));
            }
            return await Task.FromResult(informations);
        }

        public async Task AddAsync(Information information)
        {
            _context.Add(information);
            await Task.CompletedTask;
        }

        public async Task UpdateAsync(Information information)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(Information information)
        {
            _context.Information.Remove(information);
            await Task.CompletedTask;
        }

    }
}
