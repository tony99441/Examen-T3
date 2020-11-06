using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenT3.Models.Maps
{
    public class RutinaMap : IEntityTypeConfiguration<Rutina>
    {
        public void Configure(EntityTypeBuilder<Rutina> builder)
    {
        builder.ToTable("Rutina");
        builder.HasKey(o => o.Id);

        builder.HasOne(o => o.usuario).WithMany(o => o.rutinas).HasForeignKey(o => o.IdUsuario);
       
        builder.HasMany(o => o.detalleEjercicioRutina).WithOne(o => o.rutina).HasForeignKey(o => o.IdRutina);
    }

     
    }
}
