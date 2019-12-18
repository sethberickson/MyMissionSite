using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyMissionSite.Models
{
    [Table("Users")]
    public class Users
    {
        [Key]
        [DisplayName("User ID")]
        public int User_ID { get; set; }

        [Required]
        [DataType(DataType.EmailAddress, ErrorMessage = "Please enter a valid email")]
        [DisplayName("Email Address")]
        public string User_Email { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 8, ErrorMessage = "Password must be at least 8 characters long")]
        [DisplayName("Password")]
        public string User_Password { get; set; }

        [Required]
        [DisplayName("First Name")]
        public string First_Name { get; set; }

        [Required]
        [DisplayName("Last Name")]
        public string Last_Name { get; set; }


    }
}