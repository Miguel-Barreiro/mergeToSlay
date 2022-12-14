//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public MergeToStay.Components.GridObject gridObject { get { return (MergeToStay.Components.GridObject)GetComponent(GameComponentsLookup.GridObject); } }
    public bool hasGridObject { get { return HasComponent(GameComponentsLookup.GridObject); } }

    public void AddGridObject(UnityEngine.Vector2 newGridPosition) {
        var index = GameComponentsLookup.GridObject;
        var component = (MergeToStay.Components.GridObject)CreateComponent(index, typeof(MergeToStay.Components.GridObject));
        component.GridPosition = newGridPosition;
        AddComponent(index, component);
    }

    public void ReplaceGridObject(UnityEngine.Vector2 newGridPosition) {
        var index = GameComponentsLookup.GridObject;
        var component = (MergeToStay.Components.GridObject)CreateComponent(index, typeof(MergeToStay.Components.GridObject));
        component.GridPosition = newGridPosition;
        ReplaceComponent(index, component);
    }

    public void RemoveGridObject() {
        RemoveComponent(GameComponentsLookup.GridObject);
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

    static Entitas.IMatcher<GameEntity> _matcherGridObject;

    public static Entitas.IMatcher<GameEntity> GridObject {
        get {
            if (_matcherGridObject == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.GridObject);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherGridObject = matcher;
            }

            return _matcherGridObject;
        }
    }
}