﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RWEDO.DataTransferObject
{
    public class RWEDODbContext : DbContext
    {
        public RWEDODbContext(DbContextOptions<RWEDODbContext> options)
            : base(options)
        { }
        public DbSet<SurveyFile> SurveyFiles { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            foreach (var foreignKey in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetForeignKeys()))
            {
                foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }
    }
}
