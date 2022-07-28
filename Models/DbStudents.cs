using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVC_CODEFIRST.Models
{
    public class DbStudents:DbContext
    {
        public DbStudents():base("Data Source=DESKTOP-VU2QNK7\\SQLEXPRESS;Initial Catalog=University;Integrated Security=True;Pooling=False") { }
        public DbSet<Students> students { get; set; }
    }
}