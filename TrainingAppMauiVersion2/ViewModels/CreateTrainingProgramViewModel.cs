using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingAppMauiVersion2.Models;
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
        public CreateTrainingProgramViewModel()
        {
            Person = SiteVariables.LoggedInPerson;
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
    }
}