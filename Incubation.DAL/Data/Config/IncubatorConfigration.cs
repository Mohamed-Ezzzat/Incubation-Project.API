 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Incubation.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Incubation.DAL.Data.Config
{
    public class IncubatorConfigration : IEntityTypeConfiguration<Incubator>
    {
        public void Configure(EntityTypeBuilder<Incubator> builder)
        {
            builder.Property(P => P.Id).IsRequired();
            builder.Property(P=>P.City).IsRequired().HasMaxLength(50);
            //builder.Property(P => P.Name).IsRequired().HasMaxLength(100);
            //builder.Property(P => P.Location).IsRequired();
            //builder.HasMany(P => P.Doctors);
            //builder.HasMany(P => P.beds);



        }
    }
}
