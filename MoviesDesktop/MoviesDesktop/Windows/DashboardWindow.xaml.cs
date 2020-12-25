using MoviesDesktop.Data;
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
using System.Linq;
using MoviesDesktop.Models;

namespace MoviesDesktop.Windows

{
    /// <summary>
    /// Interaction logic for DashboardWindow.xaml
    /// </summary>
    public partial class DashboardWindow : Window
        
    {
        private readonly MovieContext _context;
        private Movie _selectedMovie;
        public DashboardWindow()
        {
            InitializeComponent();
            _context = new MovieContext();
            FillCountry();
            FillMovies();
          
        }
        private void FillCountry()
        {
            CmbCountry.ItemsSource = _context.Countries.ToList();
        }
        private void FillMovies()
        {
            DgvMovies.ItemsSource = _context.Movies.ToList();
        }
        private bool Validation()
        {
            bool hasError = false;
            if (string.IsNullOrEmpty(TxtName.Text))
            {
                LblName.Foreground = new SolidColorBrush(Colors.Red);
                hasError = true;
            }
            else
            {
                LblName.Foreground = new SolidColorBrush(Colors.Green);
            }
            if (CmbCountry.SelectedItem == null)
            {
                LblCountry.Foreground = new SolidColorBrush(Colors.Red);
                hasError = true;
            }
            else
            {
                LblCountry.Foreground = new SolidColorBrush(Colors.Green);
            }
            if (CmbDate.SelectedDate == null)
            {
                LblDate.Foreground = new SolidColorBrush(Colors.Red);
                hasError = true;
            }
            else
            {
                LblDate.Foreground = new SolidColorBrush(Colors.Green);
            }
            return hasError;
        }
        private void Reset()
        {
            TxtName.Clear();
            CmbDate.SelectedDate = null;
            CmbCountry.SelectedItem = null;

            BtnCreate.Visibility = Visibility.Visible;
            BtnUpgrade.Visibility = Visibility.Hidden;
            BtnDelete.Visibility = Visibility.Hidden;
            FillMovies();
        }

        private void BtnCreate_Click(object sender, RoutedEventArgs e)
        {
            if (Validation())
            {
                MessageBox.Show("bos olan yerleri doldurmalısınız");
                return;
            }
            Movie movie = new Movie()
            {
                Name = TxtName.Text,
                ReleaseDate=(DateTime)CmbDate.SelectedDate,
                CountryId=(int)CmbCountry.SelectedValue
            };
            _context.Movies.Add(movie);
            _context.SaveChanges();
            Reset();
            MessageBox.Show("film daxil edildi");
        }

        private void DgvMovies_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DgvMovies.SelectedItem == null) return;
            _selectedMovie = (Movie)DgvMovies.SelectedItem;
            TxtName.Text = _selectedMovie.Name;
            CmbCountry.SelectedItem = _selectedMovie.CountryId;
            CmbDate.SelectedDate = _selectedMovie.ReleaseDate;
            BtnCreate.Visibility = Visibility.Hidden;
            BtnUpgrade.Visibility = Visibility.Visible;
            BtnDelete.Visibility = Visibility.Visible;
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult a = MessageBox.Show("Are you sure to delete selected item?", MessageBoxButton.OKCancel.ToString());
            if (MessageBoxResult.OK == a)
            {
                _context.Movies.Remove(_selectedMovie);
                _context.SaveChanges();
                Reset();
            }
        }

        private void BtnUpgrade_Click(object sender, RoutedEventArgs e)
        {
            if (Validation())
            {
                MessageBox.Show("* olan yerleri doldurmalısınız");
                return;
            }

            _selectedMovie.Name = TxtName.Text;
            _selectedMovie.ReleaseDate = (DateTime)CmbDate.SelectedDate;
            _selectedMovie.CountryId = (int)CmbCountry.SelectedValue;
            _context.SaveChanges();
            Reset();
        }
       
    }
}
