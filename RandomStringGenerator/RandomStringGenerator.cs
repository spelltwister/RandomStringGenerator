using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography;

namespace CaptainPav.Utility.RandomStringGenerator
{
	public class RandomStringGenerator : IRandomStringGenerator, IDisposable
	{
		/// <summary>
		/// Gets the random number generator used to generate random strings
		/// </summary>
		protected RandomNumberGenerator Rng { get; private set; }

		/// <summary>
		/// Gets the list of characters that can appear in the result string
		/// </summary>
		protected IReadOnlyList<char> Characters => CharactersPrivate;

		private ReadOnlyCollection<char> CharactersPrivate { get; }

		/// <summary>
		/// Initializes a new instance of the <see cref="RandomStringGenerator" /> class.
		/// </summary>
		/// <param name="characters">
		/// Characters allowed to appear in the result string
		/// </param>
		public RandomStringGenerator(IEnumerable<char> characters)
		{
			this.CharactersPrivate = new ReadOnlyCollection<char>(characters.ToArray());
			this.Rng = RandomNumberGenerator.Create();
		}

		public string Generate(int length)
		{
			return Generate(this.Rng, this.CharactersPrivate, length);
		}

		/// <summary>
		/// Generates a random string containing only characters from the
		/// characters list and with the specified length
		/// </summary>
		/// <param name="rng">
		/// The RandomNumberGenerator used to generate the random string
		/// </param>
		/// <param name="characters">
		/// The list of characters which are allowed to appear
		/// in the result string
		/// </param>
		/// <param name="length">
		/// The length of the random string to generate
		/// </param>
		/// <returns>
		/// A random string containing only characters from the
		/// characters list and with the specified length
		/// </returns>
		public static string Generate(RandomNumberGenerator rng, IList<char> characters, int length)
		{
			byte[] randomData = new byte[length];
			rng.GetBytes(randomData);

			char[] identifier = new char[length];
			for (int idx = 0; idx < length; idx++)
			{
				int pos = randomData[idx] % characters.Count;
				identifier[idx] = characters[pos];
			}

			return new string(identifier);
		}

		/// <inheritdoc />
		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		/// <summary>
		/// Disposes the managed resources
		/// </summary>
		/// <param name="isDisposing">
		/// True if called from the Dispose method; otherwise, false
		/// </param>
		protected virtual void Dispose(bool isDisposing)
		{
			this.Rng?.Dispose();
			this.Rng = null;
		}
	}
}