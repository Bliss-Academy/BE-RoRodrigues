using BancoAPI.Data.Models.Shared;
using System.Drawing;
using System.Text.Json.Serialization;

namespace BancoMVC.Web.Models
{
    public record ViewTodoListViewModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("description")]
        public string Description { get; set; }
        [JsonPropertyName("color")]
        public int ColorCssClasses { get; set; }
        [JsonPropertyName("tasks")]
        public List<TaskInfo> Tasks { get; set; }
    }

    public class TaskInfo
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("description")]
        public string Description { get; set; }
        [JsonPropertyName("priority")]
        public int Priority { get; set; }
        [JsonPropertyName("isComplete")]
        public bool IsComplete { get; set; }
    }
}
