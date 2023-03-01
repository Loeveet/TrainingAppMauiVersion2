using TrainingAppMauiVersion2.Views;

namespace TrainingAppMauiVersion2;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
	}
}
