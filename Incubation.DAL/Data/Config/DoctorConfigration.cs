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
    internal class DoctorConfigration : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder.Property(P => P.Id).IsRequired();
            builder.Property(P => P.Name).IsRequired().HasMaxLength(100);
            builder.Property(P=> P.Specialization).IsRequired().HasMaxLength(300);
            builder.Property(P => P.PhoneNumber).IsRequired();
            //builder.HasMany(P => P.incubators);

        }
    }
}
