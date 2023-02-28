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
}

