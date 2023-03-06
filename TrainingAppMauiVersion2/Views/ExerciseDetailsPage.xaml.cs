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
    Person user;
    public ExerciseDetailsPage()
    {
        InitializeComponent();
        BindingContext = new ViewModels.ExerciseDetailsViewModel();
        user = loggedInUser.GetLoggedInPerson();
    }

    private void CreateSet(object sender, EventArgs e)
    {
        //Person user = loggedInUser.GetLoggedInPerson();
        try
        {
            int nrOfSecondsOfARep = 5;
            double metValue = 4.8;
            TimeSpan ts = TimeSpan.FromSeconds(Convert.ToInt32(Reps.Text) * nrOfSecondsOfARep);
            double duration = Math.Round(ts.TotalMinutes, 2);
            Exercise exercise = chosenExercise.GetChosenExercise();
            double caloriesBurned = Math.Round(metValue * user.Weight * 0.0175 * duration);

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
        catch (Exception ex)
        {
            App.Current.MainPage.DisplayAlert("Fail", "Try it again, dummy", "Try again");

        }

    }
    private void AddSetToProgram(ExerciseSet exerciseSet)
    {
        newTrainingProgram.AddSetToList(exerciseSet);

        //var trainingPrograms = await Connections.Connection.TrainingProgramCollection();
        //var usersProgram = trainingPrograms
        //    .AsQueryable()
        //    .Where(x => x.Person.Id == user.Id);

    }
    private async void AddProgramToUser(object sender, EventArgs e)
    {
        TrainingProgram trainingProgram = new TrainingProgram()
        {
            Id = new Guid(),
            Name = "Kom ihåg att man ska skriva namn på sitt program", //TODO: FIX!
            Exercises = newTrainingProgram.GetListOfSets()
        };
        user.Programs.Add(trainingProgram);
        var trainingPrograms = await Connections.Connection.TrainingProgramCollection();
        Task saveProgram = SaveNewProgram(trainingProgram, trainingPrograms);
        await saveProgram;
        await App.Current.MainPage.DisplayAlert("Success", "Program added to user", "Continue");
        await Navigation.PushAsync(new ExistingTrainingProgramsPage());
    }
    private static async Task SaveNewProgram(TrainingProgram trainingProgram, IMongoCollection<TrainingProgram> trainingPrograms)
    {
        await trainingPrograms.InsertOneAsync(trainingProgram);
    }
    private async void OnClickedBack(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}