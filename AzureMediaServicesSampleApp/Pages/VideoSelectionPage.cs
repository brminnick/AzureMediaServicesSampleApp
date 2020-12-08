using System;
using Xamarin.CommunityToolkit.Markup;
using Xamarin.Forms;

namespace AzureMediaServicesSampleApp
{
    public class VideoSelectionPage : ContentPage
    {
        public VideoSelectionPage()
        {
            Title = "Choose a Video";


            Content = new StackLayout
            {
                Children =
                {
                    new Button { Text = "Watch As WebView" }
                        .Invoke(webViewPageButton => webViewPageButton.Clicked += HandleWebViewPageButtonClicked),

                    new Button { Text = "Watch in Native Video Player" }
                        .Invoke(nativeVideoPlayerButton => nativeVideoPlayerButton.Clicked += HandleNativeVideoPlayerButtonClicked)
                }
            }.Center().Assign(out StackLayout stackLayout);

            if (Device.RuntimePlatform is Device.Android)
            {
                stackLayout.Children.Add(new Label { Text = "Note: Video playback may fail when on an Android emulator\n\nPlease run this sample on a physical Android Device" }
                                            .Font(italic: true).TextCenter());
            }
        }

        async void HandleWebViewPageButtonClicked(object sender, EventArgs e) => await Navigation.PushAsync(new VideoWebViewPage());
        async void HandleNativeVideoPlayerButtonClicked(object sender, EventArgs e) => await Navigation.PushAsync(new NativeVideoPlayerPage());
    }
}
