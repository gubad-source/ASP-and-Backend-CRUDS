using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MoviesDesktop.Windows
{
    /// <summary>
    /// Interaction logic for MoviesWindow.xaml
    /// </summary>
    public partial class MoviesWindow : Window
    {
        public MoviesWindow()
        {
            InitializeComponent();
        }

        private void MoviesBtn_Click(object sender, RoutedEventArgs e)
        {
            DashboardWindow Dw = new DashboardWindow();
            Dw.ShowDialog();
        }
    }
}
