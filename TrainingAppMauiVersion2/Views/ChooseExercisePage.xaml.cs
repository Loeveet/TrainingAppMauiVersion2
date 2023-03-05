using TrainingAppMauiVersion2.Models;
using TrainingAppMauiVersion2.Singletons;

namespace TrainingAppMauiVersion2.Views;

public partial class ChooseExercisePage : ContentPage
{
    LoggedInPerson user = LoggedInPerson.GetInstansOfLoggedInPerson();
    public ChooseExercisePage()
	{
		InitializeComponent();
        BindingContext = new ViewModels.ChooseExerciseViewModel();

    }
    private async void AddExerciseToList(object sender, SelectedItemChangedEventArgs e)
    {
        var exercise = ((ListView)sender).SelectedItem as Models.Exercise;

        if (exercise != null)
        {
            var page = new ExerciseDetailsPage();
            page.BindingContext = exercise;
            await Navigation.PushAsync(page);
        }
    }
}