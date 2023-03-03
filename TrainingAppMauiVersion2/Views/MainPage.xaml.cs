using TrainingAppMauiVersion2.SessionData;
using TrainingAppMauiVersion2.ViewModels;

namespace TrainingAppMauiVersion2;

public partial class MainPage : ContentPage
{

    public MainPage()
	{
		InitializeComponent();
		BindingContext = new ViewModels.MainPageViewModel();
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

        var users = await MainPageViewModel.GetUsersFromMongoDB();

        foreach (var user in users)
        {
            if (UserName.Text == user.UserName && PassWord.Text == user.PassWord)
            {
                await DisplayAlert("Success", "Welcome " + user.Name, "Continue");
                SiteVariables.LoggedInPerson = user;
                await Navigation.PushAsync(new Views.LoggedInPage());
                return;
            }

        }

        await DisplayAlert("Failed to log in", "Wrong username or password", "Try again");

    }
}

