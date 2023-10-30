using System.Text.Json.Serialization;

namespace WebAPI.Models
{
    public class House
    {
        public int Id { get; set; }
        public string Address { get; set; } = "";
        [JsonIgnore]
        public virtual List<Cat> Cats { get; set; } = new List<Cat>();
    }
}
