using System;
using Xamarin.Forms;

namespace XamarinPowerShop
{
	/// <summary>
	/// T shirt.
	/// </summary>
	public sealed class TShirt
	{
		/// <summary>
		/// Gets the ref detail.
		/// </summary>
		/// <value>The detail.</value>
		public string Detail 
		{
			get
			{ 
				return string.Format("Ref : {0}", Reference);
			}
		}

		/// <summary>
		/// Gets or sets the name.
		/// </summary>
		/// <value>The name.</value>
		public string Name { get; set; }

		/// <summary>
		/// Gets or sets the reference.
		/// </summary>
		/// <value>The reference.</value>
		public string Reference { get; set; }

		/// <summary>
		/// Gets or sets the image file.
		/// </summary>
		/// <value>The image file.</value>
		public string ImageFile { get; set; }

		/// <summary>
		/// Gets the image.
		/// </summary>
		/// <value>The image.</value>
		public ImageSource Image 
		{ 
			get
			{ 
				return ImageSource.FromFile(ImageFile);
			} 
		}
	}
}

