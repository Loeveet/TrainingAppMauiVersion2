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
    public void OnBackClicked(object sender, EventArgs e)
    {
        inputs.SetIncorrectWeight(true);
        inputs.SetUserNameTaken(true);
        Navigation.PopToRootAsync();
    }

    private void OnRegisterClicked(object sender, EventArgs e)
    {
        if (inputs.GetUserNameTaken() == string.Empty && inputs.GetIncorrectWeight() == string.Empty)
        {
            Navigation.PushAsync(new MainPage());
        }
        else
        {
            Navigation.PushAsync(new RegisterPage());
        }
    }
}