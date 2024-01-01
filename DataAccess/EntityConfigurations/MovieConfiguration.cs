using Entity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityConfigurations;

public class MovieConfiguration : IEntityTypeConfiguration<Movie>
{
    public void Configure(EntityTypeBuilder<Movie> builder)
    {
        builder.ToTable("Movies").HasKey(movie => movie.Id);

        builder.Property(movie => movie.Id).HasColumnName("id").IsRequired();
        builder.Property(movie => movie.Name).HasColumnName("name").IsRequired();
        builder.Property(movie => movie.Type).HasColumnName("type").IsRequired();
        builder.Property(movie => movie.YearOfPublication).HasColumnName("year_of_publication").IsRequired();
        builder.Property(movie => movie.Duration).HasColumnName("duration").IsRequired();
        builder.Property(movie => movie.ImdbScore).HasColumnName("imdb_score").IsRequired();
        builder.Property(movie => movie.DirectorId).HasColumnName("director_id").IsRequired();

        builder.Property(movie => movie.CreatedDate).HasColumnName("created_date");
        builder.Property(movie => movie.UpdatedDate).HasColumnName("updated_date");
        builder.Property(movie => movie.DeletedDate).HasColumnName("deleted_date");

        builder.HasIndex(indexExpression: movie => movie.Name, name: "UK_Movies_Name").IsUnique();

        builder.HasOne(movie => movie.Director);

        builder.HasQueryFilter(movie => !movie.DeletedDate.HasValue);
    }
}