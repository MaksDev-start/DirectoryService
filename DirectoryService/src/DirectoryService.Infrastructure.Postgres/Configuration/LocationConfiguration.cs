using DirectoryService.Domain.Constants;
using DirectoryService.Domain.Locations;
using DirectoryService.Domain.Locations.ValueObjets;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TimeZone = DirectoryService.Domain.Locations.ValueObjets.TimeZone;

namespace DirectoryService.Infrastructure.Postgres.Configuration;

public class LocationConfiguration : IEntityTypeConfiguration<Location>
{
    public void Configure(EntityTypeBuilder<Location> builder)
    {
        builder.ToTable("locations");

        builder.HasKey(d => d.Id).HasName("pk_location");

        builder.Property(d => d.Id)
            .HasConversion(lid => lid.Value, guid => LocationID.New(guid))
            .HasColumnName("location_id");

        builder.OwnsOne(d => d.Name, b =>
        {
            b.Property(n => n.Value)
                .HasColumnName("name")
                .HasMaxLength(LengthConstants.MAXLENGTH120);

            b.HasIndex(n => n.Value).IsUnique().HasDatabaseName(Indexes.LOCATION_NAME);
        });

        builder.ComplexProperty(l => l.Adress, la =>
        {
            la.Property(a => a.Country)
                .HasColumnName("country")
                .HasMaxLength(LengthConstants.MAXLENGTH50)
                .IsRequired();
            
            la.Property(a => a.City)
                .HasColumnName("city")
                .HasMaxLength(LengthConstants.MAXLENGTH50)
                .IsRequired();
            
            la.Property(a => a.Street)
                .HasColumnName("street")
                .HasMaxLength(LengthConstants.MAXLENGTH50)
                .IsRequired();

            la.Property(a => a.HouseNumber)
                .HasColumnName("house_number")
                .HasColumnType("integer")
                .IsRequired(false);
        });

        builder.Property(l => l.TimeZone)
            .HasConversion(ltz => ltz.Value, s => TimeZone.Create(s).Value)
            .HasColumnName("time_zone")
            .HasMaxLength(LengthConstants.MAXLENGTH50)
            .IsRequired();
        
        builder.Property(l => l.IsActive)
            .HasColumnName("is_active")
            .HasDefaultValue(true)
            .IsRequired();
        
        builder.Property(l => l.CreatedAt)
            .HasColumnName("created_at")
            .HasDefaultValueSql("timezone('utc', now())")
            .IsRequired();
        
        builder.Property(l => l.UpdatedAt)
            .HasColumnName("updated_at")
            .HasDefaultValueSql("timezone('utc', now())")
            .IsRequired();
    }
}