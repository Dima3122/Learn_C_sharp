using System;
using System.Data.Entity;

namespace WorkInBD
{
    class MyDbContecst : DbContext
    {
        public MyDbContecst() : base("DbConnectString")
        {

        }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Song> Songs { get; set; }
    }
}
