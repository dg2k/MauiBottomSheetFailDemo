using The49.Maui.BottomSheet.Views;

namespace The49.Maui.BottomSheet;

public partial class AppShell : Shell
{
    public static AppShell Instance { get; private set; }
    public AppShell()
	{
		InitializeComponent();
        Instance = this;

        Routing.RegisterRoute($"{nameof(HomePage)}", typeof(HomePage));
        Routing.RegisterRoute($"{nameof(HelpPage)}", typeof(HelpPage));
    }
}
