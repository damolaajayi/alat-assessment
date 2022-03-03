using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Configuration
{
    public class OnboardConfiguration : IEntityTypeConfiguration<Onboard>
    {

        public void Configure(EntityTypeBuilder<Onboard> builder)
        {
            builder.HasData
            (
                new Onboard
                {

                    Id = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
                    PhoneNumber = "07039121201",
                    Password = "damolaajayi",
                    Email = "damolaajayi@gmail.com",
                   
                }
            );
        }
    }
}
