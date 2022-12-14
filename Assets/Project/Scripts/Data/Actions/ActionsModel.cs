namespace MergeToStay.Data
{
	public static class ActionsModel
	{
		[System.Flags]
		public enum CombatTargetsEnum
		{
			NONE = 0, 
			FORWARD = 1 << 1,
			FORWARD2 = 1 << 2,
			MIDDLE = 1 << 3,
			BACK = 1 << 4,
			SELF = 1 << 5,
			ALL = FORWARD | FORWARD2 | MIDDLE | BACK | SELF 
		}
	}
}