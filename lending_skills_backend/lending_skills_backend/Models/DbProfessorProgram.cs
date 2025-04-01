using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace lending_skills_backend.Models;

public class DbProfessorProgram
{
    public const string TableName = "ProfessorsPrograms";

    public Guid Id { get; set; }

    public bool Favorite { get; set; }


    public Guid ProfessorId { get; set; }
    public DbProfessor Professor { get; set; }

    public Guid ProgramId { get; set; }
    public DbProgram Program { get; set; }
}    


public class DbProfessorProgramConfiguration : IEntityTypeConfiguration<DbProfessorProgram>
{
    public void Configure(EntityTypeBuilder<DbProfessorProgram> builder)
    {
        builder.ToTable(DbProfessorProgram.TableName);

        builder.HasKey(a => a.Id);

        builder.HasAlternateKey(pp => new { pp.ProfessorId, pp.ProgramId });

        builder
            .HasOne(pp => pp.Professor)
            .WithMany()
            .HasForeignKey(pp => pp.ProfessorId)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasOne(pp => pp.Program)
            .WithMany()
            .HasForeignKey(pp => pp.ProgramId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}


