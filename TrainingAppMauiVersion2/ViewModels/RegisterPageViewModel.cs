using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingAppMauiVersion2.Models;


namespace TrainingAppMauiVersion2.ViewModels
{
    internal partial class RegisterPageViewModel : ObservableObject
    {
        [ObservableProperty]
        string registerUserName;
        [ObservableProperty]
        string registerPassWord;
        [ObservableProperty]
        string registerName;
        [ObservableProperty]
        DateTime registerBirthDate;
        [ObservableProperty]
        int registerWeight;
        [ObservableProperty]
        int registerHeight;
        [ObservableProperty]
        string registerEmail;

        [RelayCommand]
        public async void OnClickedRegisterButton()
        {
            var settings = MongoClientSettings.FromConnectionString("mongodb+srv://RobinLiliegren:robin88@cluster0.cst2dyy.mongodb.net/?retryWrites=true&w=majority");
            settings.ServerApi = new ServerApi(ServerApiVersion.V1);
            var client = new MongoClient(settings);
            var database = client.GetDatabase("TrainingAppPerson");
            var myCollection = database.GetCollection<Person>("MyUsers");
            //Skapa en knapp för att registera personen om alla inmatningar är korrekta
            //och sen gå tillbaka till mainpage, för att logga in med valda parametrar
            Person person = new Person()
            {
                Id = new Guid(),
                UserName = RegisterUserName,
                PassWord = RegisterPassWord,
                Name = RegisterName,
                Birthday = RegisterBirthDate,
                Weight = RegisterWeight,
                Height = RegisterHeight,
                Email = RegisterEmail
            };
            Task savePerson = SaveUser(person, myCollection);
            await savePerson;
        }
        private static async Task SaveUser(Person person, IMongoCollection<Person> myCollection)
        {
            await myCollection.InsertOneAsync(person);
        }
    }
}
