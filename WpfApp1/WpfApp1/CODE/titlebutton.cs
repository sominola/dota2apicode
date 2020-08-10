using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Windows;
using System.Windows.Input;

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        System.Windows.Forms.NotifyIcon notifyIcons = new System.Windows.Forms.NotifyIcon();
        private void notify()
        {
            notifyIcons.ContextMenuStrip = new System.Windows.Forms.ContextMenuStrip();
            notifyIcons.Icon = new Icon(@"ico.ico");
            notifyIcons.Visible = false;
            notifyIcons.BalloonTipTitle = "Dota 2 Checker";
            notifyIcons.BalloonTipText = "Приложение было свернуто в трей!";
            notifyIcons.Text = "Dota 2 Checker";
            notifyIcons.ContextMenuStrip.Items.Add("Exit", null, Exit_Click);
            notifyIcons.MouseClick += (source, e) =>
            {
                if (e.Button == System.Windows.Forms.MouseButtons.Left)
                {
                    this.Show();
                    notifyIcons.Visible = false;
                    WindowState = WindowState.Normal;
                }


            };
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
            Close();
        }
        private void DragMove(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }
    }
    public partial class Myprofiles : Window
    {
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
        private void Exit_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void DragMove(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }
    }
}
