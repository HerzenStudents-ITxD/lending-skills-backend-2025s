
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lending_skills_backend.Models;

public class DbForm
{
    public const string TableName = "Forms";
    public Guid Id { get; set; }

    public string Data { get; set; }
    public string Date { get; set; }

    public Guid BlockId { get; set; }
    public DbBlock Block { get; set; }


    //public ICollection<DbBlock> Blocks { get; set; } = new List<DbBlock>();

}

public class DbFormsConfiguration : IEntityTypeConfiguration<DbForm>
{
    public void Configure(EntityTypeBuilder<DbForm> builder)
    {
        builder
            .ToTable(DbForm.TableName);

        builder
            .HasKey(f => f.Id);


        builder
          .HasOne(f => f.Block)
          .WithOne(b => b.Form)
          .HasForeignKey<DbForm>(f => f.BlockId)
          .OnDelete(DeleteBehavior.NoAction);
    }
}