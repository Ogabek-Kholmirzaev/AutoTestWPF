using AutoTest.WPF.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace AutoTest.WPF.Pages
{
    public partial class ExaminationPage : Page
    {
        private bool isTicketsPage { get; set; }
        public Ticket CurrentTicket { get; set; }
        public int currentQuestionIndex = 0;
        public ExaminationPage(int? clickedTicketIndex = null)
        {
            InitializeComponent();

            if (clickedTicketIndex != null)
            {
                CreateTicket(clickedTicketIndex.Value);

                TitleLabel.Content = $"Ticket{clickedTicketIndex + 1}";
                isTicketsPage = true;
                MenuOrTicketsButton.Content = "Close";
            }
            else
            {
                var randomTicketIndex = new Random().Next(0, MainWindow.InstanceMainWindow.QuestionsRepository.TicketsCount());
                CreateTicket(randomTicketIndex);

                TitleLabel.Content = $"Ticket{randomTicketIndex + 1}";
            }

            GenerateTicketIndexesButton();
            ShowQuestion();
        }

        private void GenerateTicketIndexesButton()
        {
            var questions = CurrentTicket.Questions;

            for (int i = 0; i < questions.Count; i++)
            {
                var button = new Button();
                button.Height = 40;
                button.Width = 40;
                button.Content = i + 1;
                button.Tag = i;
                button.Click += TicketQuestionsIndexPanelButtonClick;

                TicketQuestionsIndexPanel.Children.Add(button);
            }
        }

        private void TicketQuestionsIndexPanelButtonClick(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            currentQuestionIndex = (int) button!.Tag;

            ShowQuestion();
        }

        private void CreateTicket(int ticketIndex)
        {
            CurrentTicket = new Ticket(ticketIndex, MainWindow.InstanceMainWindow.QuestionsRepository.GetQuestionsRange(ticketIndex));
        }

        private void ShowQuestion()
        {
            var question = CurrentTicket.Questions[currentQuestionIndex];

            QuestionTextBlock.Text = $"{currentQuestionIndex + 1}. {question.Question}";

            SetQuestionImage(question.Media);
            GenerateChoiceButton(question.Choices);
        }

        private void SetQuestionImage(Media media)
        {
            if (media.Exist)
                QuestionImage.Source =
                    new BitmapImage(new Uri(Path.Combine(Environment.CurrentDirectory, "Images", $"{media.Name}.png")));
            else
                QuestionImage.Source = new BitmapImage(new Uri(Path.Combine(Environment.CurrentDirectory, "Images", $"noimage.png")));
        }
        private void GenerateChoiceButton(List<Choice> choices)
        {
            ChoicesPanel.Children.Clear();

            for (int i = 0; i < choices.Count; i++)
            {
                var button = new Button();
                button.MinHeight = 30;
                button.FontSize = 16;
                button.Margin = new Thickness(15, 0, 15, 5);
                button.Padding = new Thickness(7, 5, 7, 5);
                button.Tag = choices[i];
                button.Click += ChoiceButton_Clicked;

                var textBlock = new TextBlock();
                textBlock.Text = choices[i].Text;
                textBlock.TextWrapping = TextWrapping.Wrap;

                button.Content = textBlock;

                ChoicesPanel.Children.Add(button);
            }
        }

        private void ChoiceButton_Clicked(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var choice = (Choice)button!.Tag;

            if (choice.Answer)
            {
                CurrentTicket.CorrectAnswersCount++;
                button.Background = new SolidColorBrush(Colors.LightGreen);
            }
            else
            {
                button.Background = new SolidColorBrush(Colors.Red);
            }

            CurrentTicket.SolvedQuestionsList.Add(currentQuestionIndex);

            if (CurrentTicket.SolvedQuestionsList.Count == CurrentTicket.QuestionsCount)
            {
                MainWindow.InstanceMainWindow.MainWindowFrame.Navigate(new ExaminationResultPage(CurrentTicket.QuestionsCount, CurrentTicket.CorrectAnswersCount));
            }
        }

        private void MenuButtonClick(object sender, RoutedEventArgs e)
        {
            if (!isTicketsPage)
                MainWindow.InstanceMainWindow.MainWindowFrame.Navigate(new MenuPage());
            else
                MainWindow.InstanceMainWindow.MainWindowFrame.Navigate(new TicketsPage());
        }
    }
}