//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public MergeToStay.Components.Combat.Battle.Battle battle { get { return (MergeToStay.Components.Combat.Battle.Battle)GetComponent(GameComponentsLookup.Battle); } }
    public bool hasBattle { get { return HasComponent(GameComponentsLookup.Battle); } }

    public void AddBattle(System.Collections.Generic.List<GameEntity> newEnemies, int newCardDrawLevel) {
        var index = GameComponentsLookup.Battle;
        var component = (MergeToStay.Components.Combat.Battle.Battle)CreateComponent(index, typeof(MergeToStay.Components.Combat.Battle.Battle));
        component.Enemies = newEnemies;
        component.CardDrawLevel = newCardDrawLevel;
        AddComponent(index, component);
    }

    public void ReplaceBattle(System.Collections.Generic.List<GameEntity> newEnemies, int newCardDrawLevel) {
        var index = GameComponentsLookup.Battle;
        var component = (MergeToStay.Components.Combat.Battle.Battle)CreateComponent(index, typeof(MergeToStay.Components.Combat.Battle.Battle));
        component.Enemies = newEnemies;
        component.CardDrawLevel = newCardDrawLevel;
        ReplaceComponent(index, component);
    }

    public void RemoveBattle() {
        RemoveComponent(GameComponentsLookup.Battle);
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

    static Entitas.IMatcher<GameEntity> _matcherBattle;

    public static Entitas.IMatcher<GameEntity> Battle {
        get {
            if (_matcherBattle == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.Battle);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherBattle = matcher;
            }

            return _matcherBattle;
        }
    }
}
