namespace CaptainPav.Utility.RandomStringGenerator
{
	/// <summary>
	/// Interface for generating random strings
	/// </summary>
	/// <remarks>
	/// It is important to understand that random and unique are not the same.
	/// </remarks>
	public interface IRandomStringGenerator
	{
		/// <summary>
		/// Generates a random string of the specified length
		/// </summary>
		/// <param name="length">
		/// Length of the random string to generate
		/// </param>
		/// <returns>
		/// A random string of the specified length
		/// </returns>
		string Generate(int length);
	}
}