namespace MergeToStay.Data
{
	public static class Actions
	{
		[System.Flags]
		public enum TargetsEnum
		{
			NONE = 0, 
			FORWARD = 1 << 1,
			MIDDLE1 = 1 << 2,
			MIDDLE2 = 1 << 3,
			BACK = 1 << 4,
			ALL = FORWARD | MIDDLE1 | MIDDLE2 | BACK
		}
	}
}