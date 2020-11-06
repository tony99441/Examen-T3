using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenT3.Models.Maps
{
    public class EjercicioMap : IEntityTypeConfiguration<Ejercicios>
    {
        public void Configure(EntityTypeBuilder<Ejercicios> builder)
        {
            builder.ToTable("Ejercicios");
            builder.HasKey(o => o.Id);

            builder.HasMany(o => o.detalleEjercicioRutinas).WithOne(o => o.ejercicio).HasForeignKey(o => o.IdEjercicio);

       
        }


    }
}
