using DirectoryService.Domain.DepartmentPositions;
using DirectoryService.Domain.Departments.ValueObjects;
using DirectoryService.Domain.Positions.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DirectoryService.Infrastructure.Postgres.Configuration;

public class DepartmentPositinConfigurate : IEntityTypeConfiguration<DepartmentPosition>
{
    public void Configure(EntityTypeBuilder<DepartmentPosition> builder)
    {
        builder.ToTable("department_positions");
        
        builder.HasKey(dp => new { PositionID = dp.PositionId, dp.DepartmentId })
            .HasName("pk_department_position");
        
        builder.Property(dp => dp.Id)
            .HasConversion(dpId => dpId.Value, guid => DepartmentPositionId.New(guid))
            .ValueGeneratedOnAdd()
            .HasColumnName("id");
        
        builder.Property(dp => dp.DepartmentId)
            .HasConversion(
                dId => dId.Value,                   
                guid => DepartmentId.New(guid))
            .HasColumnName("department_id")
            .IsRequired();
        
        builder.Property(dp => dp.PositionId)
            .HasConversion(
                pId => pId.Value,
                guid => PositionId.New(guid))
            .HasColumnName("position_id")
            .IsRequired();

        builder
            .HasOne(dp => dp.Department)
            .WithMany(d => d.DepartmentPosition)
            .HasForeignKey(dp => dp.DepartmentId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
        
        builder
            .HasOne(dp => dp.Position)
            .WithMany(d => d.DepartmentPositions)
            .HasForeignKey(dp => dp.PositionId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
    }
}