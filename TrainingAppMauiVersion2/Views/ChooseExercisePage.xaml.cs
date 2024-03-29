using MongoDB.Driver.Core.Authentication;
using TrainingAppMauiVersion2.Models;
using TrainingAppMauiVersion2.Singletons;

namespace TrainingAppMauiVersion2.Views;

public partial class ChooseExercisePage : ContentPage
{
    ChosenExercise chosenExercise = ChosenExercise.GetInstansOfChosenExercise();

    public ChooseExercisePage()
	{
		InitializeComponent();
        BindingContext = new ViewModels.ChooseExerciseViewModel();

    }
    private async void AddExerciseToList(object sender, SelectedItemChangedEventArgs e)
    {
        if (((ListView)sender).SelectedItem is Exercise exercise)
        {
            chosenExercise.SetChosenExercise(exercise);
            var page = new ExerciseDetailsPage();
            page.BindingContext = exercise;
            await Navigation.PushAsync(page);
        }
    }

    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CreateTrainingProgramPage());
    }
    private async void OnClickedLogOut(object sender, EventArgs e)
    {
        await Navigation.PopToRootAsync();
    }
}