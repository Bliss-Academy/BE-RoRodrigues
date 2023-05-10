namespace BancoMVC.Web.Models
{
    public record ListTodoListViewModel
    {
        public List<TodoListInfo> TodoLists { get; set; } = new List<TodoListInfo>();
    }

    public class TodoListInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int TaskCount { get; set; }
        public string ColorCssClasses { get; set; }
    }
}
