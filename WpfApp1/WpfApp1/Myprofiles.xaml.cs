using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для Myprofiles.xaml
    /// </summary>
    public partial class Myprofiles : Window
    {
        public Myprofiles()
        {
            InitializeComponent();
            MyProfile();
        }
        string apiurl = "https://api.opendota.com/api/players/";
        private void MyProfile()
        {
            string path_bh = String.Empty;
            RegistryKey localKey;
            if (Environment.Is64BitOperatingSystem)
                localKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);
            else
                localKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32);
            string value = localKey.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\Steam App 570").GetValue(@"InstallLocation").ToString();
            string[] files = Directory.GetFiles(value + @"\game\dota\cfg", "latest*.txt");
            string text = "";
            foreach (string f in files)
                text += File.ReadAllText(f);
            text = Regex.Replace(text, @"\D+", " ", RegexOptions.ECMAScript).Trim();
            string[] mystring = text.Split(' ');
            for(int i = 0; i < mystring.Length; i = i + 17)
            profileslist(mystring[i]);
              
        }
        private void profileslist(string id)
        {
            infoprofile profiles = JsonConvert.DeserializeObject<infoprofile>(http(apiurl + id));
            TextBlock friendsname = new TextBlock();
            friendsname.Style = this.FindResource("Textfriendstyle") as Style;
            friendsname.Text = profiles.profile.personaname;
            Image img = new Image();
            img.Source = new BitmapImage(new Uri($"{profiles.profile.avatarfull}"));
            img.Width = friendsname.Width;
            img.Style = this.FindResource("Imagefriendstyle") as Style;
            img.MouseLeftButtonDown += (source, e) =>{ Data.EventHandler(id);};
            MyPanels.Children.Add(img);
            MyPanels.Children.Add(friendsname);
        }
        private void buttoner_Click(object sender, RoutedEventArgs e)
        {
            Myprofiles myprofiles = new Myprofiles();
            myprofiles.Show();
        }
       
    }
}
