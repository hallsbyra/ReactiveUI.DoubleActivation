using Splat;
using System;
using System.Reflection;
using System.Windows;

namespace ReactiveUI.DoubleActivation
{
    public partial class MainWindow : Window
    {
        private static MainWindow instance = null;

        public MainWindow()
        {
            instance = this;
            Locator.CurrentMutable.RegisterViewsForViewModels(Assembly.GetCallingAssembly());
            Locator.CurrentMutable.Register(() => new TestView(), typeof(IViewFor<TestViewModel>));
            InitializeComponent();
        }

        private void Show_Click(object sender, RoutedEventArgs e) =>
            viewModelViewHost.ViewModel = new TestViewModel();

        private void Hide_Click(object sender, RoutedEventArgs e) =>
            viewModelViewHost.ViewModel = null;

        public static void Log(string log) =>
            instance.log.Text += log + Environment.NewLine;
    }
}
