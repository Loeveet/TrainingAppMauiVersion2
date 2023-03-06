namespace TrainingAppMauiVersion2.Views;

public partial class SeeExercisesInProgramPage : ContentPage
{
	public SeeExercisesInProgramPage()
	{
		InitializeComponent();
	}

    private async void OnBackClicked(object sender, EventArgs e)
    {
		await Navigation.PopAsync();
    }
}