using DirectoryService.Domain.Departments;
using DirectoryService.Domain.Departments.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DirectoryService.Infrastructure.Postgres.Configuration;

public class DeportmentConfiguration : IEntityTypeConfiguration<Department>
{
    public void Configure(EntityTypeBuilder<Department> builder)
    {
        builder.ToTable("deportment");
        
        builder.HasKey(d => d.Id).HasName("pk_deportment");

        builder.Property(d => d.Id)
            .HasConversion(did => did.Value, guid => DepartmentId.New(guid))
            .HasColumnName("id");

        builder.Property(d => d.Name)
            .HasConversion(dn => dn.Value, s => DepartmentName.Create(s).Value)
            .HasColumnName("name")
            .HasMaxLength(DepartmentName.MAX_LENGTH)
            .IsRequired();
        
        builder.Property(d => d.Indefier)
            .HasConversion(di => di.Value, s => DepartmentIndefier.Create(s).Value)
            .HasColumnName("indefier")
            .HasMaxLength(DepartmentIndefier.MAX_LENGTH)
            .IsRequired();

        builder.Property(d => d.ParentId)
            .HasConversion(dpid => dpid!.Value, s => DepartmentId.New(s))
            .HasColumnName("parent_id")
            .IsRequired(false);
        
        builder.Property(d => d.Path)
            .HasConversion(dp => dp.Value, s => DepartmentPath.Create(s, null).Value)
            .HasColumnName("path")
            .HasMaxLength(DepartmentPath.MAX_LENGTH)
            .IsRequired();

        builder.Property(d => d.Depth)
            .HasColumnName("depth")
            .IsRequired(false);

        builder.Property(d => d.IsActive)
            .HasColumnName("is_active")
            .HasDefaultValue(true)
            .IsRequired();

        builder.Property(d => d.CreatedAt)
            .HasColumnName("created_at")
            .HasDefaultValueSql("timezone('utc', now())")
            .IsRequired();
        
        builder.Property(d => d.UpdatedAt)
            .HasColumnName("updated_at")
            .HasDefaultValueSql("timezone('utc', now())")
            .IsRequired();
    }
}