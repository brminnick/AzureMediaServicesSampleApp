using System;

using Xamarin.Forms;

using Plugin.MediaManager;
using Plugin.MediaManager.Forms;

using AzureMediaServicesSampleApp.Shared;

namespace AzureMediaServicesSampleApp
{
    public class NativeVideoPlayerPage : ContentPage
    {
        readonly VideoView _videoView;
        readonly Button _playButton, _pauseButton, _stopButton;

        public NativeVideoPlayerPage()
        {
            const int horizontalButtonPadding = 5;
            const int verticalButtonPadding = 10;

            Title = "Native Video Player";

            _videoView = new VideoView
            {
                Source = MediaConstants.EncryptedVideoUrl,
                AspectMode = Plugin.MediaManager.Abstractions.Enums.VideoAspectMode.AspectFit
            };

            _playButton = new Button { Text = "Play" };
            _pauseButton = new Button { Text = "Pause" };
            _stopButton = new Button { Text = "Stop" };

            Func<RelativeLayout, double> getPlayButtonHeight = (p) => _playButton.Measure(p.Width, p.Height).Request.Height;
            Func<RelativeLayout, double> getPauseButtonHeight = (p) => _pauseButton.Measure(p.Width, p.Height).Request.Height;
            Func<RelativeLayout, double> getStopButtonHeight = (p) => _stopButton.Measure(p.Width, p.Height).Request.Height;

            var relativeLayout = new RelativeLayout();
            relativeLayout.Children.Add(_videoView,
                                        Constraint.Constant(0),
                                        Constraint.Constant(0),
                                        Constraint.RelativeToParent(parent => parent.Width),
                                        Constraint.RelativeToParent(parent => parent.Height));
            relativeLayout.Children.Add(_playButton,
                                        Constraint.Constant(horizontalButtonPadding),
                                        Constraint.RelativeToParent(parent => parent.Height - verticalButtonPadding - getPlayButtonHeight(parent)),
                                        Constraint.RelativeToParent(parent => (parent.Width - 4 * horizontalButtonPadding) / 3));
            relativeLayout.Children.Add(_pauseButton,
                                        Constraint.RelativeToView(_playButton, (parent, view) => view.X + view.Width + horizontalButtonPadding),
                                        Constraint.RelativeToParent(parent => parent.Height - verticalButtonPadding - getPauseButtonHeight(parent)),
                                        Constraint.RelativeToParent(parent => (parent.Width - 4 * horizontalButtonPadding) / 3));
            relativeLayout.Children.Add(_stopButton,
                                        Constraint.RelativeToView(_pauseButton, (parent, view) => view.X + view.Width + horizontalButtonPadding),
                                        Constraint.RelativeToParent(parent => parent.Height - verticalButtonPadding - getStopButtonHeight(parent)),
                                        Constraint.RelativeToParent(parent => (parent.Width - 4 * horizontalButtonPadding) / 3));

            Content = relativeLayout;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            SubscribeEventHandlers();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            UnsubscribeEventHandlers();

            CrossMediaManager.Current.Pause();
        }

        void SubscribeEventHandlers()
        {
            _playButton.Clicked += HandlePlayButtonClicked;
            _stopButton.Clicked += HandleStopButtonClicked;
            _pauseButton.Clicked += HandlePauseButtonClicked;
        }

        void UnsubscribeEventHandlers()
        {
            _playButton.Clicked -= HandlePlayButtonClicked;
            _stopButton.Clicked -= HandleStopButtonClicked;
            _pauseButton.Clicked -= HandlePauseButtonClicked;
        }

        void HandlePlayButtonClicked(object sender, EventArgs e) => CrossMediaManager.Current.Play();
        void HandleStopButtonClicked(object sender, EventArgs e) => CrossMediaManager.Current.Stop();
        void HandlePauseButtonClicked(object sender, EventArgs e) => CrossMediaManager.Current.Pause();
    }
}
