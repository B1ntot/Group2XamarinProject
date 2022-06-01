using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Group2XamarinProject
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GameListPage : ContentPage
    {
        class Game
        {
            public Game(string name, DateTime releaseDate, Color color)
            {
                this.gameName = name;
                this.releaseDate = releaseDate;
                this.color = color;
            }

            //private int gameID { get; set; }
            public string gameName { private set; get; }
            //public string gameDesc { get; set; }
            //public string gameDev { get; set; }
            //public string gamePub { get; set; }
            public DateTime releaseDate { private set; get; }
            public Color color { private set; get; }
            //public double gamePrice { get; set; }
        }

        public GameListPage()
        {

            Label header = new Label
            {
                Text = "Games List",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                HorizontalOptions = LayoutOptions.Center
            };

            // Define some data.
            List<Game> games = new List<Game>
            {
                new Game("Game 1", new DateTime(2006, 1, 15), Color.Aqua),
                new Game("Game 2", new DateTime(2008, 2, 20), Color.Black),
                // ...etc.,...
                new Game("Game 3", new DateTime(2014, 1, 10), Color.Purple),
                new Game("Game 4", new DateTime(2019, 2, 5), Color.Red)
            };

            SearchBar searchBar = new SearchBar { Placeholder = "Search items..." };

            // Create the ListView.
            ListView listView = new ListView
            {
                // Source of data items.
                ItemsSource = games,

                // Define template for displaying each item.
                // (Argument of DataTemplate constructor is called for 
                //      each item; it must return a Cell derivative.)
                ItemTemplate = new DataTemplate(() =>
                {
                    // Create views with bindings for displaying each property.
                    Label nameLabel = new Label();
                    nameLabel.SetBinding(Label.TextProperty, "gameName");

                    Label releaseDateLabel = new Label();
                    releaseDateLabel.SetBinding(Label.TextProperty,
                        new Binding("releaseDate", BindingMode.OneWay,
                            null, null, "Released {0:d}"));

                    BoxView boxView = new BoxView();
                    boxView.SetBinding(BoxView.ColorProperty, "color");

                    // Return an assembled ViewCell.
                    return new ViewCell
                    {
                        View = new StackLayout
                        {
                            Padding = new Thickness(0, 5),
                            Orientation = StackOrientation.Horizontal,
                            Children =
                            {
                                    boxView,
                                    new StackLayout
                                    {
                                        VerticalOptions = LayoutOptions.Center,
                                        Spacing = 0,
                                        Children =
                                        {
                                            nameLabel,
                                            releaseDateLabel
                                        }
                                        }
                            }
                        }
                    };
                })
            };

            // Accomodate iPhone status bar.
            this.Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 5);

            // Build the page.
            this.Content = new StackLayout
            {
                Children =
                {
                    header,
                    searchBar,
                    listView
                }
            };

            InitializeComponent();

        }
    }
}