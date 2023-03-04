using TrainingAppMauiVersion2.SessionData;
using TrainingAppMauiVersion2.Singletons;
using TrainingAppMauiVersion2.ViewModels;

namespace TrainingAppMauiVersion2.Views;

public partial class CreateTrainingProgramPage : ContentPage
{
    bool pageStarted;
    ViewModels.CreateTrainingProgramViewModel vm = new ViewModels.CreateTrainingProgramViewModel();

    public CreateTrainingProgramPage()
	{
		InitializeComponent();
        BindingContext = vm;
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();
        if (!pageStarted)
        {
            vm.AddMuscles();
            pageStarted = true;
        }
    }
    private async void OnClickedChooseExercise(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ChooseExercisePage());
    }
    
    private async void ReloadPage(object sender, EventArgs e)
    {
        //Navigation.PopAsync();
        await Navigation.PushAsync(new CreateTrainingProgramPage());

    }

}