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


        public ExistingTrainingProgramsViewModel()
        {
            User = getLoggedInUser.GetLoggedInPerson();
            TrainingPrograms = new ObservableCollection<TrainingProgram>();
            GetPrograms();
        }

        public void GetPrograms()
        {
            var allTrainingPrograms = Connections.Connection.TrainingProgramCollection();
            var usersTrainingProgram = allTrainingPrograms
                .AsQueryable()
                .Where(x => x.Person.Id == User.Id);
            foreach ( var tp in usersTrainingProgram)
            {
                TrainingPrograms.Add(tp);
            }
        }


    }
}

