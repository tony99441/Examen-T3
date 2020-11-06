using ExamenT3.Models.Maps;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenT3.Models
{
    public class AppEjerciciosContext : DbContext
    {
        public DbSet<Usuario> usuarios { get; set; }
        public DbSet<Rutina> rutinas { get; set; }
        public DbSet<Ejercicios> ejercicios { get; set; }
        public DbSet<DetalleEjercicioRutina> detalleEjercicioRutinas { get; set; }
     

        public AppEjerciciosContext(DbContextOptions<AppEjerciciosContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new RutinaMap());
            modelBuilder.ApplyConfiguration(new EjercicioMap());
            modelBuilder.ApplyConfiguration(new DetalleEjercicioRutinaMap());
        }
    }
}