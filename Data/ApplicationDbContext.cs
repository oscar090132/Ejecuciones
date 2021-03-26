using Ejecuciones.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ejecuciones.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Departamento>().HasKey(k => new { k.CodigoDepartamento});
            modelBuilder.Entity<Municipio>().HasKey(k => new { k.CodigoDepartamento, k.CodigoMunicipio });

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Municipio> Municipios { get; set; }
    }
}
