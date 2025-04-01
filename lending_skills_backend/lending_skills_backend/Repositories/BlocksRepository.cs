using lending_skills_backend.DataAccess;
using lending_skills_backend.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace lending_skills_backend.Repositories
{
    public class BlocksRepository
    {
        private readonly ApplicationDbContext _context;

        public BlocksRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DbBlock>> GetBlocksAsync()
        {
            return await _context.Blocks.ToListAsync();
        }

        public async Task<DbBlock?> GetBlockByIdAsync(int id)
        {
            return await _context.Blocks.FindAsync(id);
        }

        public async Task AddBlockAsync(DbBlock block)
        {
            _context.Blocks.Add(block);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateBlockAsync(DbBlock block)
        {
            _context.Blocks.Update(block);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteBlockAsync(int id)
        {
            var block = await _context.Blocks.FindAsync(id);
            if (block != null)
            {
                _context.Blocks.Remove(block);
                await _context.SaveChangesAsync();
            }
        }
    }
}
