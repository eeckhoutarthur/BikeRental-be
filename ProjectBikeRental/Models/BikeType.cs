
using System.Runtime.Serialization;
using System.Text.Json.Serialization;


namespace ProjectBikeRental.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum BikeType
    {
        Road_Bike,
        E_Bike,
        Mountain_Bike,
        Urban_Bike
    }
}
