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

        public SeeExercisesInProgramViewModel()
        {
            Exercises = new ObservableCollection<ExerciseSet>();
            TrainingProgram = new TrainingProgram();
            TrainingProgram = chosenTrainingProgram.GetChosenTrainingProgram();
            foreach (var set in TrainingProgram.Exercises.ToList())
            {
                Exercises.Add(set);
            }
            
        }
    }
}
