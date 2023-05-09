using CommunityToolkit.Mvvm.Input;

using The49.Maui.BottomSheet.Views;

namespace The49.Maui.BottomSheet.ViewModels;

public partial class HomePageViewModel : BaseViewModel
{
    private BottomSheetPage bottomSheetPage;

    public Command BottomSheetButtonsHandlerCommand { get; }
    public HomePageViewModel()
    {
        BottomSheetButtonsHandlerCommand = new Command<string>(BottomSheetButtonsHandler);
    }

    public async Task OnPageAppearing()
    {
        Title = "Home Page";
    }

    public async Task OnPageDisappearing()
    {
        if (bottomSheetPage is not null) await bottomSheetPage.Dismiss();
    }

    #region RelayCommand - MainPageToolbarButtonTappedCommand
    [RelayCommand]
    private async void MainPageToolbarButtonTapped()
    {
        await ShowTipAsBottomSheet("Goto Help", "help", -1);
    }
    #endregion

    private async Task ShowTipAsBottomSheet(string buttonLabel, string cmdParam = "default", int displaySeconds = 0)
    {
        string tipTitle = "Welcome to My App!";
        string tipDescription = "This is a tip description text!";

        bottomSheetPage = new BottomSheetPage() { IsCancelable = (displaySeconds == 0), HasHandle = true };

        bottomSheetPage.BottomSheetSecondaryButton.Command = BottomSheetButtonsHandlerCommand;
        bottomSheetPage.BottomSheetSecondaryButton.CommandParameter = "dismiss";
        App.MergedResourcesDictionaries[2]["TipTitleFontAttribute"] = FontAttributes.Bold;

        bottomSheetPage.BottomSheetPrimaryButton.Command = BottomSheetButtonsHandlerCommand;
        bottomSheetPage.BottomSheetPrimaryButton.CommandParameter = cmdParam;

        bottomSheetPage.Detents = new DetentsCollection()
                {
                    new ContentDetent(),
                    new AnchorDetent { Anchor = bottomSheetPage.Divider }
                };

        App.MergedResourcesDictionaries[2]["TipTitle"] = tipTitle;
        App.MergedResourcesDictionaries[2]["TipDescription"] = tipDescription;

        App.MergedResourcesDictionaries[2]["IsBottomSheetPrimaryButtonVisible"] = true;
        App.MergedResourcesDictionaries[2]["BottomSheetPrimaryButtonLabel"] = buttonLabel;

        App.MergedResourcesDictionaries[2]["IsBottomSheetSecondaryButtonVisible"] = true;
        App.MergedResourcesDictionaries[2]["BottomSheetSecondaryButtonLabel"] = "dismiss";

        bottomSheetPage.Show(ViewPage.Window);

        if (displaySeconds > 0)
        {
            await Task.Delay(displaySeconds * 1000);
            await bottomSheetPage.Dismiss();
        }
    }

    private async void BottomSheetButtonsHandler(string param)
    {

        if (param == "help")
        {
            await Shell.Current.GoToAsync($"{nameof(HelpPage)}");
            await bottomSheetPage.Dismiss();
        }
        else if (param == "dismiss")
        {
            await bottomSheetPage.Dismiss();
        }
    }
}
