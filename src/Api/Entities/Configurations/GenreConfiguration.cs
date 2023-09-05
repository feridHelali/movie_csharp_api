using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Entities.Configurations
{
    public class GenreConfiguration : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.HasKey(g => g.Identifier);
            builder.Property(g => g.Name).HasMaxLength(150);
            var futureFantasy = new Genre { Identifier = 8, Name = "Future Fantasy" };
            var blackIrony = new Genre { Identifier = 9, Name = "Black Irony" };
            builder.HasData(futureFantasy, blackIrony);
        }
    }
}