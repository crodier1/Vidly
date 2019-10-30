using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please Enter customer's Name.")]
        [StringLength(255)]
        public string Name { get; set; }

        [Display(Name = "Date of Birth")]
        [Min18YearsIfAMember]
        public DateTime? DateOfBirth { get; set; }
        public bool IsSubScribedToNewsLetter { get; set; }
        [Display(Name = "Membership Type")]
        public int MembershipTypeId { get; set; }
        public MembershipType MembershipType { get; set; }


    }
}