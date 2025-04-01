using lending_skills_backend.DataAccess;
using lending_skills_backend.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace lending_skills_backend.Repositories
{
    public class ProfessorsRepository
    {
        private readonly ApplicationDbContext _context;

        public ProfessorsRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DbProfessor>> GetProfessorsAsync()
        {
            return await _context.Professors.ToListAsync();
        }

        public async Task<DbProfessor?> GetProfessorByIdAsync(int id)
        {
            return await _context.Professors.FindAsync(id);
        }

        public async Task AddProfessorAsync(DbProfessor professor)
        {
            _context.Professors.Add(professor);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateProfessorAsync(DbProfessor professor)
        {
            _context.Professors.Update(professor);
            await _context.SaveChangesAsync();
        }

       
    }
}
