using lending_skills_backend.DataAccess;
using lending_skills_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace lending_skills_backend.Repositories;

public class ReviewsRepository
{
    private readonly ApplicationDbContext _context;

    public ReviewsRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<DbReview>> GetReviewsAsync()
    {
        return await _context.Reviews.ToListAsync();
    }

    public async Task AddReviewAsync(DbReview review)
    {
        _context.Reviews.Add(review);
        await _context.SaveChangesAsync();
    }
}
