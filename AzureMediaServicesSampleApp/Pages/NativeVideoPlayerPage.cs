using Xamarin.Forms;

using Plugin.MediaManager.Forms;

using AzureMediaServicesSampleApp.Shared;

namespace AzureMediaServicesSampleApp
{
    public class NativeVideoPlayerPage : ContentPage
    {
        public NativeVideoPlayerPage()
        {
            Title = "Native Video Player";

            Content = new VideoView { Source = MediaConstants.EncryptedVideoUrl };
        }
    }
}
