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
using TrainingAppMauiVersion2.Singletons;

namespace TrainingAppMauiVersion2.ViewModels
{
    internal partial class ExistingTrainingProgramsViewModel : ObservableObject
    {
        LoggedInPerson getLoggedInUser = LoggedInPerson.GetInstansOfLoggedInPerson();

        [ObservableProperty]
        ObservableCollection<TrainingProgram> trainingPrograms;

        [ObservableProperty]
        Person user;

        [ObservableProperty]
        string name;

        [ObservableProperty]
        string burnedCalories;

        [ObservableProperty]
        ObservableCollection<ExerciseSet> exercises;

        [ObservableProperty]
        int chosenWeight;

        [ObservableProperty]
        int repetitions;


        public ExistingTrainingProgramsViewModel()
        {
            User = getLoggedInUser.GetLoggedInPerson();
            TrainingPrograms = new ObservableCollection<TrainingProgram>();
            GetPrograms();
        }

        public void GetPrograms()
        {

            foreach (var x in User.Programs)
            {
                TrainingPrograms.Add(x);
            }

        }


    }
}

