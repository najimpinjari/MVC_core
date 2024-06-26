﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using DBFA_CRUD.Models.Entities;

namespace DBFA_CRUD.Models
{
    public partial class CSstudentDBFContext : DbContext
    {
        public CSstudentDBFContext()
        {
        }

        public CSstudentDBFContext(DbContextOptions<CSstudentDBFContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CSstudent> CSstudents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CSstudent>(entity =>
            {
                entity.Property(e => e.City)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}