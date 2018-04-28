using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Newtonsoft.Json;

namespace Hong_Kong_Movie_DataBase
{
    /// <summary>
    /// Interaction logic for Watchlist.xaml
    /// </summary>
    public partial class Watchlist : Window
    {
        // Set up OC for films on watchlist.
        public ObservableCollection<Film> watchlistFilms = new ObservableCollection<Film>();

        // JSON Variables.
        string json;
        string jsonR;

        public Watchlist()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                // Load the films already added to the watchlist.
                StreamReader r = new StreamReader("Watchlist.json");

                // Read the JSON file.
                jsonR = r.ReadToEnd();
                r.Dispose();

                // Load in the new watchlist.
                watchlistFilms = JsonConvert.DeserializeObject<ObservableCollection<Film>>(jsonR);
            }
            catch(FileNotFoundException fnfE)
            {
                MessageBox.Show("No existing watchlist data found.");
            }
            
            // Update listbox.
            lbxWatchlist.ItemsSource = watchlistFilms;
        }

        private void lbxWatchlist_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //// Get selected film.
            Film selectedFilm = lbxWatchlist.SelectedItem as Film;

            if (selectedFilm != null)
            {
                // Display film info.
                lblWName.Content = selectedFilm.Title;
                lblWReleaseDate.Content = selectedFilm.ReleaseDate;
                lblWDirector.Content = selectedFilm.Director;
                lblWRunningTime.Content = selectedFilm.RunningTime;

                // Display film image.
                imgWMoviePoster.Source = new BitmapImage(new Uri(selectedFilm.PosterImage));

                // Un-hide the "Remove Film" button.
                btnRemoveFilm.Visibility = Visibility.Visible;
            }
        }

        private void btnSaveWatchlist_Click(object sender, RoutedEventArgs e)
        {
            // Create Json string.
            json = JsonConvert.SerializeObject(watchlistFilms, Formatting.Indented);

            // Write to the file.
            using (StreamWriter w = new StreamWriter(@"Watchlist.json"))
            {
                w.WriteLine(json);
            }
        }

        private void btnRemoveFilm_Click(object sender, RoutedEventArgs e)
        {
            // Get selected film.
            Film selectedFilm = lbxWatchlist.SelectedItem as Film;

            // Rwemove the currently selected film.
            if(selectedFilm != null)
            {
                watchlistFilms.Remove(selectedFilm);
            }
        }

        private void btnReturn_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }
        
    }
}
