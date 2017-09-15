namespace CaptainPav.Utility.RandomStringGenerator
{
	/// <summary>
	/// Random string generator whose strings are Url safe
	/// </summary>
	/// <remarks>
	/// This random string generator can be used to create random values
	/// that can be embedded in hyperlinks without worrying about encoding
	/// </remarks>
	public sealed class RandomUrlSafeStringGenerator : RandomStringGenerator
	{
		/// <summary>
		/// 64 url safe characters
		/// </summary>
		/// <remarks>
		/// To avoid bias, there are 64 url safe characters that can appear in
		/// the generated string
		/// </remarks>
		private static readonly char[] UrlSafeCharacters =
		{
			'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H',
			'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P',
			'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X',
			'Y', 'Z', 'a', 'b', 'c', 'd', 'e', 'f',
			'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n',
			'o', 'p', 'q', 'r', 's', 't', 'u', 'v',
			'w', 'x', 'y', 'z', '0', '1', '2', '3',
			'4', '5', '6', '7', '8', '9', '-', '_'
		};

		public RandomUrlSafeStringGenerator() 
			: base(UrlSafeCharacters)
		{
		}
	}
}