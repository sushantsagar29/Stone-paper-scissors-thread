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

// The Settings Flyout item template is documented at http://go.microsoft.com/fwlink/?LinkId=273769

namespace stone.paper.scissors.thread
{
    public sealed partial class Help : SettingsFlyout
    {
        public Help()
        {
            this.InitializeComponent();
            tb.Text = "\nThis game is played between two people. Here you play against computer.\nBoth player and the computer selects any of the four tools.\n1> Stone wins over scissors by smashing it.\n2> Paper wins over stone wrapping it.\n3> Scissors wins over paper and thread by shredded them.\n4> Thread wins over stone and paper by tethering them.\n The one who wins collect the points.\n\nYou can turn the music in game ON or OFF using the toggle button provided during game.\nFor further help you can contact the publisher.";
        }
    }
}
