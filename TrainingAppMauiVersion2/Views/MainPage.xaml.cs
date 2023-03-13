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
    WrongInput wrongInput = WrongInput.GetInstansOfInputs();

    public MainPage()
    {
        InitializeComponent();
        BindingContext = new MainPageViewModel();
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
            wrongInput.SetWrongInputLogInPage(true);
            return;
        }
        UserName.Text = string.Empty;
        PassWord.Text = string.Empty;
        wrongInput.SetWrongInputLogInPage(false);
        await Navigation.PushAsync(new MainPage());


    }
}

