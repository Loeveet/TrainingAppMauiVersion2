namespace TrainingAppMauiVersion2.Views;

public partial class ExerciseDetailsPage : ContentPage
{
	public ExerciseDetailsPage()
	{
		InitializeComponent();
        BindingContext = new ViewModels.ExerciseDetailsViewModel();

    }
}