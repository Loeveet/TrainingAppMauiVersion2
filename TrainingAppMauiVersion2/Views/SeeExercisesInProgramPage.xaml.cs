using TrainingAppMauiVersion2.ViewModels;

namespace TrainingAppMauiVersion2.Views;

public partial class SeeExercisesInProgramPage : ContentPage
{
	public SeeExercisesInProgramPage()
	{
		InitializeComponent();
        BindingContext = new SeeExercisesInProgramViewModel();

    }

    private async void OnBackClicked(object sender, EventArgs e)
    {
		await Navigation.PopAsync();
    }
}