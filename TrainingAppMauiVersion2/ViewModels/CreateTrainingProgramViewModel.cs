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
using System.Windows.Input;
using TrainingAppMauiVersion2.Models;
using TrainingAppMauiVersion2.NewFolder;
using TrainingAppMauiVersion2.SessionData;
using TrainingAppMauiVersion2.Views;

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
        string apiMuscleName;

        [ObservableProperty]
        string muscleName;

        [ObservableProperty]
        string muscleForShow;


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

            var myTrainingPrograms = Connections.Connection.TrainingProgramCollection();

            {
                TrainingProgram program = new()
                {
                    Id = new Guid(),
                    Person = Person,
                    Name = Name,
                    Exercises = new List<Exercise>()

                };
                Task saveProgram = SaveProgram(program, myTrainingPrograms);
                await saveProgram;
                await App.Current.MainPage.DisplayAlert("Success", "You've created " + Name, "Continue");
            }

        }//TODO: Skapa metod för att även spara programmet hos användaren. kanske en delegat?
        private static async Task SaveProgram(TrainingProgram program, IMongoCollection<TrainingProgram> myTrainingPrograms)
        {
            await myTrainingPrograms.InsertOneAsync(program);
        }

        [RelayCommand]
        public static void ChooseMuscle(string muscle)
        {
            var fixedMuscle = HelperMethods.FixWordsForApi(muscle);
            SiteVariables.ChosenMuscle = fixedMuscle;
            
        }

    }
}