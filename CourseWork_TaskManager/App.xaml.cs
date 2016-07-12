using CourseWork_TaskManager.Models;
using CourseWork_TaskManager.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace CourseWork_TaskManager
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void OnStartup(object sender, StartupEventArgs e)
        {
            MainView view = new MainView();
            //MainViewModel viewModel = new ViewModels.MainViewModel(books);
            //view.DataContext = viewModel;
            //view.Show();

            view.DataContext = new ProcessesViewModel(new ProcessesModel());
            view.Show();
        }
    }
}
