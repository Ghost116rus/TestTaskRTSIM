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
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(e => e.Id);
            builder.HasIndex(e => e.Id);
            builder.Property(e => e.Name).HasMaxLength(150);

            builder
                .HasOne(u => u.Organization)
                .WithMany(o => o.Staff)
                .HasForeignKey(u => u.OrganizationId);
        }
    }
}
