namespace TrainingAppMauiVersion2.Views;

public partial class ExistingTrainingProgramsPage : ContentPage
{
	public ExistingTrainingProgramsPage()
	{
		InitializeComponent();
        BindingContext = new ViewModels.ExistingTrainingProgramsViewModel();
    }
    private async void OnClickedExistingTrainingProgramsPage(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ExistingTrainingProgramsPage());
    }

    private async void OnClickedCreateTrainingProgramPage(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CreateTrainingProgramPage());
    }
}