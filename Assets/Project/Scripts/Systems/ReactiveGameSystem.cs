using System.Collections.Generic;
using Entitas;
using Zenject;

namespace MergeToStay.Systems
{
	public abstract class ReactiveGameSystem : ReactiveSystem<GameEntity>
	{
		[Inject] protected Contexts _contexts;
		
		protected ReactiveGameSystem() : base(Contexts.sharedInstance.game) { }
	}
}