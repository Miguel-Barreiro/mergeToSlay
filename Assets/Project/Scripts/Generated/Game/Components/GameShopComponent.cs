//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public MergeToStay.Components.Shop.ShopComponent shop { get { return (MergeToStay.Components.Shop.ShopComponent)GetComponent(GameComponentsLookup.Shop); } }
    public bool hasShop { get { return HasComponent(GameComponentsLookup.Shop); } }

    public void AddShop(System.Collections.Generic.List<MergeToStay.Data.CardsModel.Card> newCards) {
        var index = GameComponentsLookup.Shop;
        var component = (MergeToStay.Components.Shop.ShopComponent)CreateComponent(index, typeof(MergeToStay.Components.Shop.ShopComponent));
        component.Cards = newCards;
        AddComponent(index, component);
    }

    public void ReplaceShop(System.Collections.Generic.List<MergeToStay.Data.CardsModel.Card> newCards) {
        var index = GameComponentsLookup.Shop;
        var component = (MergeToStay.Components.Shop.ShopComponent)CreateComponent(index, typeof(MergeToStay.Components.Shop.ShopComponent));
        component.Cards = newCards;
        ReplaceComponent(index, component);
    }

    public void RemoveShop() {
        RemoveComponent(GameComponentsLookup.Shop);
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

    static Entitas.IMatcher<GameEntity> _matcherShop;

    public static Entitas.IMatcher<GameEntity> Shop {
        get {
            if (_matcherShop == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.Shop);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherShop = matcher;
            }

            return _matcherShop;
        }
    }
}
