using MongoDB.Driver;
using TrainingAppMauiVersion2.Models;
using TrainingAppMauiVersion2.Singletons;
using TrainingAppMauiVersion2.ViewModels;

namespace TrainingAppMauiVersion2.Views;

public partial class SeeExercisesInProgramPage : ContentPage
{
    ChosenTrainingProgram chosenTrainingProgram = ChosenTrainingProgram.GetInstansOfChosenTrainingProgram();
    LoggedInPerson loggedInUser = LoggedInPerson.GetInstansOfLoggedInPerson();
    bool pageStarted;

    public SeeExercisesInProgramPage()
    {
        InitializeComponent();
        BindingContext = new SeeExercisesInProgramViewModel();

    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        BindingContext = new SeeExercisesInProgramViewModel();
        //if (!pageStarted)
        //{
        //    pageStarted = true;
        //}
    }


    private async void DeleteSetFromTrainingProgram(object sender, SelectedItemChangedEventArgs e)
    {
        var user = loggedInUser.GetLoggedInPerson();
        var users = await Connections.Connection.UserCollection();

        if (((ListView)sender).SelectedItem is ExerciseSet set)
        {
            chosenTrainingProgram.DeleteSetFromProgram(set);
            await users.ReplaceOneAsync(x => x.Id == user.Id, user);

            var page = new SeeExercisesInProgramPage();
            await Navigation.PushAsync(page);
        }
    }

    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ExistingTrainingProgramsPage());
    }
    private async void EditSet(object sender, SelectedItemChangedEventArgs e)
    {
        var user = loggedInUser.GetLoggedInPerson();
        var users = await Connections.Connection.UserCollection();


        if (((ListView)sender).SelectedItem is ExerciseSet set)
        {
            chosenTrainingProgram.EditSetInProgram(set); //TODO: metod utan inneh�ll. h�nder inget
            await users.ReplaceOneAsync(x => x.Id == user.Id, user);

            var page = new SeeExercisesInProgramPage();
            await Navigation.PushAsync(page);
        }

    }
}