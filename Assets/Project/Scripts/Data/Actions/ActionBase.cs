using MergeToStay.Services;
using UnityEngine;

namespace MergeToStay.Data.Actions
{
	public class ActionBase : ScriptableObject
	{ 
		virtual public void Execute(GameEntity battleEntity, GameEntity boardEntity, GameEntity playerEntity, 
									CombatService combatService, BoardService boardService) { }
	}
	
}