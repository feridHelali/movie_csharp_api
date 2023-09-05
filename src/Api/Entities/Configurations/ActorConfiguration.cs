using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Entities.Configurations
{
    public class ActorConfiguration : IEntityTypeConfiguration<Actor>
    {
        public void Configure(EntityTypeBuilder<Actor> builder)
        {
            builder.Property(a => a.Name).HasMaxLength(150);
            builder.Property(a => a.DateOfBirth).HasColumnType("date");
            builder.Property(a => a.Fortune).HasPrecision(18, 3);
        }
    }
}