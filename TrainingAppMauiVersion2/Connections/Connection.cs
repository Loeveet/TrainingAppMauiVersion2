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
using TrainingAppMauiVersion2.SessionData;

namespace TrainingAppMauiVersion2.Connections
{
    internal static class Connection
    {

        public static IMongoCollection<Person> UserCollection()
        {
            var settings = MongoClientSettings.FromConnectionString("mongodb+srv://RobinLiliegren:robin88@cluster0.cst2dyy.mongodb.net/?retryWrites=true&w=majority");
            settings.ServerApi = new ServerApi(ServerApiVersion.V1);
            var client = new MongoClient(settings);
            var database = client.GetDatabase("TrainingAppPerson");
            var myUsers = database.GetCollection<Person>("MyUsers");
            return myUsers;
        }

        public static IMongoCollection<TrainingProgram> TrainingProgramCollection()
        {
            var settings = MongoClientSettings.FromConnectionString("mongodb+srv://RobinLiliegren:robin88@cluster0.cst2dyy.mongodb.net/?retryWrites=true&w=majority");
            settings.ServerApi = new ServerApi(ServerApiVersion.V1);
            var client = new MongoClient(settings);
            var database = client.GetDatabase("TrainingAppPerson");
            var myTrainingPrograms = database.GetCollection<TrainingProgram>("MyPrograms");
            return myTrainingPrograms;
        }

        public static async Task<ObservableCollection<Exercise>> GetExercices()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://api.api-ninjas.com");
            client.DefaultRequestHeaders.Add("X-Api-Key", "4DGnPLCofmkfjBtzIHc4Z55iv07P2Aw6vV57v5SP");
            ObservableCollection<Exercise> exercises = null;
            HttpResponseMessage response = await client.GetAsync("/v1/exercises?muscle=" + SiteVariables.ChosenMuscle + 
                (SiteVariables.ChosenDifficultness != string.Empty ? "&difficulty=" + SiteVariables.ChosenDifficultness : string.Empty));
            if (response.IsSuccessStatusCode)
            {
                string responseString = await response.Content.ReadAsStringAsync();
                exercises = JsonSerializer.Deserialize<ObservableCollection<Exercise>>(responseString);
            }

            return exercises;
        }

    }
}
