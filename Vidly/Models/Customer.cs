using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Name required!!")]

        [StringLength(255)]
        public string Name { get; set; }

        [Display(Name="Date of Birth")]       
        [MIn18YearsIfAMember]
        public DateTime? BrithDate { get; set; }

        public bool IsSubscribedToNewsLetter { get; set; }

        public MembershipType MembershipType { get; set; }

        [Display(Name = "Member Ship Type")]
        public Byte MembershipTypeId { get; set; }

      
    }
}