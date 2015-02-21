using System;
using XamarinPowerShop.Entities;
using System.Windows.Input;
using Xamarin.Forms;
using PowerBI.Api.Client;
using System.Collections.Generic;

namespace XamarinPowerShop
{
	/// <summary>
	/// Order view model.
	/// </summary>
	public sealed class OrderViewModel : ViewModel
	{
		/// <summary>
		/// The name of the dataset.
		/// </summary>
		static readonly string DatasetName = "XamarinPowerShop";

		/// <summary>
		/// Occurs when insert.
		/// </summary>
		public event EventHandler<Order> Ordered;

		/// <summary>
		/// Occurs when failed.
		/// </summary>
		public event EventHandler Failed;

		/// <summary>
		/// Gets or sets the current.
		/// </summary>
		/// <value>The current.</value>
		TShirt Current { get; set; }

		/// <summary>
		/// Gets or sets the size.
		/// </summary>
		/// <value>The size.</value>
		int _sizeIndex;
		public int SizeIndex
		{
			get
			{ 
				return _sizeIndex;
			}
			set
			{ 
				if(_sizeIndex != value)
				{
					_sizeIndex = value;
					OnPropertyChanged("SizeIndex");
				}
			}
		}
			
		/// <summary>
		/// Gets or sets a value indicating whether this instance is men.
		/// </summary>
		/// <value><c>true</c> if this instance is men; otherwise, <c>false</c>.</value>
		bool _isMen;
		public bool IsMen
		{
			get
			{ 
				return _isMen;
			}
			set
			{ 
				if(_isMen != value)
				{
					_isMen = value;
					OnPropertyChanged("IsMen");
				}
			}
		}

		/// <summary>
		/// Gets the sizes.
		/// </summary>
		/// <value>The sizes.</value>
		List<string> _sizes = new List<string> { "Small", "Medium", "Large", "X-Large" };
		public List<string> Sizes 
		{
			get
			{ 
				return _sizes;
			}
		}

		/// <summary>
		/// Gets the Order command.
		/// </summary>
		/// <value>The insert command.</value>
		public ICommand OrderCommand { get; private set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="XamarinPowerShop.OrderViewModel"/> class.
		/// </summary>
		/// <param name="tshirt">Tshirt.</param>
		public OrderViewModel(TShirt tshirt)
		{
			Current = tshirt;

			OrderCommand = new Command(x => {
				var now = DateTime.Now;

				var order = new Order 
				{ 
					IsMen = IsMen, 
					OrderDate = now, 
					ProductName = Current.Name, 
					ProductReference = Current.Reference,
					Size = Sizes[SizeIndex],
					HourSlots = now.Hour,
					TimeSlots = new DateTime(now.Year, now.Month, now.Day)
				};

				var isOrdered = PowerBIClient.Do<bool>(api => api.Insert(api.GetDatasetId(DatasetName), order));

				if(isOrdered)
					OnOrdered(order);
				else
					OnFailed();
			});
		}

		/// <summary>
		/// Raises the ordered event.
		/// </summary>
		/// <param name="order">Order.</param>
		void OnOrdered(Order order)
		{
			var tmp = Ordered;
			if(tmp != null)
				tmp(this, order);
		}

		/// <summary>
		/// Raises the failed event.
		/// </summary>
		void OnFailed()
		{
			var tmp = Failed;
			if(tmp != null)
				tmp(this, EventArgs.Empty);
		}
	}
}

