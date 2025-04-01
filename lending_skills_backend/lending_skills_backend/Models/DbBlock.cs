using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lending_skills_backend.Models;

public class DbBlock
{
    public const string TableName = "Blocks";
    public Guid Id { get; set; }

    public string Date { get; set; }
    public string IsExample { get; set; }
    public int Type { get; set; }

    public Guid? NextBlockId { get; set; }
    public Guid? PreviousBlockId { get; set; }

    public DbForm Form { get; set; }

    public Guid? PageId { get; set; }
    public DbPage Page { get; set;  }


    //public ICollection<DbForm> Forms { get; set; } = new List<DbForm>();
}


public class DbBlocksConfiguration : IEntityTypeConfiguration<DbBlock>
{
    public void Configure(EntityTypeBuilder<DbBlock> builder)
    {
        builder
            .ToTable(DbBlock.TableName);

        builder
            .HasKey(b => b.Id);

        builder.HasOne(b => b.Page)
            .WithMany(p => p.Blocks);


        builder.HasOne(b => b.Form)
            .WithOne(p => p.Block)
            .HasForeignKey<DbForm>(f => f.BlockId)
            .OnDelete(DeleteBehavior.NoAction);

    }

}
