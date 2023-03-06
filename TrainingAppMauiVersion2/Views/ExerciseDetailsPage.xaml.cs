using MongoDB.Driver;
using TrainingAppMauiVersion2.Models;
using TrainingAppMauiVersion2.NewFolder;
using TrainingAppMauiVersion2.Singletons;

namespace TrainingAppMauiVersion2.Views;

public partial class ExerciseDetailsPage : ContentPage
{
    LoggedInPerson loggedInUser = LoggedInPerson.GetInstansOfLoggedInPerson();
    ChosenExercise chosenExercise = ChosenExercise.GetInstansOfChosenExercise();
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
        int nrOfSecondsOfARep = 5;
        double metValue = 4.8;
        int weight = HelperMethods.TryParseToInt(Ws.Text);
        int reps = HelperMethods.TryParseToInt(Reps.Text);
        TimeSpan ts = TimeSpan.FromSeconds(Convert.ToInt32(reps) * nrOfSecondsOfARep);
        double duration = Math.Round(ts.TotalMinutes, 2);
        Exercise exercise = chosenExercise.GetChosenExercise();
        double caloriesBurned = Math.Round(metValue * user.Weight * 0.0175 * duration);

        ExerciseSet exerciseSet = new()
        {
            Exercise = exercise,
            ChoosenWeight = weight,
            Repetitions = reps,
            Duration = duration,
            CaloriesBurned = caloriesBurned

        };
        if (exerciseSet.ChoosenWeight != 0 && exerciseSet.Repetitions != 0)
        {
            AddSetToProgram(exerciseSet);
            App.Current.MainPage.DisplayAlert("Success", "Set successfully created", "Continue");
        }

    }
    private void AddSetToProgram(ExerciseSet exerciseSet)
    {
        //TODO: lägga till antingen i en lista för att sen när man är klar skapa träningsprogrammet
        // eller någonstans tidigare i processen skapa ett program där man lägger till seten
        var trainingPrograms = Connections.Connection.TrainingProgramCollection();
        var usersProgram = trainingPrograms
            .AsQueryable()
            .Where(x => x.Person.Id == user.Id);

        //loggedInUser.GetLoggedInPerson().Programs.
    }
}