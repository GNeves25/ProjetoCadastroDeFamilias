using Newtonsoft.Json;

namespace ProjetoCadastroDeFamilias.Models
{
    public class LocalizacaoModel
    {
        [JsonProperty(PropertyName = "ip")]
        public string? Ip { get; set; }

        [JsonProperty(PropertyName = "country_code")]
        public string? CountryCode { get; set; }

        [JsonProperty(PropertyName = "country_name")]
        public string? CountryName { get; set; }

        [JsonProperty(PropertyName = "region_name")]
        public string? RegionName { get; set; }

        [JsonProperty(PropertyName = "city_name")]
        public string? CityName { get; set; }

        [JsonProperty(PropertyName = "latitude")]
        public double? Latitude { get; set; }

        [JsonProperty(PropertyName = "longitude")]
        public double? Longitude { get; set; }

        [JsonProperty(PropertyName = "zip_code")]
        public string? ZipCode { get; set; }

        [JsonProperty(PropertyName = "time_zone")]
        public string? TimeZone { get; set; }

        [JsonProperty(PropertyName = "asn")]
        public string? Asn { get; set; }

        [JsonProperty(PropertyName = "as")]
        public string? @As { get; set; }

        [JsonProperty(PropertyName = "is_proxy")]
        public bool? IsProxy { get; set; }
    }
}
