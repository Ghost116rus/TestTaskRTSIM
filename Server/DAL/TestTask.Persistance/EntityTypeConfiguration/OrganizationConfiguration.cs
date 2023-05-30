using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Domain;

namespace TestTask.Persistance.EntityTypeConfiguration
{
    public class OrganizationConfiguration : IEntityTypeConfiguration<Organization>
    {
        public void Configure(EntityTypeBuilder<Organization> builder)
        {
            builder.HasKey(e => e.Id);
            builder.HasIndex(e => e.Id);

            builder.Property(e => e.Name).HasMaxLength(150);
        }
    }
}
