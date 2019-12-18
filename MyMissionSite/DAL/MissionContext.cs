
using MyMissionSite.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MyMissionSite.DAL
{
    public class MissionContext : DbContext
    {
        public MissionContext()
            : base("MissionContext")
        {

        }

        //list different models here

        public DbSet<Missions> Missions { get; set; }
        public DbSet<Mission_Questions> Mission_Questions { get; set; }
        public DbSet<Users> Users { get; set; }


    }
}