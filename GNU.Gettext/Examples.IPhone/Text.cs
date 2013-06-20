using System;

namespace Examples.IPhone
{
	public static class Text
	{
		public static readonly string MyNameIs = "__MyNameIs__";
		public static readonly string MyAge = "__MyAge__";
		public static readonly string ILove = "__ILove__";
		public static readonly string PluralDay = "__PluralDay__";
		public static readonly string PluralDays = "__PluralDays__";
	}

#if NEVERCOMPILE
	GetPluralString ("__PluralDay__", "__PluralDays__", 1);
	GetString("__MyNameIs__");
	GetString("__MyAge__");
	GetString("__ILove__");
#endif
}