using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace stone.paper.scissors.thread
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        public static string user_name = "You";
        public static int user_score = 0;
        public static int computer_score = 0;
        public static string round;
        public static int round_num;
        public static int[,] array = new int[5,5] {
                                         {0,1,2,3,4,},
                                         {1,0,-1,1,-1},
                                         {2,1,0,-1,-1},
                                         {3,-1,1,0,1},
                                         {4,1,1,-1,0}
                                            };  //this is the array through which we would calculate the result of each turn
       
        public static bool music; //wheather to play music in the game or not

        private void helpbutton_Click(object sender, RoutedEventArgs e)
        {
            border3.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            border2.Visibility = Windows.UI.Xaml.Visibility.Visible;
            help_block.Text = "                     Instructions\n\nBoth player and the computer selects any of the four tools.\n1> Stone wins over scissors by smashing it.\n2> Paper wins over stone wrapping it.\n3> Scissors wins over paper and thread by shredded them.\n4> Thread wins over stone and paper by tethering them.\n The one who wins collect the points.";
        
        }

        private void aboutbutton_Click(object sender, RoutedEventArgs e)
        {
            border2.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            about_block.Text = "\n                       About Us        \n\n Sushant Sagar\n Kiit University\n Computer Science And Engg.\n sushant.sagar29@gmail.com";
            border3.Visibility = Windows.UI.Xaml.Visibility.Visible;
        
        }

        
        private void playbutton_Click(object sender, RoutedEventArgs e)
        {
            //array[0,0] = 0;
            user_score = 0;
            computer_score = 0;
            this.Frame.Navigate(typeof(entry));
        }

        private void close_help_Click(object sender, RoutedEventArgs e)
        {
            border2.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
        }

        private void close_about_Click(object sender, RoutedEventArgs e)
        {
            border3.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
        }
    }
}
