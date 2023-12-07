using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using Nutricion.Pages;

namespace Nutricion
{
    public partial class App : Application
    {   
        public static Repository IMCrepository { get; set; }
        public App(Repository repository)
        {
            InitializeComponent();

            MainPage = new NavigationPage(new LoginPage());

            AppCenter.Start("android=454d8a4b-0ae7-4b97-b901-6941a371744f;" +
                  "uwp={Your UWP App secret here};" +
                  "ios={Your iOS App secret here};" +
                  "macos={Your macOS App secret here};",
                  typeof(Analytics), typeof(Crashes));

            IMCrepository = repository;
        }
    }
}