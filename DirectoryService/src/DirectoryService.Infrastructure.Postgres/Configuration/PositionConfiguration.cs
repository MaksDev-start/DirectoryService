using DirectoryService.Domain.Constants;
using DirectoryService.Domain.Positions;
using DirectoryService.Domain.Positions.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DirectoryService.Infrastructure.Postgres.Configuration;

public class PositionConfiguration : IEntityTypeConfiguration<Position>
{
    public void Configure(EntityTypeBuilder<Position> builder)
    {
        builder.ToTable("positions");
        
        builder.HasKey(p => p.Id).HasName("pk_position");

        builder.Property(p => p.Id)
            .HasConversion(pid => pid.Value, guid => PositionId.New(guid))
            .HasColumnName("id");

        builder.OwnsOne(p => p.Name, b =>
        {
            b.Property(n => n.Value)
                .HasColumnName("name")
                .HasMaxLength(LengthConstants.MAXLENGTH100);
            
            b.HasIndex(n => n.Value).IsUnique().HasDatabaseName(Indexes.POSITION_NAME);
        });

        builder.Property(p => p.Description)
            .HasConversion(pd => pd!.Value, s => Description.Create(s).Value)
            .HasColumnName("description")
            .HasMaxLength(LengthConstants.MAXLENGTH1000)
            .IsRequired(false);

        builder.Property(p => p.IsActive)
            .HasColumnName("is_active")
            .HasDefaultValue(true)
            .IsRequired();
        
        builder.Property(p => p.CreatedAt)
            .HasColumnName("created_at")
            .HasDefaultValueSql("timezone('utc', now())")
            .IsRequired();
        
        builder.Property(p => p.UpdatedAt)
            .HasColumnName("updated_at")
            .HasDefaultValueSql("timezone('utc', now())")
            .IsRequired();
    }
}