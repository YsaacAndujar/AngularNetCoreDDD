using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Config
{
    public class CarConfig : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.ToTable("Cars");
            builder.HasKey(c => c.id);
            //builder
            //    .HasOne(c => c.carModel)
            //    .WithMany(cm => cm.Cars)
            //    //.HasForeignKey(c => c.carModelId)
            //    .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
