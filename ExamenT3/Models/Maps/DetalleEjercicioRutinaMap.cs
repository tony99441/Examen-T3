using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenT3.Models.Maps
{
    public class DetalleEjercicioRutinaMap : IEntityTypeConfiguration<DetalleEjercicioRutina>
    {
        public void Configure(EntityTypeBuilder<DetalleEjercicioRutina> builder)
        {
            builder.ToTable("DetalleEjercicioRutina");
            builder.HasKey(o => o.Id);

            builder.HasOne(o => o.rutina).WithMany(o => o.detalleEjercicioRutina).HasForeignKey(o => o.IdRutina);

            builder.HasOne(o => o.ejercicio).WithMany(o => o.detalleEjercicioRutinas).HasForeignKey(o => o.IdEjercicio);
        }


    }
}
