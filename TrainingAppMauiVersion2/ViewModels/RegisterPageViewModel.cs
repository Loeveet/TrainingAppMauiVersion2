using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingAppMauiVersion2.Models;
using TrainingAppMauiVersion2.NewFolder;
using TrainingAppMauiVersion2.Singletons;

namespace TrainingAppMauiVersion2.ViewModels
{
    internal partial class RegisterPageViewModel : ObservableObject
    {
        WrongInput inputs = WrongInput.GetInstansOfInputs();

        [ObservableProperty]
        string userName;
        [ObservableProperty]
        string passWord;
        [ObservableProperty]
        string name;
        [ObservableProperty]
        string birthDate;
        [ObservableProperty]
        string weight;
        [ObservableProperty]
        string height;
        [ObservableProperty]
        string email;
        [ObservableProperty]
        string userNameTaken;
        [ObservableProperty]
        string correctWeight;
        

        public bool UserNameOk { get; set; }
        public bool WeightOk { get; set; }

        public RegisterPageViewModel()
        {
            UserNameTaken = inputs.GetUserNameTaken();
            CorrectWeight = inputs.GetIncorrectWeight();
        }

        [RelayCommand]
        public async void RegisterUser()
        {
            Person user = new Person()
            {
                Id = new Guid(),
                UserName = await CheckUserName(UserName),
                PassWord = PassWord,
                Name = Name,
                Programs = new List<TrainingProgram>(),
                Weight = CheckWeight()
            };

            if (UserNameOk && WeightOk)
            {
                Person.SaveUser(user);
                await App.Current.MainPage.DisplayAlert("Success", "You are now registred as a new user", "Continue");
                UserName = string.Empty;
                PassWord = string.Empty;
                Name = string.Empty;
                Weight = string.Empty;
            }
        }

        private async Task<string> CheckUserName(string name)
        {
            if (name == null || name == string.Empty)
            {
                return string.Empty;
            }

            var users = await Connections.Connection.UserCollection();
            foreach (var user in users.AsQueryable())
            {
                if (name == user.UserName)
                {
                    inputs.SetUserNameTaken(false);
                    UserNameOk = false;
                    return string.Empty;
                }
            }
            inputs.SetUserNameTaken(true);
            UserNameOk = true;
            return name;
        }

        private double CheckWeight()
        {
            if (Weight == null)
            {
                inputs.SetIncorrectWeight(false);
                CorrectWeight = inputs.GetIncorrectWeight();
                WeightOk = false;
                return 0;
            }
            var w = HelperMethods.TryParseToDouble(Weight.Replace('.', ','));
            if (w == 0)
            {
                inputs.SetIncorrectWeight(false);
                CorrectWeight = inputs.GetIncorrectWeight();
                WeightOk = false;
            }
            else
            {
                inputs.SetIncorrectWeight(true);
                CorrectWeight = inputs.GetIncorrectWeight();
                WeightOk = true;
            }
            return w;
        }
    }
}
