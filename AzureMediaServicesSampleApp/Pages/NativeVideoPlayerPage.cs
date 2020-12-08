using System;

using MediaManager;
using MediaManager.Forms;
using MediaManager.Video;
using Xamarin.CommunityToolkit.Markup;
using Xamarin.Forms;
using static AzureMediaServicesSampleApp.MarkupExtensions;
using static Xamarin.CommunityToolkit.Markup.GridRowsColumns;

namespace AzureMediaServicesSampleApp
{
    public class NativeVideoPlayerPage : ContentPage
    {
        public NativeVideoPlayerPage()
        {
            Title = "Native Video Player";

            Content = new Grid
            {
                RowDefinitions = Rows.Define(
                    (Row.Video, Star),
                    (Row.Controls, AbsoluteGridLength(100))),

                Children =
                {
                    new VideoView
                    {
                        Source = MediaConstants.EncryptedVideoUrl,
                        VideoAspect = VideoAspectMode.AspectFit
                    }.Row(Row.Video).ColumnSpan(All<Column>()),

                    new PlaybackButton("Play").Row(Row.Controls).Column(Column.Play)
                        .Invoke(playButton => playButton.Clicked += HandlePlayButtonClicked),

                    new PlaybackButton("Pause").Row(Row.Controls).Column(Column.Pause)
                        .Invoke(pauseButton => pauseButton.Clicked += HandlePauseButtonClicked),

                    new PlaybackButton("Stop").Row(Row.Controls).Column(Column.Stop)
                        .Invoke(stopButton => stopButton.Clicked += HandleStopButtonClicked)
                }
            };
        }

        enum Row { Video, Controls }
        enum Column { Play, Pause, Stop }

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
