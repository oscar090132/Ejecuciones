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
            modelBuilder.Entity<Departamento>().Property(k => k.DepartamentoId).UseIdentityAlwaysColumn();
            modelBuilder.Entity<Municipio>().Property(k => k.MunicipioId).UseIdentityAlwaysColumn();
            modelBuilder.Entity<Despacho>().Property(k => k.DespachoId).UseIdentityAlwaysColumn();
            modelBuilder.Entity<TipoSolicitud>().Property(k => k.TipoSolicitudId).UseIdentityAlwaysColumn();
            modelBuilder.Entity<Fallador>().Property(k => k.FalladorId).UseIdentityAlwaysColumn();
            modelBuilder.Entity<EstadoSolicitud>().Property(k => k.EstadoSolicitudId).UseIdentityAlwaysColumn();
            modelBuilder.Entity<EstadoProceso>().Property(k => k.EstadoProcesoId).UseIdentityAlwaysColumn();
            modelBuilder.Entity<Funcionario>().Property(k => k.FuncionarioId).UseIdentityAlwaysColumn();
            modelBuilder.Entity<Solicitud>().Property(k => k.SolicitudId).UseIdentityAlwaysColumn();
            modelBuilder.Entity<Proceso>().Property(k => k.ProcesoId).UseIdentityAlwaysColumn();
            modelBuilder.Entity<CargoEmpleado>().Property(k => k.CargoId).UseIdentityAlwaysColumn();

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Municipio> Municipios { get; set; }
    }
}
