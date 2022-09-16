using AutoTest.WPF.Pages;
using System.Windows;

namespace AutoTest.WPF
{
    public partial class MainWindow : Window
    {
        public static MainWindow InstanceMainWindow = new MainWindow();
        public MainWindow()
        {
            InitializeComponent();

            InstanceMainWindow = this;
            MainWindowFrame.Navigate(new MenuPage());
        }
    }
}
