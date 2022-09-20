using AutoTest.WPF.Pages;
using System.Windows;
using AutoTest.WPF.Repositories;

namespace AutoTest.WPF
{
    public partial class MainWindow : Window
    {
        public QuestionsRepository QuestionsRepository;
        public TicketsRepository TicketsRepository;
        public static MainWindow InstanceMainWindow;
        public MainWindow()
        {
            InitializeComponent();
            InstanceMainWindow = this;

            QuestionsRepository = new QuestionsRepository();
            TicketsRepository = new TicketsRepository();

            MainWindowFrame.Navigate(new MenuPage());
        }
    }
}
