using System;
using System.Windows;

namespace Reborn
{
    public partial class App : Application
    {
        [STAThread]
        public static void Main()
        {
            var application = new App();
            application.InitializeComponent();
            application.Run();
        }
    }
}
