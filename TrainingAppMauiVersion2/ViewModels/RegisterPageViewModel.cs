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
        WrongInput wrongInput = WrongInput.GetInstansOfInputs();

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
            UserNameTaken = wrongInput.GetUserNameTaken();
            CorrectWeight = wrongInput.GetIncorrectWeight();
        }

        [RelayCommand]
        public async void OnClickedRegisterButton()
        {
            var users = await Connections.Connection.UserCollection();

            Person person = new Person()
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
                await SaveUser(person, users);
                await App.Current.MainPage.DisplayAlert("Success", "You are now registred as a new user", "Continue");
                UserName = string.Empty;
                PassWord = string.Empty;
                Name = string.Empty;
                Weight = string.Empty;
            }


        }
        private static async Task SaveUser(Person person, IMongoCollection<Person> users)
        {
            await users.InsertOneAsync(person);
        }
        private async Task<string> CheckUserName(string name)
        {
            WrongInput userNameTaken = WrongInput.GetInstansOfInputs();
            if (name == null || name == string.Empty)
            {
                return string.Empty;
            }

            var users = await Connections.Connection.UserCollection();
            foreach (var user in users.AsQueryable())
            {
                if (name == user.UserName)
                {
                    userNameTaken.SetUserNameTaken(false);
                    UserNameOk = false;
                    return string.Empty;
                }
            }
            userNameTaken.SetUserNameTaken(true);
            UserNameOk = true;
            return name;
        }

        private double CheckWeight()
        {
            var w = HelperMethods.TryParseToDouble(Weight.Replace('.', ','));
            if (w == 0)
            {
                wrongInput.SetIncorrectWeight(false);
                CorrectWeight = wrongInput.GetIncorrectWeight();
                WeightOk = false;
            }
            else
            {
                wrongInput.SetIncorrectWeight(true);
                CorrectWeight = wrongInput.GetIncorrectWeight();
                WeightOk = true;
            }
            return w;
        }
    }
}
