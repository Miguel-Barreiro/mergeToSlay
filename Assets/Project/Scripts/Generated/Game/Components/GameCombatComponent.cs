//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    static readonly MergeToStay.Components.Combat.CombatComponent combatComponent = new MergeToStay.Components.Combat.CombatComponent();

    public bool isCombat {
        get { return HasComponent(GameComponentsLookup.Combat); }
        set {
            if (value != isCombat) {
                var index = GameComponentsLookup.Combat;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : combatComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
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

    static Entitas.IMatcher<GameEntity> _matcherCombat;

    public static Entitas.IMatcher<GameEntity> Combat {
        get {
            if (_matcherCombat == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.Combat);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherCombat = matcher;
            }

            return _matcherCombat;
        }
    }
}
