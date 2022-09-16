using System.Windows;
using System.Windows.Controls;

namespace AutoTest.WPF.Pages
{
    public partial class ExaminationPage : Page
    {
        private bool isTicketsPage { get; set; }
        public ExaminationPage(int? clickedTicketIndex = null)
        {
            InitializeComponent();
            GenerateChoiceButton();

            if (clickedTicketIndex != null)
            {
                TitleLabel.Content = $"Ticket{clickedTicketIndex + 1}";
                isTicketsPage = true;
                MenuOrTicketsButton.Content = "Close";
            }
        }

        private void GenerateChoiceButton()
        {
            QuestionTextLabel.Content = "1 - savol?";

            for (int i = 0; i < 7; i++)
            {
                var button = new Button();
                button.Width = 300;
                button.Height = 50;
                button.FontSize = 18;
                button.Margin = new Thickness(0, 5, 0, 5);
                button.Content = $"Variant{i + 1}";
                button.Tag = i;
                button.Click += ChoiceButton_Clicked;

                ChoicesPanel.Children.Add(button);
            }
        }

        private void ChoiceButton_Clicked(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            MessageBox.Show($"Variant{(int)button!.Tag + 1} Clicked");
        }

        private void MenuButtonClick(object sender, RoutedEventArgs e)
        {
            if(!isTicketsPage)
                MainWindow.InstanceMainWindow.MainWindowFrame.Navigate(new MenuPage());
            else
                MainWindow.InstanceMainWindow.MainWindowFrame.Navigate(new TicketsPage());
        }
    }
}
