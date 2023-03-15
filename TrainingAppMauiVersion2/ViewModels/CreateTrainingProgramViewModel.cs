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
using System.Xml.Linq;
using TrainingAppMauiVersion2.Models;
using TrainingAppMauiVersion2.NewFolder;
using TrainingAppMauiVersion2.Singletons;
using TrainingAppMauiVersion2.Views;

namespace TrainingAppMauiVersion2.ViewModels
{
    internal partial class CreateTrainingProgramViewModel : ObservableObject
    {

        LoggedInPerson getLoggedInUser = LoggedInPerson.GetInstansOfLoggedInPerson();
        ChosenParameters chosenItem = ChosenParameters.GetInstansOfChosenParameters();

        [ObservableProperty]
        Person user;

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

        [ObservableProperty]
        int nrOfSets;

        public CreateTrainingProgramViewModel()
        {
            User = getLoggedInUser.GetLoggedInPerson();
            ChosenMuscle = HelperMethods.CapitalizeFirstLetter(chosenItem.GetChosenMuscle());
            ChosenDifficulty = HelperMethods.CapitalizeFirstLetter(chosenItem.GetChosenDifficulty());
            ChosenType = HelperMethods.CapitalizeFirstLetter(chosenItem.GetChosenTypeOfExercise());
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
        public void ChooseMuscle(string muscle)
        {
            if (string.IsNullOrWhiteSpace(muscle))
            {
                chosenItem.SetChosenMuscle(string.Empty);
                return;
            }
            chosenItem.SetChosenMuscle(HelperMethods.FixWordsForApi(muscle));

        }
        [RelayCommand]
        public void ChooseDifficulty(string diff)
        {
            if (string.IsNullOrWhiteSpace(diff))
            {
                chosenItem.SetChosenDifficulty(string.Empty);
                return;
            }
            chosenItem.SetChosenDifficulty(HelperMethods.FixWordsForApi(diff));

        }
        [RelayCommand]
        public void ChooseType(string type)
        {
            if (string.IsNullOrWhiteSpace(type))
            {
                chosenItem.SetChosenTypeOfExercise(string.Empty);
                return;
            }
            chosenItem.SetChosenTypeOfExercise(HelperMethods.FixWordsForApi(type));

        }

    }
}