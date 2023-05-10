using BancoMVC.Web.Models.Shared;

namespace BancoMVC.Web.Models
{
    public record EditTodoListViewModel
    {
        public TodoListViewModel TodoList { get; set; } = new();
    }
}