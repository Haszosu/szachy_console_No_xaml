using System.Diagnostics;
using System.Reflection;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Documents.Serialization;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace szachy_console_No_xaml
{
    public static class piece
    {
        public static List<Button> moving_buttons = new List<Button>();
        public static Button btnCheck = new Button();
    

    public static Button piece_creation(int Width, int WP)   //width of image and later used as a paramter to BitMapToImage function, WP - which piece was choosen
        {
            Button piece1 = new Button();   //creates button
            Image image1 = new Image();     //creates image

            image1.Width = Width;   //sets size of image
            image1.Height = Width;
            string url = "";

            switch (WP) //chosing with grapic file is the choosen one
            { 
                case 1:
                    url = @"E:\WPF_Game\szachy_console_No_xaml\NewFolder\piece1.png";
                    break;
                case 2:
                    url = @"E:\WPF_Game\szachy_console_No_xaml\NewFolder\piece2.png";
                    break;
                case 3:
                    url = @"E:\WPF_Game\szachy_console_No_xaml\NewFolder\piece3.png";
                    break;
            }
            image1.Source = BitMapToImage(Width, url);    //function call BitMapToImage

            piece1.Content = image1;    //ets image1 as a content to button creating immage button
            piece1.BorderThickness = new Thickness(0);  //delete border of button so its less visible
            piece1.Background = new SolidColorBrush(Colors.Transparent);    //changes color of the button to transperent so its less visible
            piece1.Uid = Convert.ToString(WP);
            piece1.Click += new RoutedEventHandler(Gneration_of_movment);

            return piece1;  //returns created image button with piece.png image
        }
        
        private static void Gneration_of_movment(object sender, RoutedEventArgs e)
        {
            Button SenderButton = sender as Button;
            btnCheck = SenderButton;
            Console.WriteLine("row: "+ Grid.GetRow(SenderButton) +" collumn: "+ Grid.GetColumn(SenderButton));
            switch (SenderButton.Uid) 
            {
                case ("1"):
                    GOM_one( ref SenderButton);
                    break;
                case ("2"):
                    break;
                case ("3"):
                    break;
            }
        }

        private static void GOM_one(ref Button Piece_to_move)
        {
            Grid Fgrid = Piece_to_move.Parent as Grid;
            Console.WriteLine( Fgrid.RowDefinitions.Count()+" * "+ Fgrid.ColumnDefinitions.Count());
            if(Grid.GetColumn(Piece_to_move) > 0 ){Moving_button_creation(ref Fgrid, Grid.GetRow(Piece_to_move), Grid.GetColumn(Piece_to_move) -1); }
            if (Grid.GetRow(Piece_to_move) > 0) { Moving_button_creation(ref Fgrid, Grid.GetRow(Piece_to_move)-1, Grid.GetColumn(Piece_to_move)); }
            if (Grid.GetColumn(Piece_to_move) < Fgrid.ColumnDefinitions.Count()-1) { Moving_button_creation(ref Fgrid, Grid.GetRow(Piece_to_move), Grid.GetColumn(Piece_to_move) +1); }
            if (Grid.GetRow(Piece_to_move) < Fgrid.RowDefinitions.Count() - 1) { Moving_button_creation(ref Fgrid, Grid.GetRow(Piece_to_move) + 1, Grid.GetColumn(Piece_to_move)); }
        }

        private static void Moving_button_creation(ref Grid parentGrid ,int row, int collumn)
        {
            moving_buttons.Add(creating_a_very_specific_button());

            Grid.SetRow(moving_buttons.Last(), row);
            Grid.SetColumn(moving_buttons.Last(), collumn);

            Console.WriteLine("New Button row: " + row + " collumn: "+ collumn);


            parentGrid.Children.Add(moving_buttons.Last());
        }

        private static Button creating_a_very_specific_button()
        {
            Button creating_button = new Button();
            creating_button.Click += new RoutedEventHandler(Move_it_finnaly);
            return creating_button;
        }


        private static void Move_it_finnaly(object sender, RoutedEventArgs e) //wtf fuction
        {
            Button btn = sender as Button;
            Grid parentGrid  = btn.Parent as Grid;
            Grid.SetRow(btnCheck, Grid.GetRow(btn));
            Grid.SetColumn(btnCheck, Grid.GetColumn(btn));

            for(int i = 0; i < moving_buttons.Count; i++) { parentGrid.Children.Remove(moving_buttons[i]); }
            
        }
            
        public static BitmapImage BitMapToImage(int width,string url)   //width use to set size of BitmapImage and rl to set addres of myBitmapImage
        {
            BitmapImage myBitmapImage = new BitmapImage();  //create new BitmapImage

            myBitmapImage.BeginInit();  //signals the star of BitmapImage inicialization
            myBitmapImage.UriSource = new Uri(url); //sets urisource of BitmapImage to url value

            myBitmapImage.DecodePixelWidth = width; //decodes image to set value
            myBitmapImage.DecodePixelHeight = width;
            myBitmapImage.EndInit();    //signals the end of BitmapImage inicialization

            return myBitmapImage;   //returns BitmapImage
        }

        public static void SetRandConForButtonGrid(ref Button btn, int row, int col)
        {
            Grid.SetRow(btn, row);
            Grid.SetColumn(btn, col);
        }

    }
}
