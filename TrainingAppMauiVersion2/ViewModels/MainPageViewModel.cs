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
        WrongInput wrongInput = WrongInput.GetInstansOfInputs();
        LoggedInPerson user = LoggedInPerson.GetInstansOfLoggedInPerson();

        [ObservableProperty]
        string input;

        [ObservableProperty]
        string userName;

        [ObservableProperty]
        string passWord;

        //[ObservableProperty]
        //OpenWeather oWeather;

        public MainPageViewModel()
        {
            user.SetLoggedInPerson(null);
            Input = wrongInput.GetWrongInputLogInPage();
            //OWeather = new OpenWeather();
        }

        //public async void GetAWeather()
        //{
        //    var weather = await Connections.Connection.GetWeatherAsync("Nyköping");
        //    OWeather = weather;
        //}



    }
}
