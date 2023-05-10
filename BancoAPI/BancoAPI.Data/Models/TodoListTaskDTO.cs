using BancoAPI.Data.Entitites;
using BancoAPI.Data.Models.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoAPI.Data.Models
{
    public class TodoListTaskDTO : EntityBaseDTO
    {
        public string Description { get; set; }
        public PriorityDTO Priority { get; set; }
        public bool IsComplete { get; set; }
        public int TodoListId { get; set; }
        public TodoListDTO TodoList { get; set; }
    }

    public class TodoListTaskDTOConfiguration : EntityBaseDTOConfiguration<TodoListTaskDTO>
    {
        public override void Configure(EntityTypeBuilder<TodoListTaskDTO> builder)
        {
            base.Configure(builder);

            builder.ToTable("TodoListTask");

            builder.Property(x => x.Description)
                .HasMaxLength(500)
                .IsRequired();

            builder.Property(x => x.Priority)
                .HasDefaultValue(PriorityDTO.Normal)
                .IsRequired();

            builder.Property(x => x.IsComplete)
                .HasDefaultValue(false)
                .IsRequired();

            builder.HasOne(x => x.TodoList)
                .WithMany(x => x.Tasks)
                .HasForeignKey(x => x.TodoListId);
        }
    }
}