using Entity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityConfigurations;

public class DirectorConfiguration : IEntityTypeConfiguration<Director>
{
    public void Configure(EntityTypeBuilder<Director> builder)
    {
        builder.ToTable("Directors").HasKey(b => b.Id);

        builder.Property(director => director.Id).HasColumnName("id").IsRequired();
        builder.Property(director => director.FirstName).HasColumnName("first_name").IsRequired();
        builder.Property(director => director.LastName).HasColumnName("last_name").IsRequired();
        builder.Property(director => director.PlaceOfBirth).HasColumnName("place_of_birth").IsRequired();
        builder.Property(director => director.Country).HasColumnName("country").IsRequired();

        builder.Property(director => director.CreatedDate).HasColumnName("created_date").IsRequired();
        builder.Property(director => director.UpdatedDate).HasColumnName("updated_date");
        builder.Property(director => director.DeletedDate).HasColumnName("deleted_date");

        builder.HasMany(director => director.Movies);

        builder.HasQueryFilter(director => !director.DeletedDate.HasValue);
    }
}