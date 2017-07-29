﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.ApplicationSettings; // this is the namespace added

// The Blank Application template is documented at http://go.microsoft.com/fwlink/?LinkId=234227

namespace stone.paper.scissors.thread
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    sealed partial class App : Application
    {
        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            this.InitializeComponent();
            this.Suspending += OnSuspending;
        }

        /// <summary>
        /// Invoked when the application is launched normally by the end user.  Other entry points
        /// will be used such as when the application is launched to open a specific file.
        /// </summary>
        /// <param name="e">Details about the launch request and process.</param>
        protected override void OnLaunched(LaunchActivatedEventArgs e)
        {

#if DEBUG
            if (System.Diagnostics.Debugger.IsAttached)
            {
                this.DebugSettings.EnableFrameRateCounter = true;
            }
#endif

            Frame rootFrame = Window.Current.Content as Frame;

            // Do not repeat app initialization when the Window already has content,
            // just ensure that the window is active
            if (rootFrame == null)
            {
                // Create a Frame to act as the navigation context and navigate to the first page
                rootFrame = new Frame();
                // Set the default language
                rootFrame.Language = Windows.Globalization.ApplicationLanguages.Languages[0];

                rootFrame.NavigationFailed += OnNavigationFailed;

                if (e.PreviousExecutionState == ApplicationExecutionState.Terminated)
                {
                    //TODO: Load state from previously suspended application
                }

                // Place the frame in the current Window
                Window.Current.Content = rootFrame;
            }

            if (rootFrame.Content == null)
            {
                // When the navigation stack isn't restored navigate to the first page,
                // configuring the new page by passing required information as a navigation
                // parameter
                rootFrame.Navigate(typeof(MainPage), e.Arguments);
            }
            // Ensure the current window is active
            Window.Current.Activate();
        }

        /// <summary>
        /// Invoked when Navigation to a certain page fails
        /// </summary>
        /// <param name="sender">The Frame which failed navigation</param>
        /// <param name="e">Details about the navigation failure</param>
        void OnNavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            throw new Exception("Failed to load Page " + e.SourcePageType.FullName);
        }

        /// <summary>
        /// Invoked when application execution is being suspended.  Application state is saved
        /// without knowing whether the application will be terminated or resumed with the contents
        /// of memory still intact.
        /// </summary>
        /// <param name="sender">The source of the suspend request.</param>
        /// <param name="e">Details about the suspend request.</param>
        private void OnSuspending(object sender, SuspendingEventArgs e)
        {
            var deferral = e.SuspendingOperation.GetDeferral();
            //TODO: Save application state and stop any background activity
            deferral.Complete();
        }

        //editing done below this
        protected override void OnWindowCreated(WindowCreatedEventArgs args)
        {
            SettingsPane.GetForCurrentView().CommandsRequested += OnCommandsRequested;
        }

        private void OnCommandsRequested(SettingsPane sender, SettingsPaneCommandsRequestedEventArgs args)
        {

            //args.Request.ApplicationCommands.Add(new SettingsCommand("Custom Setting", "Custom Setting", (handler) => ShowCustomSettingFlyout())); 
            //args.Request.ApplicationCommands.Add(new SettingsCommand("avantika", "avantika", (handler) => Show_avantika()));
            // this is the line which invokes the setting flyout

            args.Request.ApplicationCommands.Add(new SettingsCommand("Credits", "Credits", (handler) => Show_Credits()));
            args.Request.ApplicationCommands.Add(new SettingsCommand("Privacy Policy", "Privacy Policy", (handler) => Show_Privacy_Policy()));
            args.Request.ApplicationCommands.Add(new SettingsCommand("Help", "Help", (handler) => Show_Help()));
            args.Request.ApplicationCommands.Add(new SettingsCommand("About Us", "About Us", (handler) => Show_About_Us()));

        }

        public void Show_About_Us()
        {
            About_Us aboutpane = new About_Us();
            aboutpane.Show();
        }

        public void Show_Help()
        {
            Help helppane = new Help();
            helppane.Show();
        }

        public void Show_Privacy_Policy()
        {
            Privacy_Policy privacypane = new Privacy_Policy();
            privacypane.Show();
        }

        public void Show_Credits()
        {
            Credits creditspane = new Credits();
            creditspane.Show();
        }


        /*public void ShowCustomSettingFlyout()
        {
            CustomSetting CustomSettingFlyout = new CustomSetting();
            CustomSettingFlyout.Show();
        }
         
         public void Show_avantika()
        {
            
            avantika baby = new avantika(); // avantika here is the name of the setting xaml page.
            baby.Show();
        }*/
        //this is the sample event handler to instantiate and show our new SettingsFlyout.
       
                
    }
}
