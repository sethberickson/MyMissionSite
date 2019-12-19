using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyMissionSite.Models
{
    [Table("Mission_Questions")]
    public class Mission_Questions
    {
        [Key]
        [DisplayName("Question ID")]
        public int Mission_Question_ID { get; set; }
        
        
        //foreign key Mission_ID
        [Required]
        [DisplayName("Mission ID")]
        public int Mission_ID { get; set; }
        
        /*
        [ForeignKey("Mission_ID")]
        public virtual Missions Missions { get; set; }
        */

        [Required]
        [DisplayName("User ID")]
        public int User_ID { get; set; }

        [Required]
        [DisplayName("Question")]
        public string Question { get; set; }
       
        [DisplayName("Answer")]
        public string Answer { get; set; }
    }
}