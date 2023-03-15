using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingAppMauiVersion2.Models;
using TrainingAppMauiVersion2.Singletons;

namespace TrainingAppMauiVersion2.ViewModels
{
    internal partial class SeeExercisesInProgramViewModel : ObservableObject
    {
        ChosenTrainingProgram chosenTrainingProgram = ChosenTrainingProgram.GetInstansOfChosenTrainingProgram();
        LoggedInPerson getLoggedInUser = LoggedInPerson.GetInstansOfLoggedInPerson();

        [ObservableProperty]
        Person user;

        [ObservableProperty]
        TrainingProgram trainingProgram;

        [ObservableProperty]
        ObservableCollection<ExerciseSet> exercises;

        [ObservableProperty]
        Exercise exercise;

        [ObservableProperty]
        int choosenWeight;
        [ObservableProperty]
        int repetitions;
        [ObservableProperty]
        double duration;
        [ObservableProperty]
        double caloriesBurned;
        [ObservableProperty]
        double totalCalories = 0;
        [ObservableProperty]
        int totalReps = 0;
        [ObservableProperty]
        int totalWeight = 0;
        [ObservableProperty]
        double totalTime = 0;

        public SeeExercisesInProgramViewModel()
        {
            User = getLoggedInUser.GetLoggedInPerson();
            Exercises = new ObservableCollection<ExerciseSet>();
            TrainingProgram = new TrainingProgram();
            TrainingProgram = chosenTrainingProgram.GetChosenTrainingProgram();
            foreach (var set in TrainingProgram.Exercises.ToList())
            {
                Exercises.Add(set);
                TotalCalories += set.CaloriesBurned;
                TotalReps += set.Repetitions;
                TotalWeight += set.ChoosenWeight;
            }
            TotalTime = ((TotalReps * 5) + (TrainingProgram.Exercises.Count -1) * 120) / 60;
        }
    }
}
