//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentLookupGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public static class GameComponentsLookup {

   public const int Battle = 0;
    public const int Enemy = 1;
    public const int Board = 2;
    public const int Combat = 3;
    public const int DragGridObjectEvent = 4;
    public const int DragGridObjectUpdate = 5;
    public const int DrawCardEvent = 6;
    public const int GridObject = 7;
    public const int GridObjectUseEvent = 8;
    public const int MergeEvent = 9;
    public const int DebugMessage = 10;
    public const int NodeEnterEvent = 8;
    public const int Path = 9;
    public const int TotalComponents = 11;

    public static readonly string[] componentNames = {
        "Battle",
        "Enemy",
        "Board",
        "Combat",
        "DragGridObjectEvent",
        "DragGridObjectUpdate",
        "DrawCardEvent",
        "GridObject",
        "GridObjectUseEvent",
        "MergeEvent",
        "NodeEnterEvent",
        "Path",
        "DebugMessage"
    };

    public static readonly System.Type[] componentTypes = {
        typeof(MergeToStay.Components.Combat.Battle.Battle),
        typeof(MergeToStay.Components.Combat.Battle.Enemy),
        typeof(MergeToStay.Components.Combat.BoardComponent),
        typeof(MergeToStay.Components.Combat.CombatComponent),
        typeof(MergeToStay.Components.Combat.DragGridObjectEvent),
        typeof(MergeToStay.Components.Combat.DragGridObjectUpdateComponent),
        typeof(MergeToStay.Components.Combat.DrawCardEvent),
        typeof(MergeToStay.Components.Combat.GridObject),
        typeof(MergeToStay.Components.Combat.GridObjectUseEvent),
        typeof(MergeToStay.Components.Combat.MergeEvent),
        typeof(MergeToStay.Components.Combat.NodeEnterEvent),
        typeof(MergeToStay.Components.Path.PathComponent),
        typeof(MergeToStay.Examples.Components.DebugMessageComponent)
    };
}
