namespace The49.Maui.BottomSheet.Views;

public partial class HelpPage : ContentPage
{
    private BottomSheetPage bottomSheetPage;

    public HelpPage()
	{
		InitializeComponent();
	}

    private async void ToolbarItem_Clicked(object sender, EventArgs e)
    {
        await ShowTipAsBottomSheet("Goto Home", "home", -1);
    }

    private async Task ShowTipAsBottomSheet(string buttonLabel, string cmdParam = "default", int displaySeconds = 0)
    {
        string tipTitle = "Welcome to My App!";
        string tipDescription = "This is tip description!";

        bottomSheetPage = new BottomSheetPage() { IsCancelable = (displaySeconds == 0), HasHandle = true };
        bottomSheetPage.Detents = new DetentsCollection()
                {
                    new ContentDetent(),
                    new AnchorDetent { Anchor = bottomSheetPage.Divider }
                };

        App.MergedResourcesDictionaries[2]["TipTitle"] = tipTitle;
        App.MergedResourcesDictionaries[2]["TipDescription"] = tipDescription;
        App.MergedResourcesDictionaries[2]["IsBottomSheetPrimaryButtonVisible"] = true;
        App.MergedResourcesDictionaries[2]["BottomSheetPrimaryButtonLabel"] = buttonLabel;
        App.MergedResourcesDictionaries[2]["IsBottomSheetSecondaryButtonVisible"] = false;

        bottomSheetPage.BottomSheetPrimaryButton.Command = new Command<string>(async (param) =>
        {
            if (param?.ToString() == "home")
            {
                await Shell.Current.GoToAsync($"//{nameof(HomePage)}");
            }
            await bottomSheetPage.Dismiss();
        });

        bottomSheetPage.BottomSheetPrimaryButton.CommandParameter = cmdParam;

        bottomSheetPage.Show(Window);

        if (displaySeconds > 0)
        {
            await Task.Delay(displaySeconds * 1000);
            await bottomSheetPage.Dismiss();
        }
    }

}
