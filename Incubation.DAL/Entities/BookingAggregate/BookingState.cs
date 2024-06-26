﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Incubation.DAL.Entities.BookingAggregate
{
    public enum BookingState
    {
        [EnumMember(Value = "Pending")]
        Pending,
        [EnumMember(Value = "Payment Received")]

        PaymentReceived,
        [EnumMember(Value = "Payment Fieled")]

        PaymentFieled,
    }
}
