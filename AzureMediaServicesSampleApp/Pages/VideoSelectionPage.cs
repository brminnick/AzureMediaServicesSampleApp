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

            var androidEmulatorLabel = new Label
            {
                Text = "Note: Video playback fails when on an Android emulator\n\nPlease run this sample on a physical Android Device",
                FontAttributes = FontAttributes.Italic,
                HorizontalTextAlignment = TextAlignment.Center
            };

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
                stackLayout.Children.Add(androidEmulatorLabel);

            Content = stackLayout;
        }

        void HandleWebViewPageButtonClicked(object sender, EventArgs e) =>
            Device.BeginInvokeOnMainThread(async () => await Navigation.PushAsync(new VideoWebViewPage()));

        void HandleNativeVideoPlayerButtonClicked(object sender, EventArgs e) =>
            Device.BeginInvokeOnMainThread(async () => await Navigation.PushAsync(new NativeVideoPlayerPage()));
    }
}
