using Entitas;

namespace MergeToStay.Components.Combat
{
	public class ChangeCombatStateEvent:IComponent
	{
		public Battle.Battle.BattleState NewState;
	}
}