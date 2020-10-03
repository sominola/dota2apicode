using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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
        private async Task<string> https(string url)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Proxy = null;
                using (HttpWebResponse response = (HttpWebResponse)await request.GetResponseAsync())
                using (Stream stream = response.GetResponseStream())
                {
                    return await new StreamReader(stream).ReadToEndAsync();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Ошибка: " + e.Message);
            }
            return null;
        }
        private string http(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }
        private void main(string id)
        {
            percent check = JsonConvert.DeserializeObject<percent>(http(values.apiurl + id + "/wl"));
            if (check.win == 0 && check.lose == 0)
                errors("Профиль не найден!");
            else
            {
                async(recentMatch, id);
                async(infoprofile, id);
                async(percent, id);
                async(callgetmatch, id);
            }
        }
        private void tier_icon(string rank_tiek)
        {

            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            if (rank_tiek == "11")
            {
                Tier.Source = new BitmapImage(new Uri("https://gamepedia.cursecdn.com/dota2_gamepedia/thumb/8/85/SeasonalRank1-1.png/160px-SeasonalRank1-1.png?version=4d417d6b41d86ab2bb46f685b3c6a495"));
            }
            if (rank_tiek == "12")
            {
                Tier.Source = new BitmapImage(new Uri("https://gamepedia.cursecdn.com/dota2_gamepedia/thumb/e/ee/SeasonalRank1-2.png/160px-SeasonalRank1-2.png?version=1ae01a5bccd922cb4104d9f7e0bb72b1"));
            }
            if (rank_tiek == "13")
            {
                Tier.Source = new BitmapImage(new Uri("https://gamepedia.cursecdn.com/dota2_gamepedia/thumb/0/05/SeasonalRank1-3.png/160px-SeasonalRank1-3.png?version=5c6cb43b73566f4465e308d6832c86a3"));
            }
            if (rank_tiek == "14")
            {
                Tier.Source = new BitmapImage(new Uri("https://gamepedia.cursecdn.com/dota2_gamepedia/thumb/6/6d/SeasonalRank1-4.png/160px-SeasonalRank1-4.png?version=631696a209896a9aa8872e027dca7139"));
            }
            if (rank_tiek == "15")
            {
                Tier.Source = new BitmapImage(new Uri("https://gamepedia.cursecdn.com/dota2_gamepedia/thumb/2/2b/SeasonalRank1-5.png/160px-SeasonalRank1-5.png?version=88a6558b73c5966745f7c04ccdd4d519"));
            }

            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            if (rank_tiek == "21")
            {
                Tier.Source = new BitmapImage(new Uri("https://gamepedia.cursecdn.com/dota2_gamepedia/thumb/c/c7/SeasonalRank2-1.png/160px-SeasonalRank2-1.png?version=98fa4d014af8e4c89f72cc5f43efc15e"));
            }
            if (rank_tiek == "22")
            {
                Tier.Source = new BitmapImage(new Uri("https://gamepedia.cursecdn.com/dota2_gamepedia/thumb/2/2c/SeasonalRank2-2.png/160px-SeasonalRank2-2.png?version=c53f276eb355b27c8464b5201d827811"));
            }
            if (rank_tiek == "23")
            {
                Tier.Source = new BitmapImage(new Uri("https://gamepedia.cursecdn.com/dota2_gamepedia/thumb/f/f5/SeasonalRank2-3.png/160px-SeasonalRank2-3.png?version=8fb1e78eb0aa7f8f1687312bb85146e7"));
            }
            if (rank_tiek == "24")
            {
                Tier.Source = new BitmapImage(new Uri("https://gamepedia.cursecdn.com/dota2_gamepedia/thumb/b/b4/SeasonalRank2-4.png/160px-SeasonalRank2-4.png?version=1594033d72c84a96c18b4067b7cdf9a1"));
            }
            if (rank_tiek == "25")
            {
                Tier.Source = new BitmapImage(new Uri("https://gamepedia.cursecdn.com/dota2_gamepedia/thumb/3/32/SeasonalRank2-5.png/160px-SeasonalRank2-5.png?version=22bbe284b2774aec70337fc99eb53c3a"));
            }

            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            if (rank_tiek == "31")
            {
                Tier.Source = new BitmapImage(new Uri("https://gamepedia.cursecdn.com/dota2_gamepedia/thumb/8/82/SeasonalRank3-1.png/160px-SeasonalRank3-1.png?version=a1b421795b35032f8b72b4a86cdb6995"));
            }
            if (rank_tiek == "32")
            {
                Tier.Source = new BitmapImage(new Uri("https://gamepedia.cursecdn.com/dota2_gamepedia/thumb/6/6e/SeasonalRank3-2.png/160px-SeasonalRank3-2.png?version=3bec2d08c50cc014750094bb78692f66"));
            }
            if (rank_tiek == "33")
            {
                Tier.Source = new BitmapImage(new Uri("https://gamepedia.cursecdn.com/dota2_gamepedia/thumb/6/67/SeasonalRank3-3.png/160px-SeasonalRank3-3.png?version=2e787f3b05dd34efabdd059c87041f2c"));
            }
            if (rank_tiek == "34")
            {
                Tier.Source = new BitmapImage(new Uri("https://gamepedia.cursecdn.com/dota2_gamepedia/thumb/8/87/SeasonalRank3-4.png/160px-SeasonalRank3-4.png?version=0a89c0705a8c33fc31ccb61f618ded77"));
            }
            if (rank_tiek == "35")
            {
                Tier.Source = new BitmapImage(new Uri("https://gamepedia.cursecdn.com/dota2_gamepedia/thumb/b/b1/SeasonalRank3-5.png/160px-SeasonalRank3-5.png?version=f25682e8ba71eb2399d81062bee2e0e5"));
            }

            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            if (rank_tiek == "41")
            {
                Tier.Source = new BitmapImage(new Uri("https://gamepedia.cursecdn.com/dota2_gamepedia/thumb/7/76/SeasonalRank4-1.png/160px-SeasonalRank4-1.png?version=297f2bea1b4fc9dff91dcdea0fc79cd3"));
            }
            if (rank_tiek == "42")
            {
                Tier.Source = new BitmapImage(new Uri("https://gamepedia.cursecdn.com/dota2_gamepedia/thumb/8/87/SeasonalRank4-2.png/160px-SeasonalRank4-2.png?version=44366391274726d87c568d5f8143475d"));
            }
            if (rank_tiek == "43")
            {
                Tier.Source = new BitmapImage(new Uri("https://gamepedia.cursecdn.com/dota2_gamepedia/thumb/6/60/SeasonalRank4-3.png/160px-SeasonalRank4-3.png?version=3d4fc68b5ed069c6c17381364b9b8e26"));
            }
            if (rank_tiek == "44")
            {
                Tier.Source = new BitmapImage(new Uri("https://gamepedia.cursecdn.com/dota2_gamepedia/thumb/4/4a/SeasonalRank4-4.png/160px-SeasonalRank4-4.png?version=0c51954f00d46e25b0c4dfc61ea2640b"));
            }
            if (rank_tiek == "45")
            {
                Tier.Source = new BitmapImage(new Uri("https://gamepedia.cursecdn.com/dota2_gamepedia/thumb/a/a3/SeasonalRank4-5.png/160px-SeasonalRank4-5.png?version=ace7dc976e3c1a3a7c1f0f66236f48a2"));
            }

            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            if (rank_tiek == "51")
            {
                Tier.Source = new BitmapImage(new Uri("https://gamepedia.cursecdn.com/dota2_gamepedia/thumb/7/79/SeasonalRank5-1.png/160px-SeasonalRank5-1.png?version=0be501e6594d831fb42e19946df666ad"));
            }
            if (rank_tiek == "52")
            {
                Tier.Source = new BitmapImage(new Uri("https://gamepedia.cursecdn.com/dota2_gamepedia/thumb/5/52/SeasonalRank5-2.png/160px-SeasonalRank5-2.png?version=0bbc92379757d185428bd5631119d37a"));
            }
            if (rank_tiek == "53")
            {
                Tier.Source = new BitmapImage(new Uri("https://gamepedia.cursecdn.com/dota2_gamepedia/thumb/8/88/SeasonalRank5-3.png/160px-SeasonalRank5-3.png?version=2dc37d3b1c0fbb6bec17a826776cc1c7"));
            }
            if (rank_tiek == "54")
            {
                Tier.Source = new BitmapImage(new Uri("https://gamepedia.cursecdn.com/dota2_gamepedia/thumb/2/25/SeasonalRank5-4.png/160px-SeasonalRank5-4.png?version=4aa0678724b56d4e758af5d46518cf74"));

            }
            if (rank_tiek == "55")
            {
                Tier.Source = new BitmapImage(new Uri("https://gamepedia.cursecdn.com/dota2_gamepedia/thumb/8/8e/SeasonalRank5-5.png/160px-SeasonalRank5-5.png?version=56e896b0ac5fb17a4945a49c82e0f92f"));

            }

            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            if (rank_tiek == "61")
            {
                Tier.Source = new BitmapImage(new Uri("https://gamepedia.cursecdn.com/dota2_gamepedia/thumb/e/e0/SeasonalRank6-1.png/160px-SeasonalRank6-1.png?version=ff2bf386b79fa205b4fce809415dc297"));

            }
            if (rank_tiek == "62")
            {
                Tier.Source = new BitmapImage(new Uri("https://gamepedia.cursecdn.com/dota2_gamepedia/thumb/1/1c/SeasonalRank6-2.png/160px-SeasonalRank6-2.png?version=e9169087f48445d1b481621d7522cb15"));

            }
            if (rank_tiek == "63")
            {
                Tier.Source = new BitmapImage(new Uri("https://gamepedia.cursecdn.com/dota2_gamepedia/thumb/d/da/SeasonalRank6-3.png/160px-SeasonalRank6-3.png?version=552776c40c887343a55b4e72ea9ba1f5"));

            }
            if (rank_tiek == "64")
            {
                Tier.Source = new BitmapImage(new Uri("https://gamepedia.cursecdn.com/dota2_gamepedia/thumb/d/db/SeasonalRank6-4.png/160px-SeasonalRank6-4.png?version=b96e6cdac16cac16a58e60f4a28a552c"));

            }
            if (rank_tiek == "65")
            {
                Tier.Source = new BitmapImage(new Uri("https://gamepedia.cursecdn.com/dota2_gamepedia/thumb/4/47/SeasonalRank6-5.png/160px-SeasonalRank6-5.png?version=a27cb94937ebbca56068e4d602889b88"));

            }

            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            if (rank_tiek == "71")
            {
                Tier.Source = new BitmapImage(new Uri("https://gamepedia.cursecdn.com/dota2_gamepedia/thumb/b/b7/SeasonalRank7-1.png/160px-SeasonalRank7-1.png?version=af522a37322e68f100b79797ebe9b3d7"));

            }
            if (rank_tiek == "72")
            {
                Tier.Source = new BitmapImage(new Uri("https://gamepedia.cursecdn.com/dota2_gamepedia/thumb/8/8f/SeasonalRank7-2.png/160px-SeasonalRank7-2.png?version=40eb315f0138e8b933fd0a39802701fe"));

            }
            if (rank_tiek == "73")
            {
                Tier.Source = new BitmapImage(new Uri("https://gamepedia.cursecdn.com/dota2_gamepedia/thumb/f/fd/SeasonalRank7-3.png/160px-SeasonalRank7-3.png?version=7d2b0465f63c8116a3ab6a9272a5f3dd"));

            }
            if (rank_tiek == "74")
            {
                Tier.Source = new BitmapImage(new Uri("https://gamepedia.cursecdn.com/dota2_gamepedia/thumb/1/13/SeasonalRank7-4.png/160px-SeasonalRank7-4.png?version=a8632d2f7e234ec88455209facc1ce84"));

            }
            if (rank_tiek == "75")
            {
                Tier.Source = new BitmapImage(new Uri("https://gamepedia.cursecdn.com/dota2_gamepedia/thumb/3/33/SeasonalRank7-5.png/160px-SeasonalRank7-5.png?version=2fe403a83ca5b87e0223b33dc3178b56"));

            }

            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            if (rank_tiek == "80")
                Tier.Source = new BitmapImage(new Uri("https://gamepedia.cursecdn.com/dota2_gamepedia/thumb/a/ad/SeasonalRankTop2.png/160px-SeasonalRankTop2.png?version=995bb2efa880999170983276f91acc2c"));

            if (rank_tiek == "null")
                Tier.Source = new BitmapImage(new Uri("https://riki.dotabuff.com/c/ea66a1a2ca6ef87a83d3e322bc90569a21163b63/68747470733a2f2f7261772e67697468756275736572636f6e74656e742e636f6d2f646f7461627566662f70616e6f72616d612f6d61737465722f70616e6f72616d612f696d616765732f72616e6b5f746965725f69636f6e732f72616e6b305f7073642e706e67"));
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        }
        private async void infoprofile(string id)
        {
            if (!Registry.CurrentUser.CreateSubKey(@"Software\DotaChecker\Friends\").GetSubKeyNames().Contains($"{id}"))
            {
                addfriend.Visibility = Visibility.Visible;
                addfriend.Content = "Add to friends";
                values.ids = id;
            }
            string infoprofile1 = await https(values.apiurl + id);
            infoprofile infoprofile = JsonConvert.DeserializeObject<infoprofile>(infoprofile1);
            github heroandmodes = JsonConvert.DeserializeObject<github>(values.github);
            mainImage.Source = new BitmapImage(new Uri((infoprofile.profile.avatarfull)));
            personaname.Text = infoprofile.profile.personaname;
            name.Text = infoprofile.profile.name;
            if (infoprofile.rank_tier != null)
                Tier.Source = new BitmapImage(new Uri($"{heroandmodes.ranks[infoprofile.rank_tier].source}"));
            else
               Tier.Source = new BitmapImage(new Uri($"https://github.com/sominola/dota2-api/blob/master/images/SeasonalRank0-0.png?raw=true"));
            if (infoprofile.rank_tier == "80")
                RANK.Text = infoprofile.leaderboard_rank;
            else
                RANK.Text = "";
        }
        private async void percent(string id)
        {
            string winrate1 = await https(values.apiurl + id + "/wl");
            percent winrate = JsonConvert.DeserializeObject<percent>(winrate1);
            float percent = 0;
            percent = winrate.win / (winrate.win + winrate.lose) * 100;
            winRate.Text = percent.ToString("0.##") + "%";
            wins.Text = winrate.win.ToString();
            loses.Text = winrate.lose.ToString();
        }
        private async void recentMatch(string id)
        {
            string recentMatch1 = await https(values.apiurl + id + "/recentMatches");
            List<infomatch> recentMatch = JsonConvert.DeserializeObject<List<infomatch>>(recentMatch1);
            const int N = 0;
            if (recentMatch[N].player_slot <= 127 && recentMatch[N].radiant_win == "true" || recentMatch[N].player_slot >= 128 && recentMatch[N].radiant_win == "false")
            {
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
            KDA.Text = recentMatch[N].kills + " / " + recentMatch[N].deaths + " / " + recentMatch[N].assists.ToString();
            var ts = TimeSpan.FromSeconds(recentMatch[N].duration);
            duration.Text = ts.Minutes + ":" + ts.Seconds;
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            string urls = "https://raw.githubusercontent.com/sominola/dota2-api/master/gameinfo.json";
            github heroandmodes = JsonConvert.DeserializeObject<github>(http(urls));
            Heroname.Text = heroandmodes.heroes[$"{recentMatch[N].hero_id}"].localized_name.ToString();
            mode.Text = heroandmodes.Modes[recentMatch[N].game_mode].name.ToString();
            ///HERO ICON START///
            myMediaElement.Source = new Uri($"http://github.com/sominola/dota2-api/blob/master/hero/" + $"{heroandmodes.heroes[$"{recentMatch[N].hero_id}"].name}.mp4?raw=true", UriKind.RelativeOrAbsolute);
            myMediaElement.LoadedBehavior = MediaState.Manual;
            myMediaElement.MediaEnded += delegate { myMediaElement.Position = TimeSpan.FromSeconds(0); myMediaElement.Play(); };
            myMediaElement.Play();
            ///HERO ICON END///
            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        }
        private void FindButton(object sender, RoutedEventArgs e)
        {
            if (ID_TEXT.Text.Length > 0 && !string.IsNullOrWhiteSpace(ID_TEXT.Text))
                async(main, ID_TEXT.Text);
            else errors("Поле пустое или имеет пробел");
        }
    }
}
