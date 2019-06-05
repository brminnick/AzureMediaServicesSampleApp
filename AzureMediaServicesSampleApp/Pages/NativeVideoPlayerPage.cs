using System;

using Xamarin.Forms;

using Plugin.MediaManager;
using Plugin.MediaManager.Forms;

namespace AzureMediaServicesSampleApp
{
    public class NativeVideoPlayerPage : ContentPage
    {
        public NativeVideoPlayerPage()
        {
            const int horizontalButtonPadding = 5;
            const int verticalButtonPadding = 10;

            var videoView = new VideoView
            {
                Source = MediaConstants.EncryptedVideoUrl,
                AspectMode = Plugin.MediaManager.Abstractions.Enums.VideoAspectMode.AspectFit
            };

            var playButton = new Button { Text = "Play" };
            playButton.Clicked += HandlePlayButtonClicked;

            var pauseButton = new Button { Text = "Pause" };
            pauseButton.Clicked += HandlePauseButtonClicked;

            var stopButton = new Button { Text = "Stop" };
            stopButton.Clicked += HandleStopButtonClicked;

            var relativeLayout = new RelativeLayout();
            relativeLayout.Children.Add(videoView,
                                        Constraint.Constant(0),
                                        Constraint.Constant(0),
                                        Constraint.RelativeToParent(parent => parent.Width),
                                        Constraint.RelativeToParent(parent => parent.Height));
            relativeLayout.Children.Add(playButton,
                                        Constraint.Constant(horizontalButtonPadding),
                                        Constraint.RelativeToParent(parent => parent.Height - verticalButtonPadding - getPlayButtonHeight(parent)),
                                        Constraint.RelativeToParent(parent => (parent.Width - 4 * horizontalButtonPadding) / 3));
            relativeLayout.Children.Add(pauseButton,
                                        Constraint.RelativeToView(playButton, (parent, view) => view.X + view.Width + horizontalButtonPadding),
                                        Constraint.RelativeToParent(parent => parent.Height - verticalButtonPadding - getPauseButtonHeight(parent)),
                                        Constraint.RelativeToParent(parent => (parent.Width - 4 * horizontalButtonPadding) / 3));
            relativeLayout.Children.Add(stopButton,
                                        Constraint.RelativeToView(pauseButton, (parent, view) => view.X + view.Width + horizontalButtonPadding),
                                        Constraint.RelativeToParent(parent => parent.Height - verticalButtonPadding - getStopButtonHeight(parent)),
                                        Constraint.RelativeToParent(parent => (parent.Width - 4 * horizontalButtonPadding) / 3));

            Title = "Native Video Player";

            Content = relativeLayout;

            double getPlayButtonHeight(RelativeLayout p) => playButton.Measure(p.Width, p.Height).Request.Height;
            double getPauseButtonHeight(RelativeLayout p) => pauseButton.Measure(p.Width, p.Height).Request.Height;
            double getStopButtonHeight(RelativeLayout p) => stopButton.Measure(p.Width, p.Height).Request.Height;
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            CrossMediaManager.Current.Pause();
        }

        void HandlePlayButtonClicked(object sender, EventArgs e) => CrossMediaManager.Current.Play();
        void HandleStopButtonClicked(object sender, EventArgs e) => CrossMediaManager.Current.Stop();
        void HandlePauseButtonClicked(object sender, EventArgs e) => CrossMediaManager.Current.Pause();
    }
}
