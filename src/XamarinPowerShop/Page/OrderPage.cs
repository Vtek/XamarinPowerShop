using System;
using Xamarin.Forms;

namespace XamarinPowerShop
{
	/// <summary>
	/// Order page.
	/// </summary>
	public sealed class OrderPage : ContentPage
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="XamarinPowerShop.OrderPage"/> class.
		/// </summary>
		/// <param name="tshirt">Tshirt.</param>
		public OrderPage(TShirt tshirt)
		{
			InitializeComponent(tshirt);
			var viewModel = new OrderViewModel(tshirt);

			viewModel.Failed += async (sender, e) => 
			{
				await DisplayAlert("Failed", "Can't completed your order !", "OK");
				await Navigation.PopModalAsync();
			};

			viewModel.Ordered += async (sender, e) => 
			{
				await DisplayAlert("Many thanks", string.Format("Thanks to purchase a {0}", e.ProductName), "OK");
				await Navigation.PopModalAsync();
			};

			BindingContext = viewModel;
		}

		void InitializeComponent(TShirt tshirt)
		{
			var layout = new StackLayout 
			{
				VerticalOptions = LayoutOptions.Center
			};

			var image = new Image 
			{ 
				HorizontalOptions = LayoutOptions.Center,
				Source = tshirt.Image
			};

			var label = new Label { HorizontalOptions = LayoutOptions.Center, Text = tshirt.Name };

			var genderCell = new SwitchCell { Text = "Women / Men" };
			genderCell.SetBinding<OrderViewModel>(SwitchCell.OnProperty, vm => vm.IsMen);


			var sizeLabel = new Label { Text = "Size", HorizontalOptions = LayoutOptions.StartAndExpand, VerticalOptions = LayoutOptions.Center }; 
			var sizePicker = new Picker { Title = "Small", WidthRequest = 100.0, HorizontalOptions = LayoutOptions.EndAndExpand, VerticalOptions = LayoutOptions.Center };
			sizePicker.Items.Add("Small");
			sizePicker.Items.Add("Medium");
			sizePicker.Items.Add("Large");
			sizePicker.Items.Add("X-Large");
			sizePicker.SetBinding<OrderViewModel>(Picker.SelectedIndexProperty, vm => vm.SizeIndex);

			var sizeLayout = new StackLayout
			{
				Padding = new Thickness(15, 0),
				Spacing = 0, 
				Orientation = StackOrientation.Horizontal,
				Children = 
				{
					sizeLabel,
					sizePicker
				}
			};

			var sizeCell = new ViewCell 
			{ 
				View = sizeLayout
			};

			var optionSection = new TableSection { Title = "Options" };
			optionSection.Add(genderCell);
			optionSection.Add(sizeCell);

			var tableView = new TableView
			{
				Intent = TableIntent.Form,
				HeightRequest = 300.0,
				Root = new TableRoot
				{
					optionSection
				}
			};

			var buttonCancel = new Button { HorizontalOptions = LayoutOptions.EndAndExpand, Text = "Cancel" };
			buttonCancel.Clicked += async (sender, e) => await Navigation.PopModalAsync();

			var buttonOrder = new Button { HorizontalOptions = LayoutOptions.StartAndExpand, Text = "Purchase" };
			buttonOrder.SetBinding<OrderViewModel>(Button.CommandProperty, vm => vm.OrderCommand);

			var bottomLayout = new StackLayout 
			{ 
				Spacing = 0, 
				Orientation = StackOrientation.Horizontal, 
				Children = 
				{ 
					buttonCancel,
					new Label
					{
						HorizontalOptions = LayoutOptions.CenterAndExpand
					},
					buttonOrder
				} 
			};

			layout.Children.Add(image);
			layout.Children.Add(label);
			layout.Children.Add(tableView);
			layout.Children.Add(bottomLayout);

			Content = layout;
		}
	}
}

