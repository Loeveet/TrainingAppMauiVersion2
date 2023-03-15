using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TrainingAppMauiVersion2.Models;
using TrainingAppMauiVersion2.Singletons;

namespace TrainingAppMauiVersion2.ViewModels
{
    internal partial class MainPageViewModel : ObservableObject
    {
        WrongInput inputs = WrongInput.GetInstansOfInputs();
        LoggedInPerson getLoggedInUser = LoggedInPerson.GetInstansOfLoggedInPerson();

        [ObservableProperty]
        string input;

        [ObservableProperty]
        string userName;

        [ObservableProperty]
        string passWord;


        public MainPageViewModel()
        {
            getLoggedInUser.SetLoggedInPerson(null);
            Input = inputs.GetWrongInputLogInPage();
        }




    }
}
