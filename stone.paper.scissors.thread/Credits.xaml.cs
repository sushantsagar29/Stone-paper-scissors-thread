﻿using System;
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
    public sealed partial class Credits : SettingsFlyout
    {
        public Credits()
        {
            this.InitializeComponent();
            tb.Text = "\nThis product is developed by Sushant Sagar.\nCoding, designing and every other work done by him.\nSpecial thanx to: Ashutosh Gupta\n";
        }
    }
}
