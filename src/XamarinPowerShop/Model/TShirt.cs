using System;
using Xamarin.Forms;

namespace XamarinPowerShop
{
	public sealed class TShirt
	{
		public string Detail 
		{
			get
			{ 
				return string.Format("Réf : {0}", Reference);
			}
		}

		public string Name { get; set; }
		public string Reference { get; set; }
		public string ImageFile { get; set; }
		public ImageSource Image 
		{ 
			get
			{ 
				return ImageSource.FromFile(ImageFile);
			} 
		}
	}
}

