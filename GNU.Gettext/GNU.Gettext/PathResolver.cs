using System;
using System.Reflection;
using System.Globalization;
using System.IO;

namespace GNU.Gettext
{
	public abstract class PathResolver
	{
		public static readonly PathResolver Default = new SingleNameSeparateFolderPathResolver();

		public abstract string Resolve(string baseDir, String resourceName, CultureInfo culture);
	}

	public class SingleNameSeparateFolderPathResolver : PathResolver
	{
		public override string Resolve(string baseDir, string resourceName, CultureInfo culture)
		{
			string pathToAssembly = Path.Combine(new string[]{ baseDir, culture.Name, resourceName});
			return pathToAssembly;
		}
	}

	public class DifferentNamesSingleFolderPathResolver : PathResolver
	{
		public override string Resolve(string baseDir, string resourceName, CultureInfo culture)
		{
			string asmFileName = string.Format("{0}.dll", UppercaseFirst(culture.Name.Replace("-", "")));
			string pathToAssembly = Path.Combine(baseDir, asmFileName);

			return pathToAssembly;
		}

		private static string UppercaseFirst(string s)
		{
			if (string.IsNullOrEmpty(s))
			{
				return string.Empty;
			}

			char[] a = s.ToCharArray();
			a[0] = char.ToUpper(a[0]);

			return new string(a);
		}
	}
}

