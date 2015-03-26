//
// FAButton.cs
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
using UIKit;

namespace FontAwesomeXamarin
{
	public class FAButton : UIButton
	{
		/// <summary>
		/// Gets or sets the icon for the button. Should be from <see cref="FontAwesome.Xamarin.FontAwesome"/>.
		/// </summary>
		/// <value>The icon.</value>
		public string Icon {
			get {
				return this.Title (UIControlState.Normal);
			}
			set {
				this.SetTitle (value, UIControlState.Normal);
			}
		}

		/// <summary>
		/// Gets or sets the size of the icon
		/// </summary>
		/// <value>The size of the icon.</value>
		public nfloat IconSize{
			get{ return this.Font.PointSize; }
			set{
				this.Font = FontAwesome.Font (value);
			}
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="FontAwesomeXamarin.FAButton"/> class.
		/// This class extends UIButton. It does set set a default Frame. You must do this yourself
		/// </summary>
		/// <param name="icon">Icon.</param>
		/// <param name="fontColor">Font color.</param>
		/// <param name="iconSize">Icon size.</param>
		public FAButton (string icon, UIColor fontColor, float iconSize = 20) : base(UIButtonType.System)
		{
			Icon = icon;
			IconSize = iconSize;
			this.SetTitleColor (fontColor, UIControlState.Normal);
			this.SetTitleColor (fontColor.ColorWithAlpha(100), UIControlState.Highlighted);
		}
	}
}
