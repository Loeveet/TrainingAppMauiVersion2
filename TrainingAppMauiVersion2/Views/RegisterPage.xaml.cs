using TrainingAppMauiVersion2.Singletons;
using TrainingAppMauiVersion2.ViewModels;

namespace TrainingAppMauiVersion2.Views;

public partial class RegisterPage : ContentPage
{
    WrongInput inputs = WrongInput.GetInstansOfInputs();
	public RegisterPage()
	{
		InitializeComponent();
        BindingContext = new RegisterPageViewModel();

    }
    public async void OnBackClicked(object sender, EventArgs e)
    {
        inputs.SetIncorrectWeight(true);
        inputs.SetUserNameTaken(true);
        await Navigation.PopToRootAsync();
    }

    private async void OnRegisterClicked(object sender, EventArgs e)
    {
        if (inputs.GetUserNameTaken() == string.Empty && inputs.GetIncorrectWeight() == string.Empty)
        {
            await Navigation.PopToRootAsync();
        }
        else
        {
            await Navigation.PushAsync(new RegisterPage());
        }
    }
}