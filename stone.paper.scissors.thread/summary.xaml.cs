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
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace stone.paper.scissors.thread
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class summary : Page
    {
        public summary()
        {
            this.InitializeComponent();
            
        }

        int limit;

        private void nextpage_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        void show()
        {
                        if(stone.paper.scissors.thread.MainPage.user_score == limit)
                        {
                            //make the dialog box appear
                            overcanvas.Visibility = Windows.UI.Xaml.Visibility.Visible;
                            gameover_dialog.Text = "Congratulations!! You Won.";
                           
                            Uri usertemp = new Uri("ms-appx:///Assets/happy-icon.png", UriKind.Absolute);
                            BitmapImage imgSource = new BitmapImage(usertemp);
                            this.gameover_img.Source = imgSource;                           
                        
                        }
                        else if(stone.paper.scissors.thread.MainPage.computer_score == limit)
                        {
                        //make the dialog box appear
                            overcanvas.Visibility = Windows.UI.Xaml.Visibility.Visible;
                            gameover_dialog.Text = "Sorry!! You Lost.";
                          
                            Uri usertemp = new Uri("ms-appx:///Assets/try-again.png", UriKind.Absolute);
                            BitmapImage imgSource = new BitmapImage(usertemp);
                            this.gameover_img.Source = imgSource;
                                                        
                        }

        }

        private void summarycode(object sender, RoutedEventArgs e)
        {
            if (stone.paper.scissors.thread.MainPage.music == true)
            {
                chimes.AutoPlay = true;
            }
            limit = (stone.paper.scissors.thread.MainPage.round_num + 1) / 2;
            userscore.Text = "" + stone.paper.scissors.thread.MainPage.user_score; // "" is added to make the integer score to string
            compscore.Text = "" + stone.paper.scissors.thread.MainPage.computer_score; //we can have even used the string.parse
            show();
        }

    }
}
