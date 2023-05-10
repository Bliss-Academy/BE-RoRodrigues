using BancoMVC.Web.Models;
using BancoMVC.Web.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace BancoMVC.Web.Controllers
{
    public class TodoListController : Controller
    {
        private readonly HttpClient _httpClient;
        public TodoListController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public IActionResult Index()
        {
            var response = _httpClient.GetAsync("https://localhost:7072/api/todolist/getListsWithTasks?listId=6").Result;
            var content = response.Content.ReadAsStringAsync().Result;
            var listTask = JsonSerializer.Deserialize<ViewTodoListViewModel>(content);
            return View("View",listTask);
        }

        public IActionResult deleteTask(int id)
        {
           _httpClient.DeleteAsync($"https://localhost:7072/api/todolist/task/delete?taskid={id}");
            return Index();
        }

        public IActionResult createTask(CreateTaskDTO model)
        {
            _httpClient.PostAsJsonAsync<CreateTaskDTO>("https://localhost:7072/api/todolist/createTask?todolistid=6", model);
            return  Index();
        }
    }
}
