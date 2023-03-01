using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TrainingAppMauiVersion2.Models;
using TrainingAppMauiVersion2.NewFolder;
using TrainingAppMauiVersion2.SessionData;

namespace TrainingAppMauiVersion2.ViewModels
{
    internal partial class CreateTrainingProgramViewModel : ObservableObject
    {
        [ObservableProperty]
        ObservableCollection<TrainingProgram> trainingPrograms;

        [ObservableProperty]
        Person person;

        [ObservableProperty]
        string name;

        [ObservableProperty]
        public ObservableCollection<string> muscles;

        public CreateTrainingProgramViewModel()
        {
            Person = SiteVariables.LoggedInPerson;
            Muscles = new ObservableCollection<string>();
            AddMuscles();      
        }
        private void AddMuscles()
        {
            var muscleArray = HelperMethods.CapitalizeFirstLetterInArray(Exercise.muscles);
            foreach (var m in muscleArray)
            {
                Muscles.Add(m);
            }
        }

        [RelayCommand]
        public async void ClickedGetProgramsButton()
        {
            var settings = MongoClientSettings.FromConnectionString("mongodb+srv://RobinLiliegren:robin88@cluster0.cst2dyy.mongodb.net/?retryWrites=true&w=majority");
            settings.ServerApi = new ServerApi(ServerApiVersion.V1);
            var client = new MongoClient(settings);
            var database = client.GetDatabase("TrainingAppPerson");
            var myCollection = database.GetCollection<TrainingProgram>("MyPrograms");


            {
                TrainingProgram program = new()
                {
                    Id = new Guid(),
                    Person = Person,
                    Name = Name,
                    Exercises = new List<Exercise>()

                };
                Task saveProgram = SaveProgram(program, myCollection);
                await saveProgram;
                await App.Current.MainPage.DisplayAlert("Success", "You created " + Name, "Continue");
            }

        }
        private static async Task SaveProgram(TrainingProgram program, IMongoCollection<TrainingProgram> myCollection)
        {
            await myCollection.InsertOneAsync(program);
        }

        [RelayCommand]
        public static async Task<ObservableCollection<Exercise>> GetExercices(string muscle)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://api.api-ninjas.com/");
            client.DefaultRequestHeaders.Add("X-Api-Key", "E2O3R8zknVI8Lo/k0kdq7A==JBFTCWQdZStbgUQq");

            ObservableCollection<Exercise> exercises = null;

            HttpResponseMessage response = await client.GetAsync(muscle);
            if (response.IsSuccessStatusCode)
            {
                string responseString = await response.Content.ReadAsStringAsync();
                exercises = JsonSerializer.Deserialize<ObservableCollection<Exercise>>(responseString);
            }

            return exercises;
        }
    }
}