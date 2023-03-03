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

        [ObservableProperty]
        public ObservableCollection<string> difficultyLevels;

        [ObservableProperty]
        public ObservableCollection<string> typesOfExercices;

        [ObservableProperty]
        string chosenDifficulty;

        [ObservableProperty]
        string chosenMuscle;

        [ObservableProperty]
        string chosenType;
        public CreateTrainingProgramViewModel()
        {
            ChosenMuscle = HelperMethods.CapitalizeFirstLetter(SiteVariables.ChosenMuscle);
            ChosenDifficulty = HelperMethods.CapitalizeFirstLetter(SiteVariables.ChosenDifficultness);
            ChosenType = HelperMethods.CapitalizeFirstLetter(SiteVariables.ChosenTypeOfExercise);
            Person = SiteVariables.LoggedInPerson;
            Muscles = new ObservableCollection<string>();
            DifficultyLevels = new ObservableCollection<string>();
            TypesOfExercices = new ObservableCollection<string>();
            AddMuscles();
            AddDifficultyLevels();
            AddTypesOfExercices();
        }
        private void AddMuscles()
        {
            var muscleArray = HelperMethods.CapitalizeFirstLetterInArray(Exercise.muscles);
            foreach (var m in muscleArray)
            {
                Muscles.Add(m);

            }
        }
        private void AddDifficultyLevels()
        {
            var difficultyLevelsArray = HelperMethods.CapitalizeFirstLetterInArray(Exercise.difficultyLevels);
            foreach (var m in difficultyLevelsArray)
            {
                DifficultyLevels.Add(m);

            }
        }
        private void AddTypesOfExercices()
        {
            var muscleArray = HelperMethods.CapitalizeFirstLetterInArray(Exercise.typesOfExercices);
            foreach (var m in muscleArray)
            {
                TypesOfExercices.Add(m);

            }
        }

        [RelayCommand]
        public async void ClickedGetProgramsButton()
        {

            var myTrainingPrograms = Connections.Connection.TrainingProgramCollection();
            var users = Connections.Connection.UserCollection();
            var user = users
                .AsQueryable()
                .SingleOrDefault(x => x.Id == SiteVariables.LoggedInPerson.Id);


            TrainingProgram program = new()
            {
                Id = new Guid(),
                Person = Person,
                Name = Name,
                Exercises = new List<Exercise>()

            };
            user.Programs.Add(program);
            await SaveProgram(program, myTrainingPrograms);
            await users.ReplaceOneAsync(x => x.Id == SiteVariables.LoggedInPerson.Id, user);
            await App.Current.MainPage.DisplayAlert("Success", "You've created " + Name, "Continue");


        }
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
        [RelayCommand]
        public static void ChooseDifficulty(string diff)
        {
            var fixedDiff = HelperMethods.FixWordsForApi(diff);
            SiteVariables.ChosenDifficultness = fixedDiff;

        }
        [RelayCommand]
        public static void ChooseType(string type)
        {
            var fixedType = HelperMethods.FixWordsForApi(type);
            SiteVariables.ChosenTypeOfExercise = fixedType;

        }

    }
}