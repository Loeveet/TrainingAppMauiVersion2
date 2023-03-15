using TrainingAppMauiVersion2.Models;
using TrainingAppMauiVersion2.ViewModels;
using TrainingAppMauiVersion2.Singletons;
using TrainingAppMauiVersion2.Facade;
using Microsoft.Maui.Controls.Internals;

namespace TrainingAppMauiVersion2;

public partial class MainPage : ContentPage
{

    LoggedInPerson loggedInUser = LoggedInPerson.GetInstansOfLoggedInPerson();
    ILoginFacade _loginFacade = new LoginFacade();
    readonly WrongInput input = WrongInput.GetInstansOfInputs();

    public MainPage()
    {
        InitializeComponent();
        BindingContext = new MainPageViewModel();
    }

    private async void OnClickedRegister(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Views.RegisterPage());

    }

    /*
     Använder facade för inloggning här under. Tyvärr så är det bara en check i databasen för att se om personen finns,
     men är det så att man bygger vidare appen så är det lätt att lägga till de parameterna som vi gick igenom på 
     lektionen, för att se om personen har behörighet samt har betalat. 
     */
    private async void OnClickedLogIn(object sender, EventArgs e)
    {

        if (_loginFacade.CanLogIn(UserName.Text, PassWord.Text))
        {
            await DisplayAlert("Success", "Welcome " + loggedInUser.GetLoggedInPerson().Name, "Continue");
            await Navigation.PushAsync(new Views.ExistingTrainingProgramsPage());
            UserName.Text = string.Empty;
            PassWord.Text = string.Empty;
            input.SetWrongInputLogInPage(true);
            return;
        }
        UserName.Text = string.Empty;
        PassWord.Text = string.Empty;
        input.SetWrongInputLogInPage(false);
        await Navigation.PushAsync(new MainPage());


    }
}

