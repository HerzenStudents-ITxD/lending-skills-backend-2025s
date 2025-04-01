using lending_skills_backend.DataAccess;
using lending_skills_backend.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace lending_skills_backend.Repositories
{
    public class PagesRepository
    {
        private readonly ApplicationDbContext _context;

        public PagesRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DbPage>> GetPagesAsync()
        {
            return await _context.Pages.ToListAsync();
        }

        public async Task<DbPage?> GetPageByIdAsync(int id)
        {
            return await _context.Pages.FindAsync(id);
        }

        public async Task AddPageAsync(DbPage page)
        {
            _context.Pages.Add(page);
            await _context.SaveChangesAsync();
        }

        public async Task UpdatePageAsync(DbPage page)
        {
            _context.Pages.Update(page);
            await _context.SaveChangesAsync();
        }

        public async Task DeletePageAsync(int id)
        {
            var page = await _context.Pages.FindAsync(id);
            if (page != null)
            {
                _context.Pages.Remove(page);
                await _context.SaveChangesAsync();
            }
        }
    }
}

