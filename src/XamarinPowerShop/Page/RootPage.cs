using System;
using Xamarin.Forms;
using XamarinPowerShop.Entities;
using System.Collections.Generic;

namespace XamarinPowerShop
{
	/// <summary>
	/// Root page.
	/// </summary>
	public sealed class RootPage : ContentPage
	{
		public RootPage()
		{
			InitializeComponent();
		}

		void InitializeComponent()
		{
			var layout = new StackLayout
			{
				VerticalOptions = LayoutOptions.Center
			};

			var label = new Label
			{
				Text = "T-Shirt shop",
				FontSize = 36.0,
				TextColor = Color.FromRgb(52, 152, 219),
				HorizontalOptions = LayoutOptions.Center
			};

			var tableView = new TableView
			{
				Intent = TableIntent.Menu,
				Root = new TableRoot
				{
					GetTableSection("C# T-Shirt", MockData.GetCsharp()),
					GetTableSection("F# T-Shirt", MockData.GetFsharp())
				}
			};

			layout.Children.Add(label);
			layout.Children.Add(tableView);

			Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 5);
			Content = layout;
		}

		TableSection GetTableSection(string title, List<TShirt> tshirts)
		{
			var fsharpSection = new TableSection();
			fsharpSection.Title = title;
			foreach(var tshirt in tshirts)
			{
				var imageCell = new ImageCell { ImageSource = tshirt.Image, Text = tshirt.Name, Detail = tshirt.Detail, CommandParameter = tshirt };
				imageCell.Tapped += async (sender, e) => await Navigation.PushModalAsync(new OrderPage((TShirt)imageCell.CommandParameter));
				fsharpSection.Add(imageCell);
			}

			return fsharpSection;
		}
	}
}

