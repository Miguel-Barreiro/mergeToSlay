//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public MergeToStay.Components.Path.PathComponent path { get { return (MergeToStay.Components.Path.PathComponent)GetComponent(GameComponentsLookup.Path); } }
    public bool hasPath { get { return HasComponent(GameComponentsLookup.Path); } }

    public void AddPath(string newCurrentNodeId) {
        var index = GameComponentsLookup.Path;
        var component = (MergeToStay.Components.Path.PathComponent)CreateComponent(index, typeof(MergeToStay.Components.Path.PathComponent));
        component.CurrentNodeId = newCurrentNodeId;
        AddComponent(index, component);
    }

    public void ReplacePath(string newCurrentNodeId) {
        var index = GameComponentsLookup.Path;
        var component = (MergeToStay.Components.Path.PathComponent)CreateComponent(index, typeof(MergeToStay.Components.Path.PathComponent));
        component.CurrentNodeId = newCurrentNodeId;
        ReplaceComponent(index, component);
    }

    public void RemovePath() {
        RemoveComponent(GameComponentsLookup.Path);
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

    static Entitas.IMatcher<GameEntity> _matcherPath;

    public static Entitas.IMatcher<GameEntity> Path {
        get {
            if (_matcherPath == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.Path);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherPath = matcher;
            }

            return _matcherPath;
        }
    }
}
