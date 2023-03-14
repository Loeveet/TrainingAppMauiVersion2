using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingAppMauiVersion2.Models;
using TrainingAppMauiVersion2.Singletons;

namespace TrainingAppMauiVersion2.ViewModels
{
    internal partial class ExerciseDetailsViewModel : ObservableObject
    {
        LoggedInPerson getLoggedInUser = LoggedInPerson.GetInstansOfLoggedInPerson();

        [ObservableProperty]
        Person user;

        public ExerciseDetailsViewModel()
        {
            User = getLoggedInUser.GetLoggedInPerson();
        }
    }
}
