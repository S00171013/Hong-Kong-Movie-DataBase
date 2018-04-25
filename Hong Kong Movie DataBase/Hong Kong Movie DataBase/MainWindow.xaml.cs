using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        Film movieTest;

        // Set up observable collection of films to display.
        public ObservableCollection<Film> filmographyToDisplay = new ObservableCollection<Film>();

        #region Checklist
        // Unfinished

        // Classes/Objects
        // JSON - Will be used to add reviews. Will write to file. Or watchlist feature.                  
        // Exception Handling - Not yet. Maybe for JSON file.      
        // Additional Windows - May use additional windows for reviews or watchlist.


        // In Progress.
        // Ensure database is added to github properly.
        // Ensure films from database display properly.
        // Figure out table relationships.

        // Observable Collection - Used for film listbox. Will have to ensure a list from a query can be successfully added to the observable colection.

        // Finished

        // Hand coded XAML - not drag and drop - Done.
        // Event Handling - Done.
        // Images - Done
        // Styles - Done.
        // LINQ - connecting to a database - Done.
        // Data Templates - Must have DT for film listbox. - Display Year, Title, Director - Done. Could fix year.
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

            #region Rough Test
           // movieTest = new Film();
           // movieTest.Title = "Snake in the Eagle's Shadow";
           // movieTest.ReleaseDate = new DateTime(1996, 3, 24);
           // movieTest.Director = "Yuen Woo-Ping";
           // movieTest.RunningTime = "98 Mins";
           // movieTest.PosterImage = "https://ia.media-imdb.com/images/M/MV5BODQyNTYxMDktODYwMi00MWY4LWFiZWYtODRjOWVhYWJiMzY2XkEyXkFqcGdeQXVyMzU4Nzk4MDI@._V1_UX182_CR0,0,182,268_AL_.jpg";

           // lblName.Content = movieTest.Title;
           // lblYear.Content = movieTest.ReleaseDate;
           // lblDirector.Content = movieTest.Director;
           // lblRunningTime.Content = movieTest.RunningTime;

           // Display film image.
           //imgMoviePoster.Source = new BitmapImage(new Uri(movieTest.PosterImage));
            #endregion

            //filmographyToDisplay.Add(movieTest);
            //lbxFilmography.ItemsSource = filmographyToDisplay;

            // Display actor bio in textblock. Should add to DB Model.

            // Display rough list of films.
            var query = from f in db.Films
                        orderby f.ReleaseDate
                        select f.Title;

            lbxFilmography.ItemsSource = query.ToList();
        }

        private void lbxFilmography_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {                                             
            //// Get selected film.
            //Film selectedFilm = lbxFilmography.SelectedItem as Film;

            //if (selectedFilm != null)
            //{
            //    // Display film info.
            //    lblName.Content = selectedFilm.Title;
            //    lblYear.Content = selectedFilm.ReleaseDate;
            //    lblDirector.Content = selectedFilm.Director;
            //    lblRunningTime.Content = selectedFilm.RunningTime;

            //    // Display film image.
            //    imgMoviePoster.Source = new BitmapImage(new Uri(selectedFilm.PosterImage, UriKind.Relative));
            //}
        }
    }
}
