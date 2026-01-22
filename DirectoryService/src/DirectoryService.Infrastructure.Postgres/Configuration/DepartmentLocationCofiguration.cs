using DirectoryService.Domain.DepartmentLocations;
using DirectoryService.Domain.Departments.ValueObjects;
using DirectoryService.Domain.Locations.ValueObjets;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DirectoryService.Infrastructure.Postgres.Configuration;

public class DepartmentLocationCofiguration : IEntityTypeConfiguration<DepartmentLocation>
{
    public void Configure(EntityTypeBuilder<DepartmentLocation> builder)
    {
        builder.ToTable("department_locations");
        
        builder.HasKey(dl => new { dl.DepartmentId, dl.LocationId})
            .HasName("pk_department_locations");

        builder.Property(dl => dl.Id)
            .HasConversion(dlId => dlId.Value, guid => DepartmentLocationID.New(guid))
            .ValueGeneratedOnAdd()
            .HasColumnName("id");
        
        builder.Property(dl => dl.DepartmentId)
            .HasConversion(
                dId => dId.Value,                   
                guid => DepartmentId.New(guid))
            .HasColumnName("department_id")
            .IsRequired();
    
        builder.Property(dl => dl.LocationId)
            .HasConversion(
                lId => lId.Value,            
                guid => LocationID.New(guid))
            .HasColumnName("location_id")
            .IsRequired();
        
        builder
            .HasOne(dl => dl.Department)
            .WithMany(d => d.DepartmentLocation)
            .HasForeignKey(dl => dl.DepartmentId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
        
        builder
            .HasOne(dl => dl.Location)
            .WithMany(l => l.DepartmentLocation)
            .HasForeignKey(dl => dl.LocationId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
        
    }
}