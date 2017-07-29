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
    public sealed partial class entry : Page
    {
        public entry()
        {
            this.InitializeComponent();
        }

        private void playbutton_Click(object sender, RoutedEventArgs e)
        {
            stone.paper.scissors.thread.MainPage.user_name = enter_name.Text;
            stone.paper.scissors.thread.MainPage.round = enter_round.SelectedItem.ToString();
            stone.paper.scissors.thread.MainPage.round_num = int.Parse(stone.paper.scissors.thread.MainPage.round);
            stone.paper.scissors.thread.MainPage.music = music_toggle.IsOn; // sets the value of toggle button to a boolean variable
            this.Frame.Navigate(typeof(game));
        }

        private void entryloaded(object sender, RoutedEventArgs e)
        {
            enter_name.Text = stone.paper.scissors.thread.MainPage.user_name;
        }
    }
}
