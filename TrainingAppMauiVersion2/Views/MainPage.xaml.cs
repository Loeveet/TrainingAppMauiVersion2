using TrainingAppMauiVersion2.Models;
using TrainingAppMauiVersion2.SessionData;
using TrainingAppMauiVersion2.ViewModels;
using TrainingAppMauiVersion2.Singletons;
using TrainingAppMauiVersion2.Facade;

namespace TrainingAppMauiVersion2;

public partial class MainPage : ContentPage
{
    //TODO: I första hand lägga till övningar i en lista
    //TODO: I andra hand lägga till vikt och repetioner per övning och spara det i ett exerciseset för att sedan läggas till i trainingprogram
    //TODO: Skriva ut personliga träningsprogram
    //TODO: Kunna välja träningsprogram för att läsa av
    //TODO: Kunna ändra/ta bort träningsprogram
    //TODO: Försöka att räkna ut förbrukning per träningsprogram
    //TODO: Lägga till otherexercises, som t ex löpning och sånt. Kanske bara visas för inspriration
    //TODO: Snygga till vädret på förstasidan för att rekomendera inne eller ute träning
    //TODO: Mindgames, lägga till en riddle och/eller trivia
    //TODO: Göra hela appen snyggare
    //TODO: Får jag inte till buttons i createtrainingprogrampage så gör om allt till label med knapp bredvid

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
            await Navigation.PushAsync(new Views.LoggedInPage());
            UserName.Text = string.Empty;
            PassWord.Text = string.Empty;
            return;
        }

        await DisplayAlert("Failed to log in", "Wrong username or password", "Try again");

    }
}

