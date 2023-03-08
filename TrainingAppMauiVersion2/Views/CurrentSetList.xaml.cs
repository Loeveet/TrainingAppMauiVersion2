using TrainingAppMauiVersion2.Models;
using TrainingAppMauiVersion2.Singletons;

namespace TrainingAppMauiVersion2.Views;

public partial class CurrentSetList : ContentPage
{
    NewTrainingProgram newTrainingProgram = NewTrainingProgram.GetInstansOfListOfSets();
    public CurrentSetList()
    {
        InitializeComponent();
        BindingContext = new ViewModels.CurrentSetListPageViewModel();
    }

    private async void OnClickedBack(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ExerciseDetailsPage());
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