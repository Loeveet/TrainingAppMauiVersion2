using TrainingAppMauiVersion2.SessionData;
using TrainingAppMauiVersion2.Singletons;
using TrainingAppMauiVersion2.ViewModels;

namespace TrainingAppMauiVersion2.Views;

public partial class CreateTrainingProgramPage : ContentPage
{

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

}