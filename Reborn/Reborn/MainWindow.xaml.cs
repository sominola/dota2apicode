using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;

namespace Reborn
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            infogit();
            keys();
            //Getfriend();
            //MyProfiles();
            WatchDog();

        }
        FileSystemWatcher watcher;
        private void keys()
        {
            RegistryKey localKey;
            if (Environment.Is64BitOperatingSystem)
                localKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);
            else
                localKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32);
            values.value = localKey.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\Steam App 570").GetValue(@"InstallLocation").ToString();
        }
        private void infogit()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://raw.githubusercontent.com/sominola/dota2-api/master/gameinfo.json");
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                values.github = reader.ReadToEnd();
            }
        }
        private void WatchDog()
        {
            watcher = new FileSystemWatcher(values.value + @"\game\dota\", "server_log.txt");
            watcher.NotifyFilter = NotifyFilters.Attributes | NotifyFilters.Size;
            watcher.Changed += (OnChanged);
            watcher.EnableRaisingEvents = true;
        }
        public async void OnChanged(object source, FileSystemEventArgs e)
        {
            await Task.Delay(30);
            await Dispatcher.BeginInvoke((Action)(() =>
            {
                var lastLine = File.ReadLines(values.value + @"\game\dota\server_log.txt").Last();
                if (lastLine.Contains("MODE"))
                {
                    thenemy thenemy = new thenemy();
                    thenemy.Show();
                    thenemy.suka(lastLine);
                }
            }));

        }
        private void Getfriend()
        {
            foreach (string nametree in Registry.CurrentUser.CreateSubKey(@"Software\DotaChecker\Friends\").GetSubKeyNames())
                friendslist(nametree);
        }
        private void friendslist(string id)
        {
            infoprofile profiles = JsonConvert.DeserializeObject<infoprofile>(http(values.apiurl + id));
            StackPanel stfr = new StackPanel();
            stfr.Style = this.FindResource("StackPanelFriends") as Style;
            TextBlock friendsname = new TextBlock();
            friendsname.Style = this.FindResource("FriendsText") as Style;
            friendsname.Text = profiles.profile.personaname;
            Image img = new Image();
            img.Source = new BitmapImage(new Uri($"{profiles.profile.avatarfull}"));
            img.Style = this.FindResource("ImageFriends") as Style;
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
            MyPanel.Children.Add(stfr);
            stfr.Children.Add(img);
            stfr.Children.Add(friendsname);
        }
        private void callgetmatch(string id)
        {
            string getmatch = "https://api.steampowered.com/IDOTA2Match_570/GetMatchHistory/v1/?key=F947E7FCBFF7ACB338B9887535C918EB&account_id=" + id + "&matches_requested=25";
            getmatches matches = JsonConvert.DeserializeObject<getmatches>(http(getmatch));
            for(int i = 0;i<25;i++)
                getmatches(matches.result.matches[i].match_id, id);
        }
        private async void getmatches(string matchid,string id)
        {
            string infomatch1 = await https("https://api.steampowered.com/IDOTA2Match_570/GetMatchDetails/v1/?key=F947E7FCBFF7ACB338B9887535C918EB&match_id=" + matchid);
            infomatcher infomatches = JsonConvert.DeserializeObject<infomatcher>(infomatch1);
            github heroandmodes = JsonConvert.DeserializeObject<github>(values.github);
            var ts = TimeSpan.FromSeconds(infomatches.result.duration);
            string data = DateTimeOffset.FromUnixTimeSeconds(infomatches.result.start_time).DateTime.ToLocalTime().ToString("dd/MM/yyyy hh:mm");
            string image="";
            string heroname="";
            string result="";
            string duration = ts.Minutes + ":" + ts.Seconds + " ";
            string mode= heroandmodes.Modes[infomatches.result.game_mode].name;

            for (int i = 0; i <= 9; i++)
                if (infomatches.result.players[i].account_id == id)
                {   
                    heroname=heroandmodes.heroes[infomatches.result.players[i].hero_id].localized_name;
               
                    image = $" http://cdn.dota2.com/apps/dota2/images/heroes/" + heroandmodes.heroes[infomatches.result.players[i].hero_id].name.Replace("npc_dota_hero_", "") + "_lg.png";
                    if (infomatches.result.players[i].player_slot <= 127 && infomatches.result.radiant_win == "true" || infomatches.result.players[i].player_slot >= 128 && infomatches.result.radiant_win == "false")
                        result = "WIN";
                    else
                        result = "LOSE";
                }
            matchess(data, image, heroname, result, duration, mode);
        }
        private void matchess(string dates, string image,string heroname,string resulta,string times,string modes)
        {
            Task.Delay(200);
            StackPanel stackmatch = new StackPanel();
            stackmatch.Margin = new Thickness(0,5,0,0);
            stackmatch.Background = new SolidColorBrush(Color.FromRgb(29, 33, 38));
            stackmatch.Orientation = Orientation.Horizontal;
            mainmatch.Children.Add(stackmatch);
            TextBlock date = new TextBlock();
            date.Style = this.FindResource("matchtext") as Style;
            date.MinWidth = 100;
            date.Padding = new Thickness(3,0,3,0);
            date.Text = dates;
            Image img = new Image();
            img.Width = 60;
            img.Source = new BitmapImage(new Uri($"{image}",UriKind.RelativeOrAbsolute));
            TextBlock hero = new TextBlock();
            hero.Style = this.FindResource("matchtext") as Style;
            hero.MinWidth = 135;
            hero.Margin = new Thickness(5, 0, 0, 0);
            hero.Foreground = new SolidColorBrush(Color.FromRgb(102, 187, 255));
            hero.Text = heroname;
            TextBlock result = new TextBlock();
            result.Style = this.FindResource("matchtext") as Style;
            result.MinWidth = 70;
                if(resulta == "WIN") { 
                result.Effect = new DropShadowEffect { Color = new Color { R = 106, G = 202, B = 108 }, BlurRadius = 20, };
                result.Foreground = new SolidColorBrush(Color.FromRgb(106, 202, 108));
                result.Text = "WIN";

            }
            else
            {
                result.Effect = new DropShadowEffect { Color = new Color { R = 194, G = 60, B = 42 }, BlurRadius = 20, };
                result.Foreground = new SolidColorBrush(Color.FromRgb(194, 60, 42));
                result.Text = "LOSE";
            }
            TextBlock time = new TextBlock();
            time.Style = this.FindResource("matchtext") as Style;
            time.MinWidth = 50;
            time.Text = times;
            TextBlock mode = new TextBlock();
            mode.Style = this.FindResource("matchtext") as Style;
            mode.Text = modes;
            stackmatch.Children.Add(date);
            stackmatch.Children.Add(img);
            stackmatch.Children.Add(hero);
            stackmatch.Children.Add(result);
            stackmatch.Children.Add(time);
            stackmatch.Children.Add(mode);



        }
    }
}
