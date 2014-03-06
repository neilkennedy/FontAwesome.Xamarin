//
// FABarButtonItem.cs
//
// Author:
//       Neil Kennedy <neil.p.kennedy@outlook.com>
//
// Copyright (c) 2014 neilkennedy
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
using System;
using MonoTouch.UIKit;
using System.Drawing;

namespace FontAwesomeXamarin
{
	public class FABarButtonItem : UIBarButtonItem
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="FontAwesome.Xamarin.FABarButtonItem"/> class.
		/// Use the CustomView property to access the button that we create with the new icon
		/// </summary>
		/// <param name="icon">An icon from <see cref="FontAwesome.Xamarin.FontAwesome"/></param>
		/// <param name="fontColor">The UIColor for the icon and title</param>
		/// <param name="handler">The event handler for when the button is pressed</param>
		public FABarButtonItem (string icon, UIColor fontColor, EventHandler handler) : base()
		{
			var iconButton = new UIButton (new RectangleF (0, 0, 32, 32)) {
				Font = FontAwesome.Font (25)
			};
			iconButton.SetTitle (icon, UIControlState.Normal);
			iconButton.SetTitleColor (fontColor, UIControlState.Normal);
			iconButton.TouchUpInside += handler;

			CustomView = iconButton;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="FontAwesomeXamarin.FABarButtonItem"/> class.
		/// </summary>
		/// <param name="icon">An icon from <see cref="FontAwesome.Xamarin.FontAwesome"/></param>
		/// <param name="title">A title to display under the icon</param>
		/// <param name="fontColor">The UIColor for the icon and title</param>
		/// <param name="handler">The event handler for when the button is pressed</param>
		public FABarButtonItem (string icon, string title, UIColor fontColor, EventHandler handler) : base()
		{
			UIView view = new UIView (new RectangleF (0, 0, 32, 32));
			UILabel label = new UILabel (new RectangleF (0, 22, 32, 10)) {
				Text = title,
				TextColor = fontColor,
				Font = UIFont.SystemFontOfSize(10f),
				TextAlignment = UITextAlignment.Center
			};

			UIButton button = new UIButton (new RectangleF (0, 0, 32, 16)) {
				Font = FontAwesome.Font (25),
			};
			button.SetTitle (icon, UIControlState.Normal);
			button.SetTitleColor (fontColor, UIControlState.Normal);
			button.TouchUpInside += handler;

			view.Add (button);
			view.Add (label);

			CustomView = view;
		}
	}
}
