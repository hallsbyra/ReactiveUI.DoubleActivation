using System.Reactive.Disposables;

namespace ReactiveUI.DoubleActivation
{
    public class TestViewModel : ReactiveObject, IActivatableViewModel
    {
        public ViewModelActivator Activator { get; }

        public TestViewModel()
        {
            Activator = new ViewModelActivator();
            this.WhenActivated(disp =>
            {
                MainWindow.Log("ViewModel - Activate");
                Disposable.Create(() => MainWindow.Log("ViewModel - Deactivate")).DisposeWith(disp);
            });
        }
    }
}
