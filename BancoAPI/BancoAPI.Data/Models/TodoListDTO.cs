using BancoAPI.Data.Models.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;

namespace BancoAPI.Data.Models
{
    public class TodoListDTO : EntityBaseDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ColorDTO Color { get; set; }
        public ICollection<TodoListTaskDTO> Tasks { get; set; }
    }

    public class TodoListDTOConfiguration : EntityBaseDTOConfiguration<TodoListDTO>
    {
        public override void Configure(EntityTypeBuilder<TodoListDTO> builder)
        {
            base.Configure(builder);

            builder.ToTable("TodoListDTO");

            builder.Property(x => x.Name)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.Description)
                .HasMaxLength(250);

            builder.Property(x => x.Color)
                .HasDefaultValue(ColorDTO.DarkBlue)
                .IsRequired();
        }
    }
}
