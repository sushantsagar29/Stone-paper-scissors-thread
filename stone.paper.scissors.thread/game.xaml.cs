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
    public sealed partial class game : Page
    {
        public game()
        {
            this.InitializeComponent();
        }

        int limit, c_rand = 0; // to calculate who wins
        int user_choice = 0;//c_rand has the value of compture's choice
        string newname;

        private void stonebutton_Click(object sender, RoutedEventArgs e)
        {                     
            user_stone.Background = new SolidColorBrush(Windows.UI.Colors.Red); // this line is to change the color of any element
          
            Uri usertemp = new Uri("ms-appx:///Assets/stone.png", UriKind.Absolute);
            BitmapImage imgSource1 = new BitmapImage(usertemp);
            this.choice1img.ImageSource = imgSource1;
                                  
            user_choice = 1;
            generate_computer();
        }

        private void paperbutton_Click(object sender, RoutedEventArgs e)
        {      
            user_stone.Visibility = Windows.UI.Xaml.Visibility.Visible;

            user_stone.Background = new SolidColorBrush(Windows.UI.Colors.Blue); // this line is to change the color of any element
                  
            Uri usertemp = new Uri("ms-appx:///Assets/paper.png", UriKind.Absolute);
            BitmapImage imgSource1 = new BitmapImage(usertemp);
            this.choice1img.ImageSource = imgSource1;
                     
            user_choice = 2;
            generate_computer();
        }

        private void scissorsbutton_Click(object sender, RoutedEventArgs e)
        {          
            user_stone.Visibility = Windows.UI.Xaml.Visibility.Visible;

            user_stone.Background = new SolidColorBrush(Windows.UI.Colors.Green); // this line is very imp. this is to change the color of any element
           
            Uri usertemp = new Uri("ms-appx:///Assets/scissors.png", UriKind.Absolute);
            BitmapImage imgSource1 = new BitmapImage(usertemp);
            this.choice1img.ImageSource = imgSource1;

            user_choice = 3;
            generate_computer();
        }

        private void threadbutton_Click(object sender, RoutedEventArgs e)
        {          
            user_stone.Visibility = Windows.UI.Xaml.Visibility.Visible; //border
          
            user_stone.Background = new SolidColorBrush(Windows.UI.Colors.Purple); // this line is very imp. this is to change the color of any element [border]
           
            Uri usertemp = new Uri("ms-appx:///Assets/thread.png", UriKind.Absolute);
            BitmapImage imgSource1 = new BitmapImage(usertemp);
            this.choice1img.ImageSource = imgSource1; //ellipse
 
            user_choice = 4;
            generate_computer();
        }

        //choice is displayed by making the border visible changing it background and setting the image to the ellipse inside it after the above buttons are clicked

        private void next_Click(object sender, RoutedEventArgs e)
        {
            if ((stone.paper.scissors.thread.MainPage.user_score == limit) || (stone.paper.scissors.thread.MainPage.computer_score == limit)) //if game gets over
            {
                this.Frame.Navigate(typeof(summary));
            }
            else
            {
                next.IsEnabled = false;

                stonebutton.IsEnabled = true;
                paperbutton.IsEnabled = true;
                scissorsbutton.IsEnabled = true;
                threadbutton.IsEnabled = true;

                result_border.Visibility = Windows.UI.Xaml.Visibility.Collapsed; // this statement make the result icon dissapear after the next button is clicked

                user_stone.Background = new SolidColorBrush(Windows.UI.Colors.Azure); // this line is to change the color of any element back to lightgray
                comp_stone.Background = new SolidColorBrush(Windows.UI.Colors.Azure); // this line is to change the color of any element back to lightgray
                choice1.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                choice1o1.Visibility = Windows.UI.Xaml.Visibility.Collapsed;

                comment.Text = "Make your choice for the next turn.";
                choicetb.Visibility = Windows.UI.Xaml.Visibility.Visible;
            }                    
       }

        private void gameloded(object sender, RoutedEventArgs e)//changes have been only made here
        {
            if(stone.paper.scissors.thread.MainPage.user_name.Length > 13) // this funtion here makes the only first name visible if the name entered by the yser it loger than 13 chars
            {
                string comparison;
                for (int x = 0; x < stone.paper.scissors.thread.MainPage.user_name.Length; x++)
                {
                    comparison = (stone.paper.scissors.thread.MainPage.user_name.Substring(x, 1));

                    if (comparison.Equals(" "))//this method works only on strings therefore comparison is kept string type
                        break;
                    else
                        newname = newname + comparison;//concat operation is done
                }
                usertext.Text = newname;
            }
            else
                usertext.Text = stone.paper.scissors.thread.MainPage.user_name;// if not longer than 13 chars the whole name is taken
            
            limit = (stone.paper.scissors.thread.MainPage.round_num+1)/2;           
            comment.Text = "Welcome! Let's Start The Game.";
            dash.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            choicetb.Visibility = Windows.UI.Xaml.Visibility.Visible;
        }

        void generate_computer()
        {
            choice1.Visibility = Windows.UI.Xaml.Visibility.Visible;// these lines are there to make the choice box reapper after the user strikes the button
            choice1o1.Visibility = Windows.UI.Xaml.Visibility.Visible;
            choicetb.Visibility = Windows.UI.Xaml.Visibility.Collapsed;

            stonebutton.IsEnabled = false;
            paperbutton.IsEnabled = false;
            scissorsbutton.IsEnabled = false;
            threadbutton.IsEnabled = false;

            dash.Visibility = Windows.UI.Xaml.Visibility.Visible;
            next.Visibility = Windows.UI.Xaml.Visibility.Visible; // makes the next button visible
            next.IsEnabled = true;

            Random rnd = new Random();
            c_rand = rnd.Next(1, 5); //generates no b/w 1 to 4

            display(); // this function associates the computer's choice with its image
            calculate();
            if (stone.paper.scissors.thread.MainPage.music == true)
            {
                chimes.Play();
            }
        }


        void display() //works on the c_rand generated by computer
        {

            switch (c_rand)
            {

                case 1: comp_stone.Background = new SolidColorBrush(Windows.UI.Colors.Red); // this line is to change the color of any element
                        Uri usertemp1 = new Uri("ms-appx:///Assets/stone.png", UriKind.Absolute);
                        BitmapImage imgSource1 = new BitmapImage(usertemp1);
                        this.choice1o1img.ImageSource = imgSource1;
                        break;
                case 2: comp_stone.Background = new SolidColorBrush(Windows.UI.Colors.Blue); 
                        Uri usertemp2 = new Uri("ms-appx:///Assets/paper.png", UriKind.Absolute);
                        BitmapImage imgSource2 = new BitmapImage(usertemp2);
                        this.choice1o1img.ImageSource = imgSource2;
                        break;
                case 3: comp_stone.Background = new SolidColorBrush(Windows.UI.Colors.Green); 
                        Uri usertemp3 = new Uri("ms-appx:///Assets/scissors.png", UriKind.Absolute);
                        BitmapImage imgSource3 = new BitmapImage(usertemp3);
                        this.choice1o1img.ImageSource = imgSource3;
                        break;
                case 4: comp_stone.Background = new SolidColorBrush(Windows.UI.Colors.Purple); 
                        Uri usertemp4 = new Uri("ms-appx:///Assets/thread.png", UriKind.Absolute);
                        BitmapImage imgSource4 = new BitmapImage(usertemp4);
                        this.choice1o1img.ImageSource = imgSource4; //ellipse
                        break;
            }
        }


        void calculate() // this function calculates by using the array
        {
            if (stone.paper.scissors.thread.MainPage.array[user_choice, c_rand] == -1)
            {
                stone.paper.scissors.thread.MainPage.computer_score++;
                comment_func();
                score_update();

                result_border.Visibility = Windows.UI.Xaml.Visibility.Visible;
                Uri usertemp = new Uri("ms-appx:///Assets/Hands-Thumb-down-icon.png", UriKind.Absolute);
                BitmapImage imgSource = new BitmapImage(usertemp);
                this.result_img.Source = imgSource;
            }
            else if (stone.paper.scissors.thread.MainPage.array[user_choice, c_rand] == 1)
            {
                stone.paper.scissors.thread.MainPage.user_score++;
                comment_func();
                score_update();

                result_border.Visibility = Windows.UI.Xaml.Visibility.Visible;
                Uri usertemp = new Uri("ms-appx:///Assets/Hands-Thumb-up-icon.png", UriKind.Absolute);
                BitmapImage imgSource = new BitmapImage(usertemp);
                this.result_img.Source = imgSource;
            }
            else
            {
                comment_func();
                score_update();

                result_border.Visibility = Windows.UI.Xaml.Visibility.Visible;
                Uri usertemp = new Uri("ms-appx:///Assets/Hands-Thumb-up-icon.png", UriKind.Absolute);
                BitmapImage imgSource = new BitmapImage(usertemp);
                this.result_img.Source = imgSource;
            }
            
        }//end of calculate function


        void comment_func()// this function will make comments on each turn
        {
           if(user_choice == 1)//when user chooses stone
           {
                 switch(c_rand)
                 {
                     case 1 : comment.Text = "This is a tie.";
                              break;
                     case 2: comment.Text = "Paper wrapped the stone.";
                              break;
                     case 3: comment.Text = "Stone smashed the scissors.";
                              break;
                     case 4: comment.Text = "Thread tethered the rock.";
                              break;
                 }
          }
           else if(user_choice == 2)//when user chooses paper
           { 
                 switch(c_rand)
                 {
                     case 1: comment.Text = "Paper wrapped the stone.";
                             break;
                     case 2: comment.Text = "This is a tie.";
                             break;
                     case 3: comment.Text = "Scissors shredded the paper.";
                             break;
                     case 4: comment.Text = "Thread tethered the paper.";
                             break;
                 }
           }
           else if(user_choice == 3)//when user chooses scissors
           {
                 switch(c_rand)
                 {
                     case 1: comment.Text = "Rock smashed the scissors.";
                             break;
                     case 2: comment.Text = "Scissors shredded the paper.";
                             break;
                     case 3: comment.Text = "This is a tie.";
                             break;
                     case 4: comment.Text = "Scissors shredded the thread.";
                             break;
                 }
           }
           else if(user_choice == 4)//when user chooses thread
           { 
                 switch(c_rand)
                 {
                     case 1: comment.Text = "Thread tethered the rock.";
                             break;
                     case 2: comment.Text = "Thread tethered the paper.";
                             break;
                     case 3: comment.Text = "Scissors shredded the thread.";
                             break;
                     case 4: comment.Text = "This is a tie.";
                             break;
                 }
           }

        }

        void score_update()// this function will update the score board on each turn
        {
            userscore.Text = "" + stone.paper.scissors.thread.MainPage.user_score; // "" is added to make the integer score to string
            compscore.Text = "" + stone.paper.scissors.thread.MainPage.computer_score; //we can have even used the string.parse
           
        }

    }
}
