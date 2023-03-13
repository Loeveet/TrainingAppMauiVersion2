using TrainingAppMauiVersion2.Models;
using TrainingAppMauiVersion2.Singletons;
using CommunityToolkit.Mvvm.Input;
using MongoDB.Driver;



namespace TrainingAppMauiVersion2.Views;

public partial class CurrentSetList : ContentPage
{
    NewTrainingProgram newTrainingProgram = NewTrainingProgram.GetInstansOfListOfSets();
    ChosenExercise chosenExercise = ChosenExercise.GetInstansOfChosenExercise();
    LoggedInPerson loggedInUser = LoggedInPerson.GetInstansOfLoggedInPerson();

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
    private async void OnClickedLogOut(object sender, EventArgs e)
    {
        await Navigation.PopToRootAsync();
    }

    private async void AddProgramToUser(object sender, EventArgs e)
    {
        var users = await Connections.Connection.UserCollection();
        var user = loggedInUser.GetLoggedInPerson();

        TrainingProgram trainingProgram = new TrainingProgram()
        {
            Id = Guid.NewGuid(),
            Name = NewProgramName.Text,
            Exercises = newTrainingProgram.GetListOfSets()
        };
        user.Programs.Add(trainingProgram);
        await users.ReplaceOneAsync(x => x.Id == user.Id, loggedInUser.GetLoggedInPerson());
        await App.Current.MainPage.DisplayAlert("Success", "Program added to user", "Continue");
        await Navigation.PushAsync(new ExistingTrainingProgramsPage());
    }
}