using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ManagementSystem.Models
{
    public class UserProfile

    {
        [Key]
        public int UserProfileId { get; set; }
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get;  set; }

        [StringLength(11)]
        public string number { get; set; }
    }
}