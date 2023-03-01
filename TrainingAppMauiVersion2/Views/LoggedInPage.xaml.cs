namespace TrainingAppMauiVersion2.Views;

public partial class LoggedInPage : ContentPage
{
	public LoggedInPage()
	{
		InitializeComponent();
	}
    private async void OnClickedExistingTrainingProgramsPage(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ExistingTrainingProgramsPage());
    }

    private async void OnClickedCreateTrainingProgramPage(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CreateTrainingProgramPage());
    }

    private async void OnClickedOtherExercisesPage(object sender, EventArgs e)
    {
        //await Navigation.PushAsync(new OtherExercisesPage());
    }

    private async void OnClickedSearchForOtherExercisesPage(object sender, EventArgs e)
    {
        //await Navigation.PushAsync(new SearchForOtherExercisesPage());
    }
}