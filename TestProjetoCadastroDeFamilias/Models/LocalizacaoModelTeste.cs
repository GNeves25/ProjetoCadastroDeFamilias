using ProjetoCadastroDeFamilias.Models;

namespace TestProjetoCadastroDeFamilias.Models
{
    public class LocalizacaoModelTeste
    {
        [Fact]
        public void TesteLocalizacao()
        {
            LocalizacaoModel localizacao = CriarLocalizacao();

            Assert.Equal("8.8.8.8", localizacao.Ip);
            Assert.Equal("US", localizacao.CountryCode);
            Assert.Equal("United States of America", localizacao.CountryName);
            Assert.Equal("California", localizacao.RegionName);
            Assert.Equal("Mountain View", localizacao.CityName);
            Assert.Equal(37.405992, localizacao.Latitude);
            Assert.Equal(-122.078515, localizacao.Longitude);
            Assert.Equal("94043", localizacao.ZipCode);
            Assert.Equal("-07 = 00", localizacao.TimeZone);
            Assert.Equal("15169", localizacao.Asn);
            Assert.Equal("Google LLC", localizacao.@As);
            Assert.Equal(false, localizacao.IsProxy);

        }

        private static LocalizacaoModel CriarLocalizacao()
        {
            return new LocalizacaoModel
            {
                Ip = "8.8.8.8",
                CountryCode = "US",
                CountryName = "United States of America",
                RegionName = "California",
                CityName = "Mountain View",
                Latitude = 37.405992,
                Longitude = -122.078515,
                ZipCode = "94043",
                TimeZone = "-07 = 00",
                Asn = "15169",
                @As = "Google LLC",
                IsProxy = false
            };
        }
    }
}
