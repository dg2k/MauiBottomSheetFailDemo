
using The49.Maui.BottomSheet;

namespace The49.Maui.BottomSheet.Views;

public partial class BottomSheetPage : BottomSheet
{
	public BottomSheetPage()
	{
		InitializeComponent();
	}

    public VisualElement Divider => this.DividerBoxView;
    public Button BottomSheetPrimaryButton => this.BottomSheetPrimaryBtn;
    public Button BottomSheetSecondaryButton => this.BottomSheetSecondaryBtn;
}