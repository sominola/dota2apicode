using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        string apiurl = "https://api.opendota.com/api/players/";
        private string http(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                return  reader.ReadToEnd();
            }
        }
        private void main(string id)
        {
            percent check = JsonConvert.DeserializeObject<percent>(http(apiurl+ id + "/wl"));
            if (check.win == 0 && check.lose == 0)
                errors("Профиль не найден!");
            else
            {
                //recentMatch(id);
                //infoprofile(id);
                //percent(id);
                async(recentMatch, id);
                async(infoprofile, id);
                async(percent, id);
            }
        }
        private void FindButton(object sender, RoutedEventArgs e)
        {

            if (ID_TEXT.Text.Length > 0 && !string.IsNullOrWhiteSpace(ID_TEXT.Text))
                async(main,ID_TEXT.Text);
            else errors("Поле пустое или имеет пробел");
        }
        private void Getfriend()
        {
                        foreach (string nametree in Registry.CurrentUser.OpenSubKey(@"Software\DotaChecker\Friends\").GetSubKeyNames())
                            async(friendslist,nametree);
        }
        private void friendslist(string id)
        {
            infoprofile profiles = JsonConvert.DeserializeObject<infoprofile>(http(apiurl + id));
            TextBlock friendsname = new TextBlock();
            friendsname.Style = this.FindResource("Textfriendstyle") as Style;
            friendsname.Text = profiles.profile.personaname;
            Image img = new Image();
            img.Source = new BitmapImage(new Uri($"{profiles.profile.avatarfull}"));
            img.Width = friendsname.Width;
            img.Style = this.FindResource("Imagefriendstyle") as Style;
            img.MouseLeftButtonDown += (source, e) =>
            {
                recentMatch(id);
                infoprofile(id);
                percent(id);
            };
            img.MouseRightButtonDown += (source, e) =>
            {
                Registry.CurrentUser.DeleteSubKey(@"Software\DotaChecker\Friends\" + id);
                MyPanel.Children.Clear();
                Getfriend();
            };
            MyPanel.Children.Add(img);
            MyPanel.Children.Add(friendsname);

        }
        public MainWindow()
        {
            InitializeComponent();
            asyncw(Getfriend);
            Data.EventHandler = new Data.MyEvent(func);
        }
        void func(string param)
        {
            main(param);
        }
    }
}
 
