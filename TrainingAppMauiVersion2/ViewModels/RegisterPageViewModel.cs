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

namespace TrainingAppMauiVersion2.ViewModels
{
    internal partial class RegisterPageViewModel : ObservableObject
    {
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

        [RelayCommand]
        public async void OnClickedRegisterButton()
        {
            var myCollection = await Connections.Connection.UserCollection();
            //Skapa en knapp för att registera personen om alla inmatningar är korrekta
            //och sen gå tillbaka till mainpage, för att logga in med valda parametrar


            Person person = new Person()
            {
                Id = new Guid(),
                UserName = UserName,
                PassWord = PassWord,
                Name = Name,
                Programs = new List<TrainingProgram>(),
                //Birthday = Convert.ToDateTime(BirthDate),
                Weight = HelperMethods.TryParseToInt(Weight)
                //Height = Convert.ToInt32(Height),
                //Email = Email
            };
            Task savePerson = SaveUser(person, myCollection);
            if (SaveUser(person, myCollection).IsCompletedSuccessfully)
            {
                await savePerson;
                await App.Current.MainPage.DisplayAlert("Success", "You are now registred as a new user", "Continue");
                UserName = string.Empty;
                PassWord = string.Empty;
                Name = string.Empty;
                Weight = string.Empty;
            }
            //BirthDate = string.Empty;

            //Height = string.Empty;
            //Email = string.Empty;
            //else
            //{
            //    await App.Current.MainPage.DisplayAlert("Failed", "Some field is incorrect", "Try again");
            //}


        }
        private static async Task SaveUser(Person person, IMongoCollection<Person> myCollection)
        {
            await myCollection.InsertOneAsync(person);
        }
    }
}
