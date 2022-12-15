//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public MergeToStay.Components.Combat.DragGridObjectUpdateComponent dragGridObjectUpdate { get { return (MergeToStay.Components.Combat.DragGridObjectUpdateComponent)GetComponent(GameComponentsLookup.DragGridObjectUpdate); } }
    public bool hasDragGridObjectUpdate { get { return HasComponent(GameComponentsLookup.DragGridObjectUpdate); } }

    public void AddDragGridObjectUpdate(UnityEngine.Vector2 newOriginCell, UnityEngine.GameObject newDraggedGameObject) {
        var index = GameComponentsLookup.DragGridObjectUpdate;
        var component = (MergeToStay.Components.Combat.DragGridObjectUpdateComponent)CreateComponent(index, typeof(MergeToStay.Components.Combat.DragGridObjectUpdateComponent));
        component.OriginCell = newOriginCell;
        component.DraggedGameObject = newDraggedGameObject;
        AddComponent(index, component);
    }

    public void ReplaceDragGridObjectUpdate(UnityEngine.Vector2 newOriginCell, UnityEngine.GameObject newDraggedGameObject) {
        var index = GameComponentsLookup.DragGridObjectUpdate;
        var component = (MergeToStay.Components.Combat.DragGridObjectUpdateComponent)CreateComponent(index, typeof(MergeToStay.Components.Combat.DragGridObjectUpdateComponent));
        component.OriginCell = newOriginCell;
        component.DraggedGameObject = newDraggedGameObject;
        ReplaceComponent(index, component);
    }

    public void RemoveDragGridObjectUpdate() {
        RemoveComponent(GameComponentsLookup.DragGridObjectUpdate);
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

    static Entitas.IMatcher<GameEntity> _matcherDragGridObjectUpdate;

    public static Entitas.IMatcher<GameEntity> DragGridObjectUpdate {
        get {
            if (_matcherDragGridObjectUpdate == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.DragGridObjectUpdate);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherDragGridObjectUpdate = matcher;
            }

            return _matcherDragGridObjectUpdate;
        }
    }
}
