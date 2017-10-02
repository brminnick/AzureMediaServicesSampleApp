using Xamarin.Forms;

using AzureMediaServicesSampleApp.Shared;

namespace AzureMediaServicesSampleApp
{
    public class VideoWebViewPage : ContentPage
    {
        public VideoWebViewPage()
        {
            Title = "Web View Video Player";

            Content = new WebView { Source = MediaConstants.UnencryptedVideoUrl };
        }
    }
}
