using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyMissionSite.Models
{
    [Table("Missions")]
    public class Missions
    {
        [Key]
        [DisplayName("Mission ID")]
        public int Mission_ID { get; set; }

        [Required]
        [DisplayName("Mission Name")]
        public string Mission_Name { get; set; }

        [Required]
        [DisplayName("Mission President")]
        public string Mission_President_Name { get; set; }

        [Required]
        [DisplayName("Mission Address")]
        public string Mission_Address { get; set; }

        [Required]
        [DisplayName("Dominant Language")]
        public string Mission_Language { get; set; }

        [Required]
        [DisplayName("Climate")]
        public string Mission_Climate { get; set; }

        [Required]
        [DisplayName("Dominant Religion")]
        public string Mission_Dominant_Religion { get; set; }

        [Required]
        [DisplayName("Mission Flag")]
        public string Mission_Flag { get; set; }
    }
}