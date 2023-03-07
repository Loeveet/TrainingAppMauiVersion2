using TrainingAppMauiVersion2.Models;
using TrainingAppMauiVersion2.SessionData;
using TrainingAppMauiVersion2.ViewModels;
using TrainingAppMauiVersion2.Singletons;
using TrainingAppMauiVersion2.Facade;

namespace TrainingAppMauiVersion2;

public partial class MainPage : ContentPage
{
    //TODO: 1. Ha en knapp till en sida som visar listan av set innan man gör klart programmet
    //TODO: 2. Gärna även kunna justera, eller i alla fall to bort övningar i den vyn
    //TODO: 3. Kunna ändra/ta bort träningsprogram
    //TODO: 4. Försöka att räkna ut förbrukning per träningsprogram
    //TODO: 5. Lägga till otherexercises, som t ex löpning och sånt. Kanske bara visas för inspriration
    //TODO: 6. Snygga till vädret på förstasidan för att rekomendera inne eller ute träning
    //TODO: 7. Mindgames, lägga till en riddle och/eller trivia
    //TODO: 8. Göra hela appen snyggare

    LoggedInPerson loggedInUser = LoggedInPerson.GetInstansOfLoggedInPerson();

    ILoginFacade _loginFacade = new LoginFacade();

    public MainPage()
    {
        InitializeComponent();
        BindingContext = new MainPageViewModel();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        (BindingContext as MainPageViewModel).GetAWeather();
    }

    private async void OnClickedRegister(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Views.RegisterPage());

    }

    private async void OnClickedLogIn(object sender, EventArgs e)
    {

        if (_loginFacade.CanLogIn(UserName.Text, PassWord.Text))  //Facade för inlogg
        {
            await DisplayAlert("Success", "Welcome " + loggedInUser.GetLoggedInPerson().Name, "Continue");
            await Navigation.PushAsync(new Views.ExistingTrainingProgramsPage());
            UserName.Text = string.Empty;
            PassWord.Text = string.Empty;
            return;
        }

        await DisplayAlert("Failed to log in", "Wrong username or password", "Try again");

    }
}

