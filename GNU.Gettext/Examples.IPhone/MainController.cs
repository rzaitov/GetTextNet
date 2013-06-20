using System;
using System.Drawing;
using System.Globalization;
using System.Text;

using MonoTouch.UIKit;

using GNU.Gettext;

namespace Examples.IPhone
{
	public class MainController : UIViewController
	{
		public MainController()
		{
			//Type t = typeof(MainCatalog_ru_RU);

			View = new UIView();
			View.Frame = new RectangleF(0f, 0f, 320f, 460f);
			View.BackgroundColor = UIColor.White;

			UILabel l = new UILabel();
			l.Frame = new RectangleF(0f, 0f, 320f, 200f);
			l.Lines = 0;
			l.LineBreakMode = UILineBreakMode.WordWrap;

			View.AddSubview(l);

			CultureInfo ci = new CultureInfo ("ru-RU");

			GettextResourceManager catalog = new GettextResourceManager ("MainCatalog", new DifferentNamesSingleFolderPathResolver());

			StringBuilder sb = new StringBuilder();
			sb.AppendLine(catalog.GetString (Text.MyNameIs, ci))
			  .AppendLine(catalog.GetString (Text.MyAge, ci))
			  .AppendLine(catalog.GetString (Text.ILove, ci));

			for (int i = 0; i < 6; i++)
			{
				sb.AppendLine(string.Format (catalog.GetPluralString(Text.PluralDay, Text.PluralDays, i, ci), i));
			}

			l.Text = sb.ToString();
		}
	}
}

