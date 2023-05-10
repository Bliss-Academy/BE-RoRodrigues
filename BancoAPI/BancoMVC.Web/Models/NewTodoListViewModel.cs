using BancoMVC.Web.Models.Shared;

namespace BancoMVC.Web.Models
{
    public record NewTodoListViewModel
    {
        public TodoListViewModel TodoList { get; set; } = new();
    }
}
