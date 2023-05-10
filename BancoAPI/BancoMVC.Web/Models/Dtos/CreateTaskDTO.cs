using System.Text.Json.Serialization;

namespace BancoMVC.Web.Models.Dtos
{
    public class CreateTaskDTO
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        public string Task { get; set; }
        public int Priority { get; set; }
    }
}
