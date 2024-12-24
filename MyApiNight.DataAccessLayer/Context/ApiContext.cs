﻿using Microsoft.EntityFrameworkCore;
using MyApiNight.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApiNight.DataAccessLayer.Context
{
    public class ApiContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=ONURHCS\\SQLEXPRESS;initial Catalog=ApiBook;integrated Security=true");
        }
        public DbSet<Category> Categories{ get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<Writer> Writers { get; set; }
        public DbSet<Article> Articles { get; set; }

    }
}
