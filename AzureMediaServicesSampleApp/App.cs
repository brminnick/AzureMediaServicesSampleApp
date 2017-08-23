using Xamarin.Forms;

namespace AzureMediaServicesSampleApp
{
    public class App : Application
    {
        public App() =>
            MainPage = new ContentPage
            {
                Content = new WebView
                {
                    Source = "https://amssamples.streaming.mediaservices.windows.net/2e91931e-0d29-482b-a42b-9aadc93eb825/AzurePromo.mp4"
                }
            };
    }
}
