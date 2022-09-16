using System.Windows;
using System.Windows.Controls;

namespace AutoTest.WPF.Pages
{
    /// <summary>
    /// Interaction logic for TicketsPage.xaml
    /// </summary>
    public partial class TicketsPage : Page
    {
        public TicketsPage()
        {
            InitializeComponent();
            GenerateTicketsButton();
        }

        private void GenerateTicketsButton()
        {
            for (int i = 0; i < 35; i++)
            {
                var button = new Button();
                button.Width = 300;
                button.Height = 50;
                button.FontSize = 18;
                button.Margin = new Thickness(0, 5, 0, 5);
                button.Content = $"Ticket{i + 1}";
                button.Tag = i;
                button.Click += TicketsButton_Click;

                TicketsPanel.Children.Add(button);
            }
        }

        private void TicketsButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var tickesIndex = (int)button!.Tag;
            
            // MessageBox.Show($"Ticket{tickesIndex + 1} clicked");

            MainWindow.InstanceMainWindow.MainWindowFrame.Navigate(new ExaminationPage(tickesIndex));
        }

        private void MenuButtonClick(object sender, RoutedEventArgs e)
        {
            MainWindow.InstanceMainWindow.MainWindowFrame.Navigate(new MenuPage());
        }
    }
}
