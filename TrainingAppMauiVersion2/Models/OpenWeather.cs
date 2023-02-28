using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Threading.Tasks;

namespace TrainingAppMauiVersion2.Models
{
    internal class OpenWeather
    {
        [JsonPropertyName("coord")]
        public Coord Coordinates { get; set; }

        [JsonPropertyName("weather")]
        public Weather[] Weather { get; set; }

        [JsonPropertyName("_base")]
        public string Base { get; set; }

        [JsonPropertyName("main")]
        public Main Main { get; set; }

        [JsonPropertyName("visibility")]
        public int Visibility { get; set; }

        [JsonPropertyName("wind")]
        public Wind Wind { get; set; }

        [JsonPropertyName("rain")]
        public Rain Rain { get; set; }

        [JsonPropertyName("clouds")]
        public Clouds Clouds { get; set; }

        [JsonPropertyName("dt")]
        public int Dt { get; set; }

        [JsonPropertyName("sys")]
        public Sys Sys { get; set; }

        [JsonPropertyName("timezone")]
        public int Timezone { get; set; }

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("cod")]
        public int Cod { get; set; }


        private static async Task<OpenWeather> GetOpenWeather(string city)
        {

            string apiKey = "aaa3c5f1fb092617638c1dcf8266f07b";

            string url = $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={apiKey}&units=metric";
            OpenWeather weatherData = null;
            var client = new HttpClient();
            HttpResponseMessage response1 = await client.GetAsync(url);
            if (response1.IsSuccessStatusCode)
            {
                string apiResponse = await response1.Content.ReadAsStringAsync();
                weatherData = JsonSerializer.Deserialize<OpenWeather>(apiResponse);

            }
            return weatherData;
        }
        public static async Task<OpenWeather> GetOpenWeatherInACity(string city)
        {
            Task<OpenWeather> w = GetOpenWeather(city);

            if ((await w) is not null)
            {
                return await w;
                //Console.WriteLine($"Current weather in {(await w).name}: {(await w).wind.speed}, {(await w).main.temp}°C, {(await w).weather[0].description}, feels like {(await w).main.feels_like}");
            }
            else
            {
                Console.WriteLine("City does not exists in this context");
                //w = null;
                return null;
            }
        }

        public static void CheckWeather(OpenWeather weather)
        {

            if (weather.Main.Temp > 25)
            {
                if (weather.Clouds.All > 50)
                {

                }

            }
        }
    }

    public class Coord
    {
        [JsonPropertyName("lon")]
        public float Longitude { get; set; }

        [JsonPropertyName("lat")]
        public float Latitude { get; set; }
    }

    public class Main
    {
        [JsonPropertyName("temp")]
        public float Temp { get; set; }

        [JsonPropertyName("feels_like")]
        public float FeelsLike { get; set; }

        [JsonPropertyName("temp_min")]
        public float TempMin { get; set; }

        [JsonPropertyName("temp_max")]
        public float TempMax { get; set; }

        [JsonPropertyName("pressure")]
        public int Pressure { get; set; }

        [JsonPropertyName("humidity")]
        public int Humidity { get; set; }

        [JsonPropertyName("sea_level")]
        public int SeaLevel { get; set; }

        [JsonPropertyName("grnd_level")]
        public int GrndLevel { get; set; }
    }

    public class Wind
    {
        [JsonPropertyName("speed")]
        public float Speed { get; set; }

        [JsonPropertyName("deg")]
        public int DirectionsAndDegrees { get; set; }

        [JsonPropertyName("gust")]
        public float Gust { get; set; }

    }

    public class Rain
    {
        [JsonPropertyName("_1h")]
        public float _1h { get; set; }
    }

    public class Clouds
    {
        [JsonPropertyName("all")]
        public int All { get; set; }
    }

    public class Sys
    {
        [JsonPropertyName("type")]
        public int Type { get; set; }

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("country")]
        public string Country { get; set; }

        [JsonPropertyName("sunrise")]
        public int Sunrise { get; set; }

        [JsonPropertyName("sunset")]
        public int Sunset { get; set; }
    }

    public class Weather
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("main")]
        public string Main { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("icon")]
        public string Icon { get; set; }
    }
}
