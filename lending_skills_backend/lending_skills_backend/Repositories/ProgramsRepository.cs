using lending_skills_backend.DataAccess;
using lending_skills_backend.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace lending_skills_backend.Repositories
{
    public class ProgramsRepository
    {
        private readonly ApplicationDbContext _context;

        public ProgramsRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DbProgram>> GetProgramsAsync()
        {
            return await _context.Programs.ToListAsync();
        }

        public async Task<DbProgram?> GetProgramByIdAsync(int id)
        {
            return await _context.Programs.FindAsync(id);
        }

        public async Task AddProgramAsync(DbProgram program)
        {
            _context.Programs.Add(program);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateProgramAsync(DbProgram program)
        {
            _context.Programs.Update(program);
            await _context.SaveChangesAsync();
        }

      
    }
}
