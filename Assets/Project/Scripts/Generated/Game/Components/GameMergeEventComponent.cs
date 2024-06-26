//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public MergeToStay.Components.Combat.MergeEvent mergeEvent { get { return (MergeToStay.Components.Combat.MergeEvent)GetComponent(GameComponentsLookup.MergeEvent); } }
    public bool hasMergeEvent { get { return HasComponent(GameComponentsLookup.MergeEvent); } }

    public void AddMergeEvent(UnityEngine.Vector2 newOriginCell, UnityEngine.Vector2 newTargetCell) {
        var index = GameComponentsLookup.MergeEvent;
        var component = (MergeToStay.Components.Combat.MergeEvent)CreateComponent(index, typeof(MergeToStay.Components.Combat.MergeEvent));
        component.originCell = newOriginCell;
        component.targetCell = newTargetCell;
        AddComponent(index, component);
    }

    public void ReplaceMergeEvent(UnityEngine.Vector2 newOriginCell, UnityEngine.Vector2 newTargetCell) {
        var index = GameComponentsLookup.MergeEvent;
        var component = (MergeToStay.Components.Combat.MergeEvent)CreateComponent(index, typeof(MergeToStay.Components.Combat.MergeEvent));
        component.originCell = newOriginCell;
        component.targetCell = newTargetCell;
        ReplaceComponent(index, component);
    }

    public void RemoveMergeEvent() {
        RemoveComponent(GameComponentsLookup.MergeEvent);
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherMergeEvent;

    public static Entitas.IMatcher<GameEntity> MergeEvent {
        get {
            if (_matcherMergeEvent == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.MergeEvent);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherMergeEvent = matcher;
            }

            return _matcherMergeEvent;
        }
    }
}
