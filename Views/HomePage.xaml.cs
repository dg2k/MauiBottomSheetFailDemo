using The49.Maui.BottomSheet.ViewModels;

namespace The49.Maui.BottomSheet.Views;

public partial class HomePage : ContentPage
{
    private readonly HomePageViewModel viewModel;
    public HomePage(HomePageViewModel vm)
    {
        InitializeComponent();
        BindingContext = viewModel = vm;
        vm.ViewPage = this;

        App.MergedResourcesDictionaries = Application.Current.Resources.MergedDictionaries.ToList();
    }
    protected async override void OnAppearing()
    {
        base.OnAppearing();

        await viewModel.OnPageAppearing();

    }


    protected async override void OnDisappearing()
    {
        base.OnDisappearing();

        await viewModel.OnPageDisappearing();
    }
}