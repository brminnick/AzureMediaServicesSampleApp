using System;

using Xamarin.Forms;

namespace AzureMediaServicesSampleApp
{
    public class VideoSelectionPage : ContentPage
    {
        public VideoSelectionPage()
        {
            var webViewPageButton = new Button { Text = "Watch As WebView" };
            webViewPageButton.Clicked += HandleWebViewPageButtonClicked;

            var nativeVideoPlayerButton = new Button { Text = "Watch in Native Video Player" };
            nativeVideoPlayerButton.Clicked += HandleNativeVideoPlayerButtonClicked;

            Title = "Choose a Video";

            var stackLayout = new StackLayout
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,

                Children = {
                    webViewPageButton,
                    nativeVideoPlayerButton
                }
            };

            if (Device.RuntimePlatform is Device.Android)
            {
                var androidEmulatorLabel = new Label
                {
                    Text = "Note: Video playback fails when on an Android emulator\n\nPlease run this sample on a physical Android Device",
                    FontAttributes = FontAttributes.Italic,
                    HorizontalTextAlignment = TextAlignment.Center
                };

                stackLayout.Children.Add(androidEmulatorLabel);
            }

            Content = stackLayout;
        }

        async void HandleWebViewPageButtonClicked(object sender, EventArgs e) => await Navigation.PushAsync(new VideoWebViewPage());
        async void HandleNativeVideoPlayerButtonClicked(object sender, EventArgs e) => await Navigation.PushAsync(new NativeVideoPlayerPage());
    }
}
