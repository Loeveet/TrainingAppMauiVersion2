using TrainingAppMauiVersion2.SessionData;

namespace TrainingAppMauiVersion2.Views;

public partial class CreateTrainingProgramPage : ContentPage
{
	public CreateTrainingProgramPage()
	{
		InitializeComponent();
		BindingContext = new ViewModels.CreateTrainingProgramViewModel();
	}
	//TODO: skapa ny sida f�r att skriva ut �vningar, registerpage som det st�r h�r �r bara ett test.
    private async void OnClickedRegister(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Views.RegisterPage());

    }

}