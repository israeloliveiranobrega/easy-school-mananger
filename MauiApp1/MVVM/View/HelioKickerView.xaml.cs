using MauiApp1.MVVM.ViewModel;

namespace MauiApp1.MVVM.View;

public partial class HelioKickerView : ContentPage
{
	public HelioKickerView(HelioKickerViewModel helioKickerViewModel)
	{
		InitializeComponent();
		 BindingContext = helioKickerViewModel;
    }
}