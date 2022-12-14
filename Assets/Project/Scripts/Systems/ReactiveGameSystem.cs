using System.Collections.Generic;
using Entitas;

namespace MergeToStay.Systems
{
	public abstract class ReactiveGameSystem : ReactiveSystem<GameEntity>
	{
		protected ReactiveGameSystem() : base(Contexts.sharedInstance.game) { }
	}
}