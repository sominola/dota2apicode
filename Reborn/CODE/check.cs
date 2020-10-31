using Microsoft.Win32;
using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Animation;

namespace Reborn
{
    public partial class MainWindow : Window
    {
        public delegate void Func(string a);
        public delegate void Funcs();
        public async void async(Func func, string a)
        {
            await Task.Run(() =>
            {
                Dispatcher.Invoke((Action)(() =>
                {
                    func(a);
                }
                ));
            });
        }
        public async void asyncw(Funcs func)
        {
            await Task.Run(() =>
            {
                Dispatcher.Invoke((Action)(() =>
                {
                    func();
                }
                ));
            });
        }
        public void errors(string text)
        {
            error.Text = text;
            var animation = new DoubleAnimation
            {
                From = 1,
                To = 0,
                BeginTime = TimeSpan.FromSeconds(3),
                Duration = TimeSpan.FromSeconds(1),
                FillBehavior = FillBehavior.Stop
            };
            animation.Completed += delegate { error.Text = ""; };
            error.BeginAnimation(UIElement.OpacityProperty, animation);
        }
        private void ID_TEXT_PreviewTextInput(object sender, TextCompositionEventArgs e)
        { e.Handled = !(Char.IsDigit(e.Text, 0)); }
        private static readonly Regex _regex = new Regex("[^0-9.-]+");
        private static bool IsTextAllowed(string text)
        { return !_regex.IsMatch(text); }
        private void ID_TEXT_Pasting(object sender, DataObjectPastingEventArgs e)
        {
            String text = (String)e.DataObject.GetData(typeof(String));
            if (!IsTextAllowed(text))
            {
                e.CancelCommand();
                errors("Вставляйте только цифры!");
            }
        }
        private void clicker(object sender, RoutedEventArgs e)
        {
            Registry.CurrentUser.CreateSubKey($@"Software\DotaChecker\Friends\{values.ids}");
            var animation = new DoubleAnimation
            {
                From = 1,
                To = 0,
                BeginTime = TimeSpan.FromSeconds(3),
                Duration = TimeSpan.FromSeconds(1),
                FillBehavior = FillBehavior.Stop
            };
            addfriend.Content = $"Friend added";
            animation.Completed += delegate { addfriend.Content = ""; addfriend.Visibility = Visibility.Hidden; };
            addfriend.BeginAnimation(UIElement.OpacityProperty, animation);
            MyPanel.Children.Clear();
            Getfriend();
        }
        
    }
}
