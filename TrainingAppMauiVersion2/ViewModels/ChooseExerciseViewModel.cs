using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TrainingAppMauiVersion2.Models;
using TrainingAppMauiVersion2.SessionData;
using TrainingAppMauiVersion2.Singletons;

namespace TrainingAppMauiVersion2.ViewModels
{
    internal partial class ChooseExerciseViewModel : ObservableObject
    {
        ChosenParameters chosenItem = ChosenParameters.GetInstansOfChosenParameters();

        [ObservableProperty]
        string name;
        [ObservableProperty]
        string type;
        [ObservableProperty]
        string muscle;
        [ObservableProperty]
        string equipment;
        [ObservableProperty]
        string difficulty;
        [ObservableProperty]
        string instructions;
        [ObservableProperty]
        string chosenMuscle;

        [ObservableProperty]
        ObservableCollection<Exercise> exercises;

        public ChooseExerciseViewModel()
        {
            Exercises = new ObservableCollection<Exercise>();
            ChosenMuscle = chosenItem.GetChosenMuscle();
            GetTheExercises();

        }
        public async void GetTheExercises()
        {
            var exercises = await Connections.Connection.GetExercices();
            Exercises = exercises;
        }


    }
}
