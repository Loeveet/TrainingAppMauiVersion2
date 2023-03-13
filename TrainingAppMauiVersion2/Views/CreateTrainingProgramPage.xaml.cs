using TrainingAppMauiVersion2.Singletons;
using TrainingAppMauiVersion2.ViewModels;

namespace TrainingAppMauiVersion2.Views;

public partial class CreateTrainingProgramPage : ContentPage
{
    ChosenParameters chosenParameters = ChosenParameters.GetInstansOfChosenParameters();
    public CreateTrainingProgramPage()
	{
		InitializeComponent();
        BindingContext = new CreateTrainingProgramViewModel();
    }

    private async void OnClickedChooseExercise(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ChooseExercisePage());
    }
    
    private async void ReloadPage(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CreateTrainingProgramPage());

    }

    private async void OnBackClicked(object sender, EventArgs e)
    {
        chosenParameters.SetChosenMuscle(string.Empty);
        chosenParameters.SetChosenDifficulty(string.Empty);
        chosenParameters.SetChosenTypeOfExercise(string.Empty);
        await Navigation.PushAsync(new ExistingTrainingProgramsPage());
    }
    private async void OnClickedLogOut(object sender, EventArgs e)
    {
        await Navigation.PopToRootAsync();
    }
}