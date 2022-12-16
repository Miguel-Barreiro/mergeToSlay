//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public MergeToStay.Components.Combat.ChangeCombatStateEvent changeCombatStateEvent { get { return (MergeToStay.Components.Combat.ChangeCombatStateEvent)GetComponent(GameComponentsLookup.ChangeCombatStateEvent); } }
    public bool hasChangeCombatStateEvent { get { return HasComponent(GameComponentsLookup.ChangeCombatStateEvent); } }

    public void AddChangeCombatStateEvent(MergeToStay.Components.Combat.Battle.Battle.BattleState newNewState) {
        var index = GameComponentsLookup.ChangeCombatStateEvent;
        var component = (MergeToStay.Components.Combat.ChangeCombatStateEvent)CreateComponent(index, typeof(MergeToStay.Components.Combat.ChangeCombatStateEvent));
        component.NewState = newNewState;
        AddComponent(index, component);
    }

    public void ReplaceChangeCombatStateEvent(MergeToStay.Components.Combat.Battle.Battle.BattleState newNewState) {
        var index = GameComponentsLookup.ChangeCombatStateEvent;
        var component = (MergeToStay.Components.Combat.ChangeCombatStateEvent)CreateComponent(index, typeof(MergeToStay.Components.Combat.ChangeCombatStateEvent));
        component.NewState = newNewState;
        ReplaceComponent(index, component);
    }

    public void RemoveChangeCombatStateEvent() {
        RemoveComponent(GameComponentsLookup.ChangeCombatStateEvent);
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

    static Entitas.IMatcher<GameEntity> _matcherChangeCombatStateEvent;

    public static Entitas.IMatcher<GameEntity> ChangeCombatStateEvent {
        get {
            if (_matcherChangeCombatStateEvent == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.ChangeCombatStateEvent);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherChangeCombatStateEvent = matcher;
            }

            return _matcherChangeCombatStateEvent;
        }
    }
}