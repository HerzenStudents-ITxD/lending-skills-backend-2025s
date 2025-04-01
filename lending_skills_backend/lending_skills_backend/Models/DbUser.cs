using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lending_skills_backend.Models;

public class DbUser
{
    public const string TableName = "Users";
    public Guid Id { get; set; }

    public string? Photo { get; set; }
    public string Profession { get; set; }
    public string? Description { get; set; }
    public string? Social { get; set; }
    public string? SocialDescription { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string? Patronymic { get; set; }
    public string Login { get; set; }
    public string PasswordHash { get; set; }
    public string Salt { get; set; }
    public string Email { get; set; }
    public string Status { get; set; }

    public ICollection<DbWork> Works { get; set; } = new List<DbWork>();

    public ICollection<DbLike> Likes { get; set; } = new List<DbLike>();
}

public class DbUserConfiguration : IEntityTypeConfiguration<DbUser>
{
    public void Configure(EntityTypeBuilder<DbUser> builder)
    {
        builder
            .ToTable(DbUser.TableName);

        builder
            .HasKey(u => u.Id);

        //builder
        //    .HasMany(u => u.Works) // идем от таблицы works где связь hasMany
        //    .WithOne(w => w.User) // приходим в withone в таблице user
        //    .HasForeignKey(u => u.UserId)
        //    .OnDelete(DeleteBehavior.NoAction);

        builder
          .HasMany(u => u.Likes)
          .WithOne(l => l.User)
          .OnDelete(DeleteBehavior.NoAction);
    }
}


