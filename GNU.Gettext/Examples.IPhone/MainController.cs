using System;
using System.Drawing;
using System.Globalization;

using MonoTouch.UIKit;

using GNU.Gettext;

namespace Examples.IPhone
{
	public class MainController : UIViewController
	{
		public MainController()
		{
			Type t = typeof(MainCatalog_ru_RU);

			View = new UIView();
			View.Frame = new RectangleF(0,0,320, 460);
			View.BackgroundColor = UIColor.White;

			UILabel l = new UILabel();
			l.Frame = new RectangleF(0,0,320,200);
			l.Lines = 0;
			l.LineBreakMode = UILineBreakMode.WordWrap;

			View.AddSubview(l);

			CultureInfo ci = new CultureInfo ("ru-RU");

			GettextResourceManager catalog = new GettextResourceManager ("MainCatalog");

			l.Text += catalog.GetString (Text.MyNameIs, ci);
			l.Text += catalog.GetString (Text.GoodFeet, ci);
			l.Text += catalog.GetString (Text.PerfectFeet, ci);

			for (int i = 0; i < 6; i++)
			{
				l.Text +=  string.Format (catalog.GetPluralString(Text.PluralDay, Text.PluralDays, i, ci), i);
			}
		}
	}
}

