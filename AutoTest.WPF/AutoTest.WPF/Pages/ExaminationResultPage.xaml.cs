using System.Linq;
using System.Windows;
using System.Windows.Controls;
using AutoTest.WPF.Models;

namespace AutoTest.WPF.Pages
{
    /// <summary>
    /// Interaction logic for ExaminationResultPage.xaml
    /// </summary>
    public partial class ExaminationResultPage : Page
    {
        public ExaminationResultPage(Ticket ticket)
        {
            InitializeComponent();

            QuestionsCountTextBlock.Text = ticket.QuestionsCount.ToString();
            CorrectAnswersCountTextBlock.Text = ticket.CorrectAnswersCount.ToString();
            SelectedAnswersCountTextBlock.Text = ticket.SolvedQuestionsDictionary.Count.ToString();
        }

        private void MenuButtonClick(object sender, RoutedEventArgs e)
        {
            MainWindow.InstanceMainWindow.MainWindowFrame.Navigate(new MenuPage());
        }
    }
}
