using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using BancoAPI.Data.Entitites;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Drawing;
using Microsoft.EntityFrameworkCore;

namespace BancoAPI.Data.Entities
{
    public class AccountEntity : EntityBase
    {
        public string userId { get; set; }
        public string username { get; set; }
        public decimal income { get; set; }
        public decimal expense { get; set; }
    }

    public class AccountConfiguration : EntityBaseConfiguration<AccountEntity>
    {
        public override void Configure(EntityTypeBuilder<AccountEntity> builder)
        {
            base.Configure(builder);

            builder.ToTable("Accounts");

            builder.Property(x => x.username)
                .HasMaxLength(70)
                .IsRequired();
        }
    }
}
