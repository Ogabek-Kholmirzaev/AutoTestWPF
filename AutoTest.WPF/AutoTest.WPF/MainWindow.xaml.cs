using System;
using System.Windows;
using AutoTest.WPF.Pages;

namespace AutoTest.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static MainWindow InstanceMainWindow;
        public MainWindow()
        {
            InitializeComponent();

            InstanceMainWindow = this;
            MainWindowFrame.Navigate(new MenuPage());
        }
    }
}
