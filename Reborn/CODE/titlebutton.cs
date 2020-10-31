using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;

namespace Reborn
{
    public partial class MainWindow : Window
    {
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (sidePanel.Width == 0)
            {
                var animation = new DoubleAnimation
                {
                    From = 0,
                    To = 200,
                    BeginTime = TimeSpan.FromSeconds(0),
                    Duration = TimeSpan.FromSeconds(0.5),
                    FillBehavior = FillBehavior.Stop
                };
                animation.Completed += delegate { sidePanel.Width = 200; };
                sidePanel.BeginAnimation(FrameworkElement.WidthProperty, animation);
            }
            else
            {
                var animation = new DoubleAnimation
                {
                    From = 200,
                    To = 0,
                    BeginTime = TimeSpan.FromSeconds(0),
                    Duration = TimeSpan.FromSeconds(0.5),
                    FillBehavior = FillBehavior.Stop
                };
                animation.Completed += delegate { sidePanel.Width = 0; };
                sidePanel.BeginAnimation(FrameworkElement.WidthProperty, animation);
            }
        }
        private void DragMove(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }
        private void Minimazed(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
            //if (WindowState == WindowState.Minimized)
            //{
            //    this.Hide();
            //    notifyIcons.Visible = true;
            //    notifyIcons.ShowBalloonTip(1000);
            //}
            //else if (WindowState.Normal == this.WindowState)
            //{ notifyIcons.Visible = false; }
        }
        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            RotateTransform rt = new RotateTransform();
            Pts.RenderTransform = rt;
            Pts.RenderTransformOrigin = new Point(.5, .5);
            int counts = MyPanel.Children.Count * 58;
            if (MyPanel.Visibility == Visibility.Hidden)
            {
                MyPanel.Visibility = Visibility.Visible;
                var animation = new DoubleAnimation
                {
                    From = 0,
                    To = counts,
                    BeginTime = TimeSpan.FromSeconds(0),
                    Duration = TimeSpan.FromMilliseconds(300),
                    FillBehavior = FillBehavior.Stop
                };
                animation.Completed += delegate { MyPanel.Height = counts; };
                MyPanel.BeginAnimation(FrameworkElement.HeightProperty, animation);
                DoubleAnimation anim3 = new DoubleAnimation(0, 180, TimeSpan.FromSeconds(.3));
                rt.BeginAnimation(RotateTransform.AngleProperty, anim3);
            }
            else
            {
                var animation = new DoubleAnimation
                {
                    From = counts,
                    To = 0,
                    BeginTime = TimeSpan.FromSeconds(0),
                    Duration = TimeSpan.FromMilliseconds(300),
                    FillBehavior = FillBehavior.Stop
                };
                animation.Completed += delegate { MyPanel.Height = 0; MyPanel.Visibility = Visibility.Hidden; };
                MyPanel.BeginAnimation(FrameworkElement.HeightProperty, animation);
                DoubleAnimation anim3 = new DoubleAnimation(180, 0, TimeSpan.FromSeconds(.3));
                rt.BeginAnimation(RotateTransform.AngleProperty, anim3);
            }
        }
        private void Myprofile(object sender, RoutedEventArgs e)
        {
            RotateTransform rts = new RotateTransform();
            pathprof.RenderTransform = rts;
            pathprof.RenderTransformOrigin = new Point(.5, .5);
            int counts = Mypanel1.Children.Count * 58;
            if (Mypanel1.Visibility == Visibility.Hidden)
            {
                Mypanel1.Visibility = Visibility.Visible;
                var animation = new DoubleAnimation
                {
                    From = 0,
                    To = counts,
                    BeginTime = TimeSpan.FromSeconds(0),
                    Duration = TimeSpan.FromMilliseconds(300),
                    FillBehavior = FillBehavior.Stop
                };
                animation.Completed += delegate { Mypanel1.Height = counts; };
                Mypanel1.BeginAnimation(FrameworkElement.HeightProperty, animation);
                DoubleAnimation anim3 = new DoubleAnimation(0, 180, TimeSpan.FromSeconds(.3));
                rts.BeginAnimation(RotateTransform.AngleProperty, anim3);
            }
            else
            {
                var animation = new DoubleAnimation
                {
                    From = counts,
                    To = 0,
                    BeginTime = TimeSpan.FromSeconds(0),
                    Duration = TimeSpan.FromMilliseconds(300),
                    FillBehavior = FillBehavior.Stop
                };
                animation.Completed += delegate { Mypanel1.Height = 0; Mypanel1.Visibility = Visibility.Hidden; };
                Mypanel1.BeginAnimation(FrameworkElement.HeightProperty, animation);
                DoubleAnimation anim3 = new DoubleAnimation(180, 0, TimeSpan.FromSeconds(.3));
                rts.BeginAnimation(RotateTransform.AngleProperty, anim3);
            }
        }
        private void MyProfiles()
        {
            string[] files = Directory.GetFiles(values.value + @"\game\dota\cfg", "latest*.txt");
            string text = "";
            foreach (string f in files)
                text += File.ReadAllText(f);
            text = Regex.Replace(text, @"\D+", " ", RegexOptions.ECMAScript).Trim();
            string[] mystring = text.Split(' ');
            for (int i = 0; i < mystring.Length; i += 17)
                profileslist(mystring[i]);
        }
        private void profileslist(string id)
        {
            infoprofile profiles = JsonConvert.DeserializeObject<infoprofile>(http(values.apiurl + id));
            StackPanel stpprf = new StackPanel();
            stpprf.Style = this.FindResource("StackPanelFriends") as Style;
            TextBlock friendsname = new TextBlock();
            friendsname.Style = this.FindResource("FriendsText") as Style;
            friendsname.Text = profiles.profile.personaname;
            Image img = new Image();
            img.Source = new BitmapImage(new Uri($"{profiles.profile.avatarfull}"));
            img.Style = this.FindResource("ImageFriends") as Style;
            img.MouseLeftButtonDown += (source, e) => { main(id);};
            Mypanel1.Children.Add(stpprf);
            stpprf.Children.Add(img);
            stpprf.Children.Add(friendsname);
        }
        private void sidePanel_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            sidePanel.Width = 0;
        }
        private void friendsbutton_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            BrushConverter bc = new BrushConverter();
            FriendsBackground.Background = Brushes.DarkGoldenrod;
        }
        private void friendsbutton_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            BrushConverter bc = new BrushConverter();
            FriendsBackground.Background = (Brush)bc.ConvertFrom("#1D2126");
        }
        private void Button_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            BrushConverter bc = new BrushConverter();
            MyprofilesBackground.Background = Brushes.DarkGoldenrod;
        }
        private void Button_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            BrushConverter bc = new BrushConverter();
            MyprofilesBackground.Background = (Brush)bc.ConvertFrom("#1D2126");

        }
    }
    public partial class thenemy : Window
    {
        private void DragMove(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }
        private void Minimazed(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
            //if (WindowState == WindowState.Minimized)
            //{
            //    this.Hide();
            //    notifyIcons.Visible = true;
            //    notifyIcons.ShowBalloonTip(1000);
            //}
            //else if (WindowState.Normal == this.WindowState)
            //{ notifyIcons.Visible = false; }
        }
        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
