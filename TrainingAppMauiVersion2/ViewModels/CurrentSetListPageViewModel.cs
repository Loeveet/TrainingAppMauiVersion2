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
    internal partial class CurrentSetListPageViewModel : ObservableObject
    {
        NewTrainingProgram program = NewTrainingProgram.GetInstansOfListOfSets();
        LoggedInPerson getLoggedInUser = LoggedInPerson.GetInstansOfLoggedInPerson();

        [ObservableProperty]
        Person user;

        [ObservableProperty]
        ObservableCollection<ExerciseSet> exercises;

        [ObservableProperty]
        Exercise exercise;

        [ObservableProperty]
        double caloriesBurned;

        [ObservableProperty]
        int choosenWeight;

        [ObservableProperty]
        int repetitions;

        [ObservableProperty]
        int nrOfSets;

        [ObservableProperty]
        int offSetButtons;

        public CurrentSetListPageViewModel()
        {
            User = getLoggedInUser.GetLoggedInPerson();
            NrOfSets = program.GetListOfSets().Count();
            OffSetButtons = SetButtonOffSet();

            Exercises = new ObservableCollection<ExerciseSet>();
            foreach (var x in program.GetListOfSets())
            {
                Exercises.Add(x);
                Exercise = x.Exercise;
                CaloriesBurned = x.CaloriesBurned;
                ChoosenWeight = x.ChoosenWeight;
                Repetitions = x.Repetitions;

            }
        }

        private int SetButtonOffSet()
        {
            if (program.GetListOfSets().Count != 0)
            {
                return 2;
            }
            
            return 0;

        }
    }
}
