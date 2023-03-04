using TrainingAppMauiVersion2.Models;
using TrainingAppMauiVersion2.SessionData;
using TrainingAppMauiVersion2.ViewModels;
using TrainingAppMauiVersion2.Singletons;
using TrainingAppMauiVersion2.Facade;

namespace TrainingAppMauiVersion2;

public partial class MainPage : ContentPage
{

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

