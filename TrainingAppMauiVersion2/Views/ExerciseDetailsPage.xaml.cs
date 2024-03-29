using CommunityToolkit.Mvvm.Input;
using MongoDB.Driver;
using TrainingAppMauiVersion2.Models;
using TrainingAppMauiVersion2.NewFolder;
using TrainingAppMauiVersion2.Singletons;

namespace TrainingAppMauiVersion2.Views;

public partial class ExerciseDetailsPage : ContentPage
{
    LoggedInPerson loggedInUser = LoggedInPerson.GetInstansOfLoggedInPerson();
    NewTrainingProgram newTrainingProgram = NewTrainingProgram.GetInstansOfListOfSets();
    ChosenExercise chosenExercise = ChosenExercise.GetInstansOfChosenExercise();
    public ExerciseDetailsPage()
    {
        InitializeComponent();
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
            App.Current.MainPage.DisplayAlert("Fail", "Only numbers", "Try again");

        }

    }
    private void AddSetToProgram(ExerciseSet exerciseSet)
    {
        newTrainingProgram.AddSetToList(exerciseSet);

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