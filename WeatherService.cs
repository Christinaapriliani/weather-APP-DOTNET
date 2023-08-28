using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WeatherApp.Models;

namespace WeatherApp
{
    public class WeatherService
    {
        private const string ApiKey = "YOUR_OPENWEATHERMAP_API_KEY"; // Ganti dengan API key yang valid

        public async Task<WeatherData> GetWeatherAsync(string city)
        {
            using (HttpClient client = new HttpClient())
            {
                string apiUrl = $"http://api.openweathermap.org/data/2.5/weather?q={city}&units=metric&appid={ApiKey}";
                HttpResponseMessage response = await client.GetAsync(apiUrl);
                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    WeatherData weatherData = JsonConvert.DeserializeObject<WeatherData>(json);
                    return weatherData;
                }
                else
                {
                    throw new Exception("Failed to fetch weather data");
                }
            }
        }
    }
}
