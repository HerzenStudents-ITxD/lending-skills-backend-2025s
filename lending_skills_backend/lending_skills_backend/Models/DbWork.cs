using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lending_skills_backend.Models;

public class DbWork
{
    public const string TableName = "Works";
    public Guid Id { get; set; }
    public string Date { get; set; }
    public string Name { get; set; }
    public string WorkDescription { get; set; }
    public string Sphere { get; set; }
    public string Status { get; set; }
    public string Photos { get; set; }
    public bool Favorite { get; set; }

    public Guid UserId { get; set; }
    public DbUser User { get; set; }

    public ICollection<DbLike> Likes { get; set; } = new List<DbLike>();
}


public class DbWorksConfiguration : IEntityTypeConfiguration<DbWork>
{
    public void Configure(EntityTypeBuilder<DbWork> builder)
    {
        builder.ToTable(DbWork.TableName);
        builder.HasKey(w => w.Id);


        builder.HasMany(w => w.Likes)
            .WithOne(l => l.Work)
            .HasForeignKey(l => l.WorkId)
            .OnDelete(DeleteBehavior.NoAction);

    }

}