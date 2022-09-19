using System.Windows;
using System.Windows.Controls;

namespace AutoTest.WPF.Pages
{
    /// <summary>
    /// Interaction logic for ExaminationResultPage.xaml
    /// </summary>
    public partial class ExaminationResultPage : Page
    {
        public ExaminationResultPage(int questionsCount, int correctAnswers)
        {
            InitializeComponent();

            QuestionsCountTextBlock.Text = questionsCount.ToString();
            CorrectAnswersCountTextBlock.Text = correctAnswers.ToString();
        }

        private void MenuButtonClick(object sender, RoutedEventArgs e)
        {
            MainWindow.InstanceMainWindow.MainWindowFrame.Navigate(new MenuPage());
        }
    }
}
