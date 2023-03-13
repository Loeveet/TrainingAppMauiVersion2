using TrainingAppMauiVersion2.Models;
using TrainingAppMauiVersion2.Singletons;

namespace TrainingAppMauiVersion2.Views;

public partial class CurrentSetList : ContentPage
{
    NewTrainingProgram newTrainingProgram = NewTrainingProgram.GetInstansOfListOfSets();
    ChosenExercise chosenExercise = ChosenExercise.GetInstansOfChosenExercise();

    public CurrentSetList()
    {
        InitializeComponent();
        BindingContext = new ViewModels.CurrentSetListPageViewModel();
    }

    private async void OnClickedBack(object sender, EventArgs e)
    {
        var page = new ExerciseDetailsPage();
        page.BindingContext = chosenExercise.GetChosenExercise();
        await Navigation.PushAsync(page);
    }

    private async void DeleteSet(object sender, SelectedItemChangedEventArgs e)
    {
        if (((ListView)sender).SelectedItem is ExerciseSet set)
        {
            newTrainingProgram.DeleteSet(set);
            var page = new CurrentSetList();
            await Navigation.PushAsync(page);
        }
    }

}