using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using SQLBEBEBEEBE.ViewModel;

namespace SQLBEBEBEEBE
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }

    }
}
