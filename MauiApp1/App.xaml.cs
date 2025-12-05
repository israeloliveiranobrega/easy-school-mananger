using MauiApp1.MVVM.View;
using MauiApp1.MVVM.ViewModel;

namespace MauiApp1
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            var vm = MauiProgram.ServiceProvider.GetRequiredService<HelioKickerView>();
            return new Window(new NavigationPage(vm));
        }
    }
}