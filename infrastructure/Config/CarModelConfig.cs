using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Config
{
    public class CarModelConfig : IEntityTypeConfiguration<CarModel>
    {
        public void Configure(EntityTypeBuilder<CarModel> builder)
        {
            builder.ToTable("CarsModels");
            builder.HasKey(cm => cm.id);
            builder
                .HasOne(cm => cm.brand)
                .WithMany(b => b.carsModels)
                .HasForeignKey(cm => cm.brandId);
            builder.HasIndex(cm => new { cm.brandId, cm.name }).IsUnique();

        }
    }
}
