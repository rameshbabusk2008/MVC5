using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name required!!")]
        [StringLength(255)]
        public string Name { get; set; }       
        //[MIn18YearsIfAMember]
        public DateTime? BrithDate { get; set; }
        public bool IsSubscribedToNewsLetter { get; set; } 
        public Byte MembershipTypeId { get; set; }

        public MemberShipTypeDto MembershipType { get; set; }

    }
} 