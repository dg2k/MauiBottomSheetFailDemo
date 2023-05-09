using CommunityToolkit.Mvvm.ComponentModel;

namespace The49.Maui.BottomSheet.ViewModels
{
    public partial class BaseViewModel : ObservableObject
    {
        public Page ViewPage { get; set; }


        [ObservableProperty]
        string title = string.Empty;
    }
}
