using System;

using MediaManager;
using MediaManager.Forms;
using MediaManager.Video;

using Xamarin.Forms;

namespace AzureMediaServicesSampleApp
{
    public class NativeVideoPlayerPage : ContentPage
    {
        public NativeVideoPlayerPage()
        {
            var videoView = new VideoView
            {
                Source = MediaConstants.EncryptedVideoUrl,
                VideoAspect = VideoAspectMode.AspectFit
            };

            var playButton = new PlaybackButton("Play");
            playButton.Clicked += HandlePlayButtonClicked;

            var pauseButton = new PlaybackButton("Pause");
            pauseButton.Clicked += HandlePauseButtonClicked;

            var stopButton = new PlaybackButton("Stop");
            stopButton.Clicked += HandleStopButtonClicked;

            var absoluteLayout = new AbsoluteLayout();
            absoluteLayout.Children.Add(videoView, new Rectangle(0, 0, 1, 1), AbsoluteLayoutFlags.All);
            absoluteLayout.Children.Add(playButton, new Rectangle(0.25, 1, -1, -1), AbsoluteLayoutFlags.PositionProportional);
            absoluteLayout.Children.Add(pauseButton, new Rectangle(0.5, 1, -1, -1), AbsoluteLayoutFlags.PositionProportional);
            absoluteLayout.Children.Add(stopButton, new Rectangle(0.75, 1, -1, -1), AbsoluteLayoutFlags.PositionProportional);

            Title = "Native Video Player";

            Content = absoluteLayout;
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            CrossMediaManager.Current.Pause();
        }

        void HandlePlayButtonClicked(object sender, EventArgs e) => CrossMediaManager.Current.Play();
        void HandleStopButtonClicked(object sender, EventArgs e) => CrossMediaManager.Current.Stop();
        void HandlePauseButtonClicked(object sender, EventArgs e) => CrossMediaManager.Current.Pause();

        class PlaybackButton : Button
        {
            public PlaybackButton(string text)
            {
                Text = text;
                BackgroundColor = new Color(255, 255, 255, 0.75);
                Padding = new Thickness(15, 0);
                Margin = new Thickness(0, 15);
            }
        }
    }
}
