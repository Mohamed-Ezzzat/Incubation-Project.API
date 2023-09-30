using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Incubation.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Incubation.DAL.Data.Config
{
    internal class BedConfigration : IEntityTypeConfiguration<Bed>
    {
        public void Configure(EntityTypeBuilder<Bed> builder)
        {
            builder.Property(P => P.Id).IsRequired();
            builder.Property(P => P.TypeofBed).IsRequired().HasMaxLength(100);
            builder.Property(P => P.Condition).IsRequired();


            //builder.HasOne(P=>P.ChildData).WithOne(P=>P.Bed).HasForeignKey
            //builder.HasMany(P => P.incubators);
        //    modelBuilder.Entity<Person>()
        //.HasOne(p => p.Address)
        //    .WithOne(a => a.Person)
        //.HasForeignKey<Address>(a => a.PersonId);


        }
    }
}
