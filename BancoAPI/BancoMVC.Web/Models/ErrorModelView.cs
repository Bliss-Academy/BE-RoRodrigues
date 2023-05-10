namespace BancoMVC.Web.Models
{
    public record ErrorModelView
    {
        public string? RequestId { get; set; }
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
