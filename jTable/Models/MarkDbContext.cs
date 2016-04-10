using jTable.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace jTableMVC.Models
{
    public class MarkDbContext:DbContext
    {
        public MarkDbContext()
            : base("name=DbConnectionString")
        { }

     public DbSet<Mark> Marks { get; set; }

    }
}