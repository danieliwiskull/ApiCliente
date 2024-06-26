using System.Text.Json.Serialization;

namespace WebApp.Models
{
    public class ClienteViewModel
    {
        [JsonPropertyName("Id")]
        public int Id { get; set; }

        [JsonPropertyName("Nombre")]
        public string Nombre { get; set; } = string.Empty;

        [JsonPropertyName("Apellido")]
        public string Apellido { get; set; } = string.Empty;
    }
}
