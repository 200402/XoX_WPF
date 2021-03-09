using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace XoX_attempt_1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Game game;
        Rectangle[,] all_rectangle;
        public MainWindow()
        {
            InitializeComponent();
            game = new Game();
            all_rectangle = new Rectangle[,] { { up_left, up_center, up_right, },
                                               { middle_left, middle_center, middle_right },
                                               { down_left, down_center, down_right} };
        }

        private void Rectangle_MouseEnter(object sender, MouseEventArgs e)
        {
            Rectangle rect = sender as Rectangle;
            int[] position = picture_position(rect.Name);
            if (game.Place_is_free(position[0], position[1]))
            {
                string wayImage;
                if (game.Is_turn_zero())
                    wayImage = @"Image\O-image-transparent.jpg";
                else
                    wayImage = @"Image\X-image-transparent.jpg";
                rect.Fill = new ImageBrush
                {
                    ImageSource = new BitmapImage(new Uri(wayImage, UriKind.Relative))
                };
            }
        }

        private void Rectangle_MouseLeave(object sender, MouseEventArgs e)
        {
            Rectangle rect = sender as Rectangle;
            int[] position = picture_position(rect.Name);
            if (game.Place_is_free(position[0], position[1]))
            {
                rect.Fill = new SolidColorBrush(Colors.White);
            }
        }

        private void Rectangle_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Rectangle rect = sender as Rectangle;
            int[] position = picture_position(rect.Name);
            if (game.Place_is_free(position[0], position[1]))
            {
                string wayImage;
                if (game.Is_turn_zero())
                    wayImage = @"Image\O-image.jpg";
                else
                    wayImage = @"Image\X-image.jpg";
                rect.Fill = new ImageBrush
                {
                    ImageSource = new BitmapImage(new Uri(wayImage, UriKind.Relative))
                };
                game.New_turn(position[0], position[1]);
            }
        }

        private void click_on_menu_item_play_with_player(object sender, RoutedEventArgs e)
        {
            all_menu_item_play_with_somebody_checked_false();
            menu_item_play_with_player.IsChecked = true;
            menu_item_play_for_the.IsEnabled = false;
            new_game();
        }

        private void click_on_menu_item_play_for_the_zero(object sender, RoutedEventArgs e)
        {
            menu_item_play_for_the_zero.IsChecked = true;
            menu_item_play_for_the_cross.IsChecked = false;
            new_game();
            game.Side_zero();
        }

        private void click_on_menu_item_play_for_the_cross(object sender, RoutedEventArgs e)
        {
            menu_item_play_for_the_zero.IsChecked = false;
            menu_item_play_for_the_cross.IsChecked = true;
            new_game();
            game.Side_cross();
        }

        private void click_on_menu_item_play_with_bot(object sender, RoutedEventArgs e)
        {
            all_menu_item_play_with_somebody_checked_false();
            MenuItem menuI = sender as MenuItem;
            menuI.IsChecked = true;
            menu_item_play_for_the.IsEnabled = true;
            new_game();
        }

        private void new_game()
        {
            game.New_game();
            foreach (Rectangle rect in all_rectangle)
            {
                rect.Fill = new SolidColorBrush(Colors.White);
            }
        }

        private void all_menu_item_play_with_somebody_checked_false()
        {
            menu_item_play_with_player.IsChecked = false;
            menu_item_easy.IsChecked = false;
            menu_item_middle.IsChecked = false;
            menu_item_hard.IsChecked = false;
            menu_item_trained.IsChecked = false;
        }

        private int[] picture_position(string name_image)
        {
            int[] mas = new int[2];

            string[] words = name_image.Split(new char[] { '_' });
            switch (words[0])
            {
                case "up":
                    mas[0] = 0;
                    break;
                case "middle":
                    mas[0] = 1;
                    break;
                case "down":
                    mas[0] = 2;
                    break;
            }
            switch (words[1])
            {
                case "left":
                    mas[1] = 0;
                    break;
                case "center":
                    mas[1] = 1;
                    break;
                case "right":
                    mas[1] = 2;
                    break;
            }
            return mas;
        }
    }
}
