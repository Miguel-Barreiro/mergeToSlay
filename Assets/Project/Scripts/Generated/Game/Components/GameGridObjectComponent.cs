//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public MergeToSlay.Components.GridObject gridObject { get { return (MergeToSlay.Components.GridObject)GetComponent(GameComponentsLookup.GridObject); } }
    public bool hasGridObject { get { return HasComponent(GameComponentsLookup.GridObject); } }

    public void AddGridObject(System.Nullable<UnityEngine.Vector2> newGridPosition, UnityEngine.GameObject newView) {
        var index = GameComponentsLookup.GridObject;
        var component = (MergeToSlay.Components.GridObject)CreateComponent(index, typeof(MergeToSlay.Components.GridObject));
        component.GridPosition = newGridPosition;
        component.View = newView;
        AddComponent(index, component);
    }

    public void ReplaceGridObject(System.Nullable<UnityEngine.Vector2> newGridPosition, UnityEngine.GameObject newView) {
        var index = GameComponentsLookup.GridObject;
        var component = (MergeToSlay.Components.GridObject)CreateComponent(index, typeof(MergeToSlay.Components.GridObject));
        component.GridPosition = newGridPosition;
        component.View = newView;
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
