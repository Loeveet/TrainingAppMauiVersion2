using TrainingAppMauiVersion2.SessionData;

namespace TrainingAppMauiVersion2.Views;

public partial class CreateTrainingProgramPage : ContentPage
{
	public CreateTrainingProgramPage()
	{
		InitializeComponent();
		BindingContext = new ViewModels.CreateTrainingProgramViewModel();
	}
    private async void OnClickedChooseExercise(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ChooseExercisePage());
    }

}