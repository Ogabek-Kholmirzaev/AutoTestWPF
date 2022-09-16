using System.Windows;
using System.Windows.Controls;

namespace AutoTest.WPF.Pages
{
    public partial class MenuPage : Page
    {
        public MenuPage()
        {
            InitializeComponent();
        }

        private void TicketsButton_OnClick(object sender, RoutedEventArgs e)
        {
            MainWindow.InstanceMainWindow.MainWindowFrame.Navigate(new TicketsPage());
        }
        private void ExaminationButton_OnClick(object sender, RoutedEventArgs e)
        {
            MainWindow.InstanceMainWindow.MainWindowFrame.Navigate(new ExaminationPage());
        }
    }
}
