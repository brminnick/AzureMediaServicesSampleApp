using Xamarin.Forms;

namespace AzureMediaServicesSampleApp
{
    public class App : Application
    {
        public App() => MainPage = new NavigationPage(new VideoSelectionPage());
    }
}
