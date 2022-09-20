using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace AutoTest.WPF.Pages
{
    public partial class MenuPage : Page
    {
        public MenuPage()
        {
            InitializeComponent();

            QuestionsResultLabel.Content = $"Questions Result:  {CorrectAnswers()}/{MainWindow.InstanceMainWindow.QuestionsRepository.Questions.Count}";
            TicketsResultLabel.Content = $"Tickets Result:  {CompletedTickets()}/{MainWindow.InstanceMainWindow.QuestionsRepository.TicketsCount()}";
        }

        private int CompletedTickets()
        {
            return MainWindow.InstanceMainWindow.TicketsRepository.TicketsList.Count(ticket => ticket.QuestionsCount == ticket.SolvedQuestionsDictionary.Count);
        }

        private int CorrectAnswers()
        {
            return MainWindow.InstanceMainWindow.TicketsRepository.TicketsList.Sum(ticket => ticket.CorrectAnswersCount);
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
