using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;


namespace Reborn
{
    public partial class thenemy : Window
    {
        public thenemy()
        {
            InitializeComponent();
        }
        async Task<string> https(string uri)
        {
            try
            {
                using (HttpClientHandler hch = new HttpClientHandler {  UseProxy = true })
                using (var client = new HttpClient(hch))
                    return await client.GetStringAsync(uri);
            }
            catch (Exception e)
            {
                MessageBox.Show("Ошибка: " + e.Message);
                return null;
            }
        }
        async Task<string> https(string uri, string ip)
        {
            try
            {
                using (HttpClientHandler hch = new HttpClientHandler { Proxy = new WebProxy(ip, false), UseProxy = true })
                using (var client = new HttpClient(hch))
                    return await client.GetStringAsync(uri);
            }
            catch (Exception e)
            {
                MessageBox.Show("Ошибка: " + e.Message + " IP: " + ip);
                return null;
            }
        }
        public void suka(string lastLine)
        {
            Regex regex = new Regex(@"\[U:1:\d{2,}\]");
            MatchCollection matches = regex.Matches(lastLine);
            int[] srt = string.Join("", from Match match in matches select match.Value.Replace("[U:1:", "").Replace("]", " ")).Trim().Split(' ').Select(x => int.Parse(x)).ToArray();
            for (int i = 0; i < 10; i++)
                    enemys(srt[i], i);
               
        }
         async void enemys(int id, int ids)
        {
            StackPanel mainstack = new StackPanel();
            Image mainimage = new Image();
            mainstack.Style = this.FindResource("mainstack") as Style;
            string winrate1 = await https(values.apiurl + id + "/wl");
            string proverka1 = await https(values.apiurl + id + "/peers");
            percent winrate = JsonConvert.DeserializeObject<percent>(winrate1);
            if (ids < 5)
                Grid.SetRow(mainstack, ids + 1);
            else
                Grid.SetRow(mainstack, ids + 2);
            if (winrate.win == 0 && winrate.lose == 0 || proverka1 == string.Empty || proverka1 == "[]" || proverka1 == " ")
            {
                main.Children.Add(mainstack);
                mainimage.Source = new BitmapImage(new Uri($"https://steamcdn-a.akamaihd.net/steamcommunity/public/images/avatars/b5/b599127509772f2125568318a38f24e64881de61_full.jpg"));
                mainimage.HorizontalAlignment = HorizontalAlignment.Left;
                mainstack.Children.Add(mainimage);
                return;
            }
            else
            {
                string infoprofile1 = await https(values.apiurl + id);
                string ingames1 = await https(values.apiurl + id + "/heroes");
                github heroandmodes = JsonConvert.DeserializeObject<github>(values.github);
                infoprofile infoprofile = JsonConvert.DeserializeObject<infoprofile>(infoprofile1);
                List<ingame> ingames = JsonConvert.DeserializeObject<List<ingame>>(ingames1);
                mainimage.Source = new BitmapImage(new Uri(infoprofile.profile.avatarfull));
                StackPanel wraptext = new StackPanel();
                wraptext.Margin = new Thickness(5, 0, 0, 0);
                TextBlock personaname = new TextBlock();
                personaname.Width = 135;
                personaname.Foreground = new SolidColorBrush(Colors.White);
                personaname.FontSize = 18;
                personaname.Text = infoprofile.profile.personaname;
                TextBlock name = new TextBlock();
                name.Width = 135;
                name.Foreground = new SolidColorBrush(Colors.Gray);
                name.FontSize = 14;
                name.Text = "Country: " + infoprofile.profile.loccountrycode;
                Image rank = new Image();
                if (infoprofile.rank_tier != null)
                    rank.Source = new BitmapImage(new Uri($"{heroandmodes.ranks[infoprofile.rank_tier].source}"));
                else
                    rank.Source = new BitmapImage(new Uri($"https://github.com/sominola/dota2-api/blob/master/images/SeasonalRank0-0.png?raw=true"));
                rank.Width = 100;
                StackPanel wrapperpercent = new StackPanel();
                wrapperpercent.Width = 150;
                StackPanel winlose = new StackPanel();
                winlose.Margin = new Thickness(0, 5, 0, 0);
                winlose.Orientation = Orientation.Horizontal;
                winlose.HorizontalAlignment = HorizontalAlignment.Center;
                TextBlock win = new TextBlock();
                win.Style = this.FindResource("wins") as Style;
                win.Text = winrate.win.ToString();
                TextBlock stroke = new TextBlock();
                stroke.Text = "–";
                stroke.Margin = new Thickness(5, 0, 5, 0);
                stroke.Foreground = new SolidColorBrush(Colors.White);
                TextBlock lose = new TextBlock();
                lose.Style = this.FindResource("loses") as Style;
                lose.Text = winrate.lose.ToString();
                TextBlock percent = new TextBlock();
                percent.Style = this.FindResource("TextStyle") as Style;
                percent.Foreground = new SolidColorBrush(Colors.White);
                percent.HorizontalAlignment = HorizontalAlignment.Center;
                float percents = winrate.win / (winrate.win + winrate.lose) * 100;
                percent.Text = percents.ToString("0.##") + "%";
                TextBlock winratetext = new TextBlock();
                winratetext.Text = "WIN RATE";
                    winratetext.Style = this.FindResource("TextStyle") as Style;
                    winratetext.Foreground = new SolidColorBrush(Colors.Gray);
                    winratetext.HorizontalAlignment = HorizontalAlignment.Center;
                StackPanel hero = new StackPanel();
                Image hero1 = new Image();
                hero1.Margin = new Thickness(0, 0, 5, 0);
                hero1.Source = new BitmapImage(new Uri($"http://cdn.dota2.com/apps/dota2/images/heroes/" + heroandmodes.heroes[ingames[0].hero_id].name + "_lg.png"));
                Image hero2 = new Image();
                hero2.Margin = new Thickness(0, 0, 5, 0);
                hero2.Source = new BitmapImage(new Uri($"http://cdn.dota2.com/apps/dota2/images/heroes/" + heroandmodes.heroes[ingames[1].hero_id].name + "_lg.png"));
                Image hero3 = new Image();
                hero3.Source = new BitmapImage(new Uri($"http://cdn.dota2.com/apps/dota2/images/heroes/" + heroandmodes.heroes[ingames[2].hero_id].name + "_lg.png"));
                hero.Orientation = Orientation.Horizontal;
                TextBlock radiant = new TextBlock();
                radiant.Style = this.FindResource("radire") as Style;
                radiant.Text = "Radiant";
                TextBlock dire = new TextBlock();
                dire.Style = this.FindResource("radire") as Style;
                dire.Text = "Dire";
                Grid.SetRow(dire, 6);
                main.Children.Add(radiant);
                main.Children.Add(dire);
                main.Children.Add(mainstack);
                mainstack.Children.Add(mainimage);
                mainstack.Children.Add(wraptext);
                wraptext.Children.Add(personaname);
                wraptext.Children.Add(name);
                mainstack.Children.Add(rank);
                mainstack.Children.Add(wrapperpercent);
                wrapperpercent.Children.Add(winlose);
                winlose.Children.Add(win);
                winlose.Children.Add(stroke);
                winlose.Children.Add(lose);
                wrapperpercent.Children.Add(percent);
                wrapperpercent.Children.Add(winratetext);
                mainstack.Children.Add(hero);
                hero.Children.Add(hero1);
                hero.Children.Add(hero2);
                hero.Children.Add(hero3);
            }
        }


    }
}