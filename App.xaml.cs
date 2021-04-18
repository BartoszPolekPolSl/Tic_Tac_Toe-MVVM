using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Tic_Tac_Toe
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static void ChangeWindow()
        {
            var startWindow = App.Current.MainWindow;
            var mainWindow = new MainWindow();
            mainWindow.Show();
            App.Current.MainWindow = mainWindow;
            startWindow.Close();
        }
        public static void NewGame()
        {
            var oldWindow = App.Current.MainWindow;
            var startWindow = new View.StartWindow();
            startWindow.Show();
            App.Current.MainWindow = startWindow;
            oldWindow.Close();

        }
    }
}
