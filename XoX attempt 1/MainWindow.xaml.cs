﻿using System;
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
    }
}
