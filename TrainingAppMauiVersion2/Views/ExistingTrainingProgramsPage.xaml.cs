using MongoDB.Driver;
using TrainingAppMauiVersion2.Models;
using TrainingAppMauiVersion2.Singletons;

namespace TrainingAppMauiVersion2.Views;

public partial class ExistingTrainingProgramsPage : ContentPage
{
    LoggedInPerson loggedInUser = LoggedInPerson.GetInstansOfLoggedInPerson();
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
            await Navigation.PushAsync(new SeeExercisesInProgramPage());
        }
    }

    private async void OnClickedLogOut(object sender, EventArgs e)
    {
        await Navigation.PopToRootAsync();
    }

    private async void Delete(object sender, SelectedItemChangedEventArgs e)
    {
        var user = loggedInUser.GetLoggedInPerson();
        var users = await Connections.Connection.UserCollection();

        if (((ListView)sender).SelectedItem is TrainingProgram trainingProgram)
        {
            user.Programs.Remove(trainingProgram);
            await users.ReplaceOneAsync(x => x.Id == user.Id, user);            
            await Navigation.PushAsync(new ExistingTrainingProgramsPage());
        }

    }


}