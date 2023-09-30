using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Incubation.DAL.Entities.BookingAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Incubation.DAL.Data.Config
{
    public class BookingConfigration : IEntityTypeConfiguration<Booking>
    {
        public void Configure(EntityTypeBuilder<Booking> builder)
        {
            //builder.OwnsOne(B => B.BookingData, childdate => childdate.WithOwner());
            builder.Property(B => B.bookingState)
                .HasConversion(
                Ibookingstates => Ibookingstates.ToString(),
                Ibookingstates => (BookingState)Enum.Parse(typeof(BookingState), Ibookingstates));


            builder.Property(p => p.UserDateId).HasDefaultValue(2);

            //builder.Property(P => P.ChildData).HasDefaultValue(null);
            //builder.Property(P => P.BedData).HasDefaultValue(null);
        }
    }
}
