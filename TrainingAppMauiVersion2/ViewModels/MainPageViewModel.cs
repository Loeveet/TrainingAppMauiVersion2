using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TrainingAppMauiVersion2.Models;

namespace TrainingAppMauiVersion2.ViewModels
{
    internal partial class MainPageViewModel : ObservableObject
    {
        [ObservableProperty]
        string userName;

        [ObservableProperty]
        string passWord;

        [ObservableProperty]
        OpenWeather oWeather;

        public MainPageViewModel()
        {
            OWeather = new OpenWeather();
        }
        public static async Task<List<Models.Person>> GetUsersFromMongoDB()
        {
            var settings = MongoClientSettings.FromConnectionString("mongodb+srv://RobinLiliegren:robin88@cluster0.cst2dyy.mongodb.net/?retryWrites=true&w=majority");
            settings.ServerApi = new ServerApi(ServerApiVersion.V1);
            var client = new MongoClient(settings);
            var database = client.GetDatabase("TrainingAppPerson");
            var myCollection = database.GetCollection<Models.Person>("MyUsers");

            var users = await GetAllUsers(myCollection);
            return users;

        }
        private static async Task<List<Models.Person>> GetAllUsers(IMongoCollection<Models.Person> myCollection)
        {
            var allUsers = await myCollection.AsQueryable().ToListAsync();
            return allUsers;
        }

        public async void GetAWeather()
        {
            var weather = await GetWeatherAsync("Nyköping");
            OWeather = weather;
        }

        [RelayCommand]
        public static async Task<OpenWeather> GetWeatherAsync(string city)
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

    }
}
