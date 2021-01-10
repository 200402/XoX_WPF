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

namespace XoX_attempt_1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Rectangle_MouseEnter(object sender, MouseEventArgs e)
        {
            Rectangle rect = sender as Rectangle;
            rect.Fill = new ImageBrush
            {
                ImageSource = new BitmapImage(new Uri(@"Image\O-image-transparent.jpg", UriKind.Relative))
            };
        }

        private void Rectangle_MouseLeave(object sender, MouseEventArgs e)
        {
            Rectangle rect = sender as Rectangle;
            rect.Fill = new SolidColorBrush(Colors.White);
        }

        private void Rectangle_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Rectangle rect = sender as Rectangle;
            rect.Fill = new ImageBrush
            {
                ImageSource = new BitmapImage(new Uri(@"Image\O-image.jpg", UriKind.Relative))
            };
        }

        private void click_on_menu_item_play_with_player(object sender, RoutedEventArgs e)
        {
            all_menu_item_play_with_somebody_checked_false();

            menu_item_play_with_player.IsChecked = true;
            menu_item_first_move_at.IsEnabled = true;
            menu_item_play_for_the.IsEnabled = false;
        }

        private void click_on_menu_item_play_with_bot(object sender, RoutedEventArgs e)
        {
            all_menu_item_play_with_somebody_checked_false();

            MenuItem rect = sender as MenuItem;
            rect.IsChecked = true;
            menu_item_first_move_at.IsEnabled = false;
            menu_item_play_for_the.IsEnabled = true;
        }

        private void all_menu_item_play_with_somebody_checked_false()
        {
            menu_item_play_with_player.IsChecked = false;
            menu_item_easy.IsChecked = false;
            menu_item_middle.IsChecked = false;
            menu_item_hard.IsChecked = false;
            menu_item_trained.IsChecked = false;
        }
    }
}
