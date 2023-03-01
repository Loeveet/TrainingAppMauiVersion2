namespace TrainingAppMauiVersion2.Views;

public partial class ExistingTrainingProgramsPage : ContentPage
{
	public ExistingTrainingProgramsPage()
	{
		InitializeComponent();
        BindingContext = new ViewModels.ExistingTrainingProgramsViewModel();
    }
}