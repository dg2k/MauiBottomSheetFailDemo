using The49.Maui.BottomSheet.Views;

namespace The49.Maui.BottomSheet;

public partial class App : Application
{
    public static List<ResourceDictionary> MergedResourcesDictionaries { get; set; }

    public App()
	{
		InitializeComponent();

		MainPage = new AppShell(); //    new NavigationPage(new MainPage());
	}
}
