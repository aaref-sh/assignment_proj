using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.Entity;

namespace assignment_proj.Models
{
    public class DB : DbContext
    {
        public DB() : base("DefaultConnection")
        {

        }
        public DbSet<Category> Categories { get; set; }
    }
}