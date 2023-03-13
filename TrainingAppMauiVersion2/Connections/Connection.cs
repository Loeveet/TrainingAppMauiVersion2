using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Authentication;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TrainingAppMauiVersion2.Models;
using TrainingAppMauiVersion2.Singletons;

namespace TrainingAppMauiVersion2.Connections
{
    internal class Connection
    {

        public static async Task<IMongoCollection<Person>> UserCollection()
        {
            var settings = MongoClientSettings.FromConnectionString("mongodb://RobinLiliegren:robin88@ac-ypkinxo-shard-00-00.cst2dyy.mongodb.net:27017,ac-ypkinxo-shard-00-01.cst2dyy.mongodb.net:27017,ac-ypkinxo-shard-00-02.cst2dyy.mongodb.net:27017/?ssl=true&replicaSet=atlas-fch61g-shard-0&authSource=admin&retryWrites=true&w=majority");
            var client = new MongoClient(settings);
            var database = client.GetDatabase("TrainingAppPerson");
            var myUsers = database.GetCollection<Person>("MyUsers");
            return myUsers;

        }

        //public static async Task<IMongoCollection<TrainingProgram>> TrainingProgramCollection()
        //{
        //    var settings = MongoClientSettings.FromConnectionString("mongodb://RobinLiliegren:robin88@ac-ypkinxo-shard-00-00.cst2dyy.mongodb.net:27017,ac-ypkinxo-shard-00-01.cst2dyy.mongodb.net:27017,ac-ypkinxo-shard-00-02.cst2dyy.mongodb.net:27017/?ssl=true&replicaSet=atlas-fch61g-shard-0&authSource=admin&retryWrites=true&w=majority");
        //    var client = new MongoClient(settings);
        //    var database = client.GetDatabase("TrainingAppPerson");
        //    var myTrainingPrograms = database.GetCollection<TrainingProgram>("MyPrograms");
        //    return myTrainingPrograms;
        //}

        public static async Task<ObservableCollection<Exercise>> GetExercices()
        {
            ChosenParameters chosenItem = ChosenParameters.GetInstansOfChosenParameters();

            var client = new HttpClient();
            client.BaseAddress = new Uri("https://api.api-ninjas.com");
            client.DefaultRequestHeaders.Add("X-Api-Key", "4DGnPLCofmkfjBtzIHc4Z55iv07P2Aw6vV57v5SP");
            ObservableCollection<Exercise> exercises = null;
            HttpResponseMessage response = await client.GetAsync("/v1/exercises?muscle=" + chosenItem.GetChosenMuscle()
            + (chosenItem.GetChosenDifficulty() != string.Empty ? "&difficulty=" + chosenItem.GetChosenDifficulty() : string.Empty)
            + (chosenItem.GetChosenTypeOfExercise() != string.Empty ? "&type=" + chosenItem.GetChosenTypeOfExercise() : string.Empty));
            if (response.IsSuccessStatusCode)
            {
                string responseString = await response.Content.ReadAsStringAsync();
                exercises = JsonSerializer.Deserialize<ObservableCollection<Exercise>>(responseString);
            }

            return exercises;
        }
        //public static async Task<OpenWeather> GetWeatherAsync(string city)
        //{

        //    string apiKey = "aaa3c5f1fb092617638c1dcf8266f07b";

        //    string url = $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={apiKey}&units=metric";
        //    OpenWeather weatherData = null;
        //    var client = new HttpClient();
        //    HttpResponseMessage response1 = await client.GetAsync(url);
        //    if (response1.IsSuccessStatusCode)
        //    {
        //        string apiResponse = await response1.Content.ReadAsStringAsync();
        //        weatherData = JsonSerializer.Deserialize<OpenWeather>(apiResponse);

        //    }
        //    return weatherData;
        //}
    }
}
