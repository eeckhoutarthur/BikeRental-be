using System.Runtime.Serialization;
using System.Text.Json.Serialization;


namespace ProjectBikeRental.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Groupset
    {
        Shimano,
        Sram
    }
}
