using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class MembershipType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public byte DurationInMonths { get; set; }
        public int DiscountRate { get; set; }

        public static readonly int Unknown = 0;
        public static readonly int Monthly = 1;


    }
}