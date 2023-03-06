using TrainingAppMauiVersion2.Views;

namespace TrainingAppMauiVersion2;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		//MainPage = new AppShell();
		MainPage = new NavigationPage(new MainPage()); // TODO: så att jag kan ta bort bakåtknappen. skapa egna överallt
	}
}
