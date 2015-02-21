using System;
using System.Windows.Input;
using Xamarin.Forms;
using PowerBI.Api.Client;
using XamarinPowerShop.Entities;

namespace XamarinPowerShop
{
	/// <summary>
	/// Main view model.
	/// </summary>
	public class MainViewModel : ViewModel
	{
		/// <summary>
		/// Occurs when insert.
		/// </summary>
		public event EventHandler Insert;

		/// <summary>
		/// The name of the dataset.
		/// </summary>
		static readonly string DatasetName = "XamarinPowerShop";

		/// <summary>
		/// Gets the insert command.
		/// </summary>
		/// <value>The insert command.</value>
		public ICommand InsertCommand { get; private set; }

		public MainViewModel()
		{
			InsertCommand = new Command(x => {
				var isInsert = PowerBIClient.Do<bool>(api => {
				
					return api.Insert(api.GetDatasetId(DatasetName), new Order
					{
						IsMen = true,
						OrderDate = DateTime.Now,
						ProductName = "C# Blue TShirt",
						ProductReference = "C-R",
						Size = "L"
					});
				});

				if(isInsert)
					OnInsert();
			});
		}

		/// <summary>
		/// Raises the connected event.
		/// </summary>
		protected void OnInsert()
		{
			var tmp = Insert;
			if(tmp != null)
				tmp(this, EventArgs.Empty);
		}
	}
}

