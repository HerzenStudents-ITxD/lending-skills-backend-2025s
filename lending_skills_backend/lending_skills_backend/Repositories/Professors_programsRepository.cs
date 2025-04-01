using lending_skills_backend.DataAccess;
using lending_skills_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace lending_skills_backend.Repositories;

public class ProfessorsProgramsRepository
{
    private readonly ApplicationDbContext _context;

    public ProfessorsProgramsRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<DbProfessorProgram>> GetProfessorsProgramsAsync()
    {
        return await _context.ProfessorsPrograms.ToListAsync();
    }

    public async Task<DbProfessorProgram?> GetProfessorProgramByIdAsync(int professorId, int programId)
    {
        return await _context.ProfessorsPrograms.FindAsync(professorId, programId);
    }

    public async Task AddProfessorProgramAsync(DbProfessorProgram professorProgram)
    {
        _context.ProfessorsPrograms.Add(professorProgram);
        await _context.SaveChangesAsync();
    }

    public async Task RemoveProfessorProgramAsync(int professorId, int programId)
    {
        var professorProgram = await _context.ProfessorsPrograms.FindAsync(professorId, programId);
        if (professorProgram != null)
        {
            _context.ProfessorsPrograms.Remove(professorProgram);
            await _context.SaveChangesAsync();
        }
    }
}
