using Xamarin.Forms;

namespace AzureMediaServicesSampleApp
{
    public class VideoWebViewPage : ContentPage
    {
        public VideoWebViewPage()
        {
            Title = "Web View Video Player";
            
            Content = new WebView { Source = MediaConstants.VideoUrl };
        }
    }
}
