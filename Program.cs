using System;
using System.Threading.Tasks;
using WeatherApp.Models;

namespace WeatherApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.Write("Enter a city name: ");
            string city = Console.ReadLine();

            WeatherService weatherService = new WeatherService();
            try
            {
                WeatherData weatherData = await weatherService.GetWeatherAsync(city);
                Console.WriteLine($"Weather in {weatherData.City}:");
                Console.WriteLine($"Description: {weatherData.Description}");
                Console.WriteLine($"Temperature: {weatherData.Temperature}°C");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
