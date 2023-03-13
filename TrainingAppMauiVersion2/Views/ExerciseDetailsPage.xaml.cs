using CommunityToolkit.Mvvm.Input;
using MongoDB.Driver;
using TrainingAppMauiVersion2.Models;
using TrainingAppMauiVersion2.NewFolder;
using TrainingAppMauiVersion2.Singletons;

namespace TrainingAppMauiVersion2.Views;

public partial class ExerciseDetailsPage : ContentPage
{
    LoggedInPerson loggedInUser = LoggedInPerson.GetInstansOfLoggedInPerson();
    ChosenExercise chosenExercise = ChosenExercise.GetInstansOfChosenExercise();
    NewTrainingProgram newTrainingProgram = NewTrainingProgram.GetInstansOfListOfSets();
    public ExerciseDetailsPage()
    {
        InitializeComponent();
        BindingContext = new ViewModels.ExerciseDetailsViewModel();
    }

    private void CreateSet(object sender, EventArgs e)
    {
        try
        {
            int nrOfSecondsOfARep = 5;
            double metValue = 4.8;
            TimeSpan ts = TimeSpan.FromSeconds(Convert.ToInt32(Reps.Text) * nrOfSecondsOfARep);
            double duration = Math.Round(ts.TotalMinutes, 2);
            Exercise exercise = chosenExercise.GetChosenExercise();
            double caloriesBurned = Math.Round(metValue * loggedInUser.GetLoggedInPerson().Weight * 0.0175 * duration);

            ExerciseSet exerciseSet = new()
            {
                Exercise = exercise,
                ChoosenWeight = Convert.ToInt32(Ws.Text),
                Repetitions = Convert.ToInt32(Reps.Text),
                Duration = duration,
                CaloriesBurned = caloriesBurned

            };

            AddSetToProgram(exerciseSet);
            App.Current.MainPage.DisplayAlert("Success", "Set successfully created", "Continue");
        }
        catch 
        {
            App.Current.MainPage.DisplayAlert("Fail", "Try it again, dummy", "Try again");

        }

    }
    private void AddSetToProgram(ExerciseSet exerciseSet)
    {
        newTrainingProgram.AddSetToList(exerciseSet);

    }
    private async void AddProgramToUser(object sender, EventArgs e)
    {
        var users = await Connections.Connection.UserCollection();

        TrainingProgram trainingProgram = new TrainingProgram()
        {
            Id = Guid.NewGuid(),
            Name = NewProgramName.Text,
            Exercises = newTrainingProgram.GetListOfSets()
        };
        loggedInUser.GetLoggedInPerson().Programs.Add(trainingProgram);
        await users.ReplaceOneAsync(x => x.Id == loggedInUser.GetLoggedInPerson().Id, loggedInUser.GetLoggedInPerson());
        await App.Current.MainPage.DisplayAlert("Success", "Program added to user", "Continue");
        await Navigation.PushAsync(new ExistingTrainingProgramsPage());
    }

    private async void OnClickedBack(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ChooseExercisePage());
    }

    private async void OnClickedCurrentSetList(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CurrentSetList());
    }

    private async void OnClickedLogOut(object sender, EventArgs e)
    {
        await Navigation.PopToRootAsync();
    }
}