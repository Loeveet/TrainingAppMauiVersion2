using TrainingAppMauiVersion2.ViewModels;

namespace TrainingAppMauiVersion2.Views;

public partial class RegisterPage : ContentPage
{
	public RegisterPage()
	{
		InitializeComponent();
        BindingContext = new RegisterPageViewModel();

    }
    private void OnBackClicked(object sender, EventArgs e)
    {
        Navigation.PopAsync();
    }
}