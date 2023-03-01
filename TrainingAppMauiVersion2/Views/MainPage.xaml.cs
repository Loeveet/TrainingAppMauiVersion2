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
                await App.Current.MainPage.DisplayAlert("Success", "Welcome " + user.Name, "Continue");
                await Navigation.PushAsync(new Views.LoggedInPage());
                return;
            }

        }

        await App.Current.MainPage.DisplayAlert("Failed to log in", "Wrong username or password", "Try again");

    }
}

