using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieRents.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieRents.DataAccess.Configurations
{
    public class ReviewConfiguration : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder.Property(x => x.Content).IsRequired();
            builder.Property(x => x.Title).IsRequired();

            builder.HasOne(x => x.Movie)
                .WithMany(x => x.Reviews)
                .HasForeignKey(x => x.MovieId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
