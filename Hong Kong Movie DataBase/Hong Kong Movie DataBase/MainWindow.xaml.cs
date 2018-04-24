using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Hong_Kong_Movie_DataBase
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Checklist
        // Unfinished

        // Classes/Objects
        // JSON - Will be used to add reviews. Will write to file. Or watchlist feature.
        // Observable Collection - Used for film listbox?      
        // Data Templates - Must have DT for film listbox. - Display Title, year, director. Age rating instead?
        // Exception Handling - Not yet. Maybe for JSON file.      
        // Additional Windows - May use additional windows for reviews or watchlist.


        // Finished

        // Hand coded XAML - not drag and drop - Done.
        // Event Handling - Done.
        // Images - Done
        // Styles - Done?
        // LINQ - connecting to a database - Done.
        #endregion

        // Set up database.
        HKMoviesContainer db = new HKMoviesContainer();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnActor_Click(object sender, RoutedEventArgs e)
        {
            // Get button clicked.
            Button clickedButton = sender as Button;

            // Get button content test.
            txtBlkDescription.Text = clickedButton.Content.ToString();

            // Display actor image.
            imgActor.Source = new BitmapImage(new Uri("Actor Images/"+clickedButton.Content.ToString()+".png", UriKind.Relative));

            // Display actor bio in textblock. Should add to DB Model.

            // Display rough list of films.
            var query = from f in db.Films
                        orderby f.ReleaseDate
                        select f.Title;

            lbxFilmography.ItemsSource = query.ToList();
        }

        private void lbxFilmography_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Get selected film.
            Film selectedFilm = lbxFilmography.SelectedItem as Film;

            if (selectedFilm != null)
            {
                // Display film info.
                lblName.Content = selectedFilm.Title;
                lblYear.Content = selectedFilm.ReleaseDate;
                lblDirector.Content = selectedFilm.Director;
                lblRunningTime.Content = selectedFilm.RunningTime;

                // Display film image.
                imgMoviePoster.Source = new BitmapImage(new Uri(selectedFilm.PosterImage, UriKind.Relative));
            }
        }
    }
}
