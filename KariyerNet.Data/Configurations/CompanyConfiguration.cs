using KariyerNet.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace KariyerNet.Data.Configurations
{
    class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.HasKey(x => x.CompanyId);
            builder.Property(x => x.CompanyId).UseIdentityColumn();

            builder.Property(x => x.PhoneNumber).IsRequired().HasMaxLength(12);
            builder.Property(x => x.MaxJobAdvertisementCount).IsRequired();
            builder.Property(x => x.CompanyAddress).IsRequired();
            builder.Property(x => x.CompanyName).IsRequired();
        }
    }
}
