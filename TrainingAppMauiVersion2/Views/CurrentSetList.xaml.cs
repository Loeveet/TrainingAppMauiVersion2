using TrainingAppMauiVersion2.Models;
using TrainingAppMauiVersion2.Singletons;
using CommunityToolkit.Mvvm.Input;
using MongoDB.Driver;
using TrainingAppMauiVersion2.Facade;

namespace TrainingAppMauiVersion2.Views;

public partial class CurrentSetList : ContentPage
{
    ISaveProgramFacade _saveProgramFacade = new SaveProgramFacade();
    NewTrainingProgram newTrainingProgram = NewTrainingProgram.GetInstansOfListOfSets();
    ChosenExercise chosenExercise = ChosenExercise.GetInstansOfChosenExercise();
    LoggedInPerson loggedInUser = LoggedInPerson.GetInstansOfLoggedInPerson();
    Person user;

    public CurrentSetList()
    {
        user = loggedInUser.GetLoggedInPerson();
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

    private async void OnClickedAddProgramToUser(object sender, EventArgs e)
    {
        if (_saveProgramFacade.SaveProgram(NewProgramName.Text, user))
        {

        }

        var users = await Connections.Connection.UserCollection();

        TrainingProgram trainingProgram = new TrainingProgram()
        {
            Id = Guid.NewGuid(),
            Name = NewProgramName.Text,
            Exercises = newTrainingProgram.GetListOfSets()
        };
        user.Programs.Add(trainingProgram);
        await users.ReplaceOneAsync(x => x.Id == user.Id, user);
        await App.Current.MainPage.DisplayAlert("Success", "Program added to user", "Continue");
        await Navigation.PushAsync(new ExistingTrainingProgramsPage());
    }
}