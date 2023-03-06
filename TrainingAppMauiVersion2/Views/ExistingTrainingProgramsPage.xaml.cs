using TrainingAppMauiVersion2.Models;
using TrainingAppMauiVersion2.Singletons;

namespace TrainingAppMauiVersion2.Views;

public partial class ExistingTrainingProgramsPage : ContentPage
{
    LoggedInPerson user = LoggedInPerson.GetInstansOfLoggedInPerson();
    ChosenTrainingProgram chosenTrainingProgram = ChosenTrainingProgram.GetInstansOfChosenTrainingProgram();
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

    private async void SeeExercisesInProgram(object sender, SelectedItemChangedEventArgs e)
    {
        if (((ListView)sender).SelectedItem is TrainingProgram trainingProgram)
        {
            chosenTrainingProgram.SetChosenTrainingProgram(trainingProgram);
            var page = new SeeExercisesInProgramPage();
            page.BindingContext = trainingProgram;
            await Navigation.PushAsync(page);
        }
    }

    private async void OnClickedLoggedOut(object sender, EventArgs e)
    {
        user.SetLoggedInPerson(null);
        await Navigation.PopToRootAsync();
    }
}