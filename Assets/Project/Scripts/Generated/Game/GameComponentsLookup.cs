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
    public const int SummonEnemyEvent = 2;
    public const int Board = 3;
    public const int Combat = 4;
    public const int DragGridObjectEvent = 5;
    public const int DragGridObjectUpdate = 6;
    public const int DrawCardEvent = 7;
    public const int GridObject = 8;
    public const int GridObjectUseEvent = 9;
    public const int MergeEvent = 10;
    public const int RestartGameEvent = 11;
    public const int NodeEnterEvent = 12;
    public const int NodeExitEvent = 13;
    public const int Path = 14;
    public const int ShowViewEvent = 15;
    public const int Player = 16;
    public const int DebugMessage = 17;

    public const int TotalComponents = 18;

    public static readonly string[] componentNames = {
        "Battle",
        "Enemy",
        "SummonEnemyEvent",
        "Board",
        "Combat",
        "DragGridObjectEvent",
        "DragGridObjectUpdate",
        "DrawCardEvent",
        "GridObject",
        "GridObjectUseEvent",
        "MergeEvent",
        "RestartGameEvent",
        "NodeEnterEvent",
        "NodeExitEvent",
        "Path",
        "ShowViewEvent",
        "Player",
        "DebugMessage"
    };

    public static readonly System.Type[] componentTypes = {
        typeof(MergeToStay.Components.Combat.Battle.Battle),
        typeof(MergeToStay.Components.Combat.Battle.Enemy),
        typeof(MergeToStay.Components.Combat.Battle.SummonEnemyEvent),
        typeof(MergeToStay.Components.Combat.BoardComponent),
        typeof(MergeToStay.Components.Combat.CombatComponent),
        typeof(MergeToStay.Components.Combat.DragGridObjectEvent),
        typeof(MergeToStay.Components.Combat.DragGridObjectUpdateComponent),
        typeof(MergeToStay.Components.Combat.DrawCardEvent),
        typeof(MergeToStay.Components.Combat.GridObject),
        typeof(MergeToStay.Components.Combat.GridObjectUseEvent),
        typeof(MergeToStay.Components.Combat.MergeEvent),
        typeof(MergeToStay.Components.Game.RestartGameEvent),
        typeof(MergeToStay.Components.Path.NodeEnterEvent),
        typeof(MergeToStay.Components.Path.NodeExitEvent),
        typeof(MergeToStay.Components.Path.PathComponent),
        typeof(MergeToStay.Components.Path.ShowViewEvent),
        typeof(MergeToStay.Components.Player.PlayerComponent),
        typeof(MergeToStay.Examples.Components.DebugMessageComponent)
    };
}
