using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using BancoAPI.Data.Models.Shared;

namespace BancoMVC.Web.Models.Shared
{
    public class TodoListViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Name", Prompt = "Todo list name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide a name for the todo list")]
        public string Name { get; set; }
        [Display(Name = "Description", Prompt = "Todo list description")]
        public string Description { get; set; }
        public int SelectedColor { get; set; }
        public List<TodoListColor> AvailableColors { get; set; }

        public TodoListViewModel()
        {
            AvailableColors = Enum.GetValues<ColorDTO>().Select(c => new TodoListColor(c)).ToList();
        }

        public record TodoListColor
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string CssClassName { get; set; }

            public TodoListColor(ColorDTO color)
            {
                Id = (int)color;
                Name = color.ToString();
                CssClassName = color switch
                {
                    ColorDTO.DarkBlue => "btn-outline-primary",
                    ColorDTO.DarkGray => "btn-outline-secondary",
                    ColorDTO.Green => "btn-outline-success",
                    ColorDTO.Red => "btn-outline-danger",
                    ColorDTO.Yellow => "btn-outline-warning",
                    ColorDTO.LightBlue => "btn-outline-info",
                    ColorDTO.Black => "btn-outline-dark",
                    ColorDTO.White => "btn-outline-white",
                    _ => "btn-outline-primary"
                };
            }
        }
    }
}
