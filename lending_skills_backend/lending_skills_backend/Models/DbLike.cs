using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace lending_skills_backend.Models;

public class DbLike
{
    public const string TableName = "Likes";
    public Guid Id { get; set; }

    public Guid UserId { get; set; }
    public DbUser User { get; set; }

    public Guid WorkId { get; set; }
    public DbWork Work { get; set; }
}


public class DbLikeConfiguration : IEntityTypeConfiguration<DbLike>
{
    public void Configure(EntityTypeBuilder<DbLike> builder)
    {
        builder.ToTable(DbLike.TableName);
        builder.HasKey(u => u.Id);
    }
}

