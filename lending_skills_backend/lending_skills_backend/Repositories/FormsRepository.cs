using lending_skills_backend.DataAccess;
using lending_skills_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace lending_skills_backend.Repositories;
public class FormsRepository
{
    private readonly ApplicationDbContext _context;

    public FormsRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<DbForm>> GetFormsAsync()
    {
        return await _context.Forms.ToListAsync();
    }

    public async Task<DbForm?> GetFormByIdAsync(int formId)
    {
        return await _context.Forms.FindAsync(formId);
    }

    public async Task AddFormAsync(DbForm form)
    {
        _context.Forms.Add(form);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateFormAsync(DbForm form)
    {
        _context.Forms.Update(form);
        await _context.SaveChangesAsync();
    }

    public async Task RemoveFormAsync(int formId)
    {
        var form = await _context.Forms.FindAsync(formId);
        if (form != null)
        {
            _context.Forms.Remove(form);
            await _context.SaveChangesAsync();
        }
    }
}
