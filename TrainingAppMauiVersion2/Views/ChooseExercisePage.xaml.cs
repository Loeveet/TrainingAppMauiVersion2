namespace TrainingAppMauiVersion2.Views;

public partial class ChooseExercisePage : ContentPage
{
	public ChooseExercisePage()
	{
		InitializeComponent();
        BindingContext = new ViewModels.ChooseExerciseViewModel();

    }
}