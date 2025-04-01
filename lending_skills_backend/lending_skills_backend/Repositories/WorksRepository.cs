using lending_skills_backend.DataAccess;
using lending_skills_backend.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace lending_skills_backend.Repositories
{
    public class WorksRepository
    {
        private readonly ApplicationDbContext _context;

        public WorksRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DbWork>> GetWorksAsync()
        {
            return await _context.Works.ToListAsync();
        }

        public async Task<DbWork?> GetWorkByIdAsync(int id)
        {
            return await _context.Works.FindAsync(id);
        }

        public async Task AddWorkAsync(DbWork work)
        {
            _context.Works.Add(work);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateWorkAsync(DbWork work)
        {
            _context.Works.Update(work);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteWorkAsync(int id)
        {
            var work = await _context.Works.FindAsync(id);
            if (work != null)
            {
                _context.Works.Remove(work);
                await _context.SaveChangesAsync();
            }
        }
    }
}
