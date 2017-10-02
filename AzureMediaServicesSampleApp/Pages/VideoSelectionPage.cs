using System;

using Xamarin.Forms;

namespace AzureMediaServicesSampleApp
{
	public class VideoSelectionPage : ContentPage
	{
		readonly Button _webViewPageButton, _nativeVideoPlayerButton;

		public VideoSelectionPage()
		{
			_webViewPageButton = new Button { Text = "Watch As WebView" };
			_nativeVideoPlayerButton = new Button { Text = "Watch in Native Video Player" };

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
					_webViewPageButton,
					_nativeVideoPlayerButton
				}
			};
			switch (Device.RuntimePlatform)
			{
				case Device.Android:
					stackLayout.Children.Add(androidEmulatorLabel);
					break;
			}

			Content = stackLayout;
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();

			_webViewPageButton.Clicked += HandleWebViewPageButtonClicked;
			_nativeVideoPlayerButton.Clicked += HandleNativeVideoPlayerButtonClicked;
		}

		protected override void OnDisappearing()
		{
			base.OnDisappearing();

			_webViewPageButton.Clicked -= HandleWebViewPageButtonClicked;
			_nativeVideoPlayerButton.Clicked -= HandleNativeVideoPlayerButtonClicked;
		}

		void HandleWebViewPageButtonClicked(object sender, EventArgs e) =>
			Device.BeginInvokeOnMainThread(async () => await Navigation.PushAsync(new VideoWebViewPage()));

		void HandleNativeVideoPlayerButtonClicked(object sender, EventArgs e) =>
			Device.BeginInvokeOnMainThread(async () => await Navigation.PushAsync(new NativeVideoPlayerPage()));
	}
}
