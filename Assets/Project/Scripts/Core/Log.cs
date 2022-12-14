
using UnityEngine;

namespace MergeToSlay.Core
{
	public static class Log
	{
		public static void Normal(string text)
		{
			Debug.Log(text);
		}

		public static void Warning(string text)
		{
			Debug.LogWarning(text);			
		}

		public static void Error(string text)
		{
			Debug.LogError(text);			
		}

	}
}