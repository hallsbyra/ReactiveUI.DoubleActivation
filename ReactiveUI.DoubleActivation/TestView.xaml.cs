using System.Reactive.Disposables;

namespace ReactiveUI.DoubleActivation
{
    public partial class TestView : ReactiveUserControl<TestViewModel>
    {
        public TestView()
        {
            InitializeComponent();

            this.WhenActivated(disp =>
            {
                MainWindow.Log("View - Activate");
                Disposable.Create(() => MainWindow.Log("View - Deactivate")).DisposeWith(disp);
            });
        }
    }
}
