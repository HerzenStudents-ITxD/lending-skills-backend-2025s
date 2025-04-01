
using lending_skills_backend.DataAccess;
using lending_skills_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace lending_skills_backend.Repositories;

public class UsersRepository
{
    private readonly ApplicationDbContext _context;

    public UsersRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<DbUser>> GetUsersAsync()
    {
        return await _context.Users.ToListAsync();
    }

    public async Task<DbUser?> GetUserByIdAsync(int id)
    {
        return await _context.Users.FindAsync(id);
    }

    public async Task AddUserAsync(DbUser user)
    {
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
    }


    public async Task UpdateUserAsync(DbUser user)
    {
        _context.Users.Update(user);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> SwitchActiveStatusAsync(Guid userId, bool isActive)
    {
        var user = await _context.Users.FindAsync(userId);
        if (user == null) return false;

        user.Status = isActive ? "Active" : "Inactive"; 
        _context.Users.Update(user);
        await _context.SaveChangesAsync();
        return true;
    }
}