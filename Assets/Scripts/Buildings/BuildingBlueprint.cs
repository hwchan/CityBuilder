using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;

//TODO replace dictionary key of BuildingEnum, use this
public abstract class BuildingBlueprint
{
    public static Dictionary<string, BuildingBlueprint> Blueprints { get;}
    public static string[] Keys { get;}

    static BuildingBlueprint()
    {
        Blueprints = new Dictionary<string, BuildingBlueprint>
        {
            { "house", new House() },
            { "bakery", new Bakery() },
            { "bank", new Bank() },
            { "barracks", new Barracks() },
            { "brewery", new Brewery() },
            { "castle", new Castle() },
            { "chapel", new Chapel() },
            { "clay_pit", new ClayPit() },
            { "coal_mine", new CoalMine() },
            { "construction_guild", new ConstructionGuild() },
            { "courthouse", new Courthouse() },
            { "fishing_wharf", new FishingWharf() },
            { "flax_farm", new FlaxFarm() },
            { "gold_mine", new GoldMine() },
            { "granary", new Granary() },
            { "hunting_lodge", new HuntingLodge() },
            { "iron_mine", new IronMine() },
            { "leatherwork", new Leatherwork() },
            { "library", new Library() },
            { "lighthouse", new Lighthouse() },
            { "lumbermill", new Lumbermill() },
            { "market", new Market() },
            { "physician", new Physician() },
            { "pig_farm", new PigFarm() },
            { "potter", new Potter() },
            { "prison", new Prison() },
            { "quarry", new Quarry() },
            { "shipyard", new Shipyard() },
            { "smithy", new Smithy() },
            { "stables", new Stables() },
            { "steel_forge", new SteelForge() },
            { "storehouse", new Storehouse() },
            { "tavern", new Tavern() },
            { "theatre", new Theatre() },
            { "trade_depot", new TradeDepot() },
            { "university", new University() },
            { "watermill", new Watermill() },
            { "waver", new Weaver() },
            { "wheat_farm", new WheatFarm() },
            { "woodcutter", new Woodcutter() },
            { "workshop", new Workshop() }
        };
        Keys = Blueprints.Keys.ToArray();
    }

    public Vector2 SpriteSize { get; set; }
    public string BuildingName { get; set; }
    public int Tier { get; set; }
    public int CoinCost { get; set; }
    public int CoinUpkeep { get; set; }
    public int Culture { get; protected set; }
    public int ProductionCost { get; set; }
    public GoodsCollection BuildingCost { get; set; }
    public GoodsCollection MaterialsRequired { get; set; }
    public GoodsCollection MaterialsProduced { get; set; }

    public List<Action<GoodsCollection>> BuildingEffects { get; set; }

    private Sprite _sprite;
    public Sprite Sprite
    {
        get
        {
            if (_sprite == null)
            {
                _sprite = Resources.Load<Sprite>(BuildingName);
            }
            return _sprite;
        }
    }

    public BuildingButton BuildingButton { get; set; }

    public BuildingBlueprint()
    {
        BuildingEffects = new List<Action<GoodsCollection>>();
        //Sprite = Resources.Load<Sprite>(BuildingName);
    }

    public virtual string GetMaterialsProducedString()
    {
        return MaterialsProduced.ToString();
    }


    //public string BuildingName { get; private set; }
    //public Sprite Sprite { get; private set; }
    //public Vector2 SpriteSize { get; private set; }

    //public BuildingBlueprint(string name, Vector2 size)
    //{
    //    BuildingName = name;
    //    SpriteSize = size;
    //    Sprite = Resources.Load<Sprite>(BuildingName);
    //}

    //public static readonly BuildingBlueprint BAKERY =               new BuildingBlueprint("bakery",             new Vector2(1, 1));
    //public static readonly BuildingBlueprint BANK =                 new BuildingBlueprint("bank",               new Vector2(1, 1));
    //public static readonly BuildingBlueprint BARRACKS =             new BuildingBlueprint("barracks",           new Vector2(1, 1));
    //public static readonly BuildingBlueprint BREWERY =              new BuildingBlueprint("brewery",            new Vector2(1, 1));
    //public static readonly BuildingBlueprint CASTLE =               new BuildingBlueprint("castle",             new Vector2(1, 1));
    //public static readonly BuildingBlueprint CHAPEL =               new BuildingBlueprint("chapel",             new Vector2(1, 1));
    //public static readonly BuildingBlueprint CLAY_PIT =             new BuildingBlueprint("clay_pit",           new Vector2(1, 1));
    //public static readonly BuildingBlueprint COAL_MINE =            new BuildingBlueprint("coal_mine",          new Vector2(1, 1));
    //public static readonly BuildingBlueprint CONSTRUCTION_GUILD =   new BuildingBlueprint("construction_guild", new Vector2(1, 1));
    //public static readonly BuildingBlueprint COURTHOUSE =           new BuildingBlueprint("courthouse",         new Vector2(1, 1));
    //public static readonly BuildingBlueprint FISHING_WHARF =        new BuildingBlueprint("fishing_wharf",      new Vector2(1, 1));
    //public static readonly BuildingBlueprint FLAX_FARM =            new BuildingBlueprint("flax_farm",          new Vector2(1, 1));
    //public static readonly BuildingBlueprint GOLD_MINE =            new BuildingBlueprint("gold_mine",          new Vector2(1, 1));
    //public static readonly BuildingBlueprint GRANARY =              new BuildingBlueprint("granary",            new Vector2(1, 1));
    //public static readonly BuildingBlueprint HUNTING_LODGE =        new BuildingBlueprint("hunting_lodge",      new Vector2(1, 1));
    //public static readonly BuildingBlueprint IRON_MINE =            new BuildingBlueprint("iron_mine",          new Vector2(1, 1));
    //public static readonly BuildingBlueprint LEATHERWORK =          new BuildingBlueprint("leatherwork",        new Vector2(1, 1));
    //public static readonly BuildingBlueprint LIBRARY =              new BuildingBlueprint("library", new Vector2(1, 1));
    //public static readonly BuildingBlueprint LIGHTHOUSE =           new BuildingBlueprint("lighthouse", new Vector2(1, 1));
    //public static readonly BuildingBlueprint LUMBERMILL =           new BuildingBlueprint("lumbermill", new Vector2(1, 1));
    //public static readonly BuildingBlueprint MARKET =               new BuildingBlueprint("market", new Vector2(1, 1));
    //public static readonly BuildingBlueprint PHYSICIAN =            new BuildingBlueprint("physician", new Vector2(1, 1));
    //public static readonly BuildingBlueprint PIG_FARM =             new BuildingBlueprint("pig_farm", new Vector2(1, 1));
    //public static readonly BuildingBlueprint POTTER =               new BuildingBlueprint("potter", new Vector2(1, 1));
    //public static readonly BuildingBlueprint PRISON =               new BuildingBlueprint("prison", new Vector2(1, 1));
    //public static readonly BuildingBlueprint QUARRY =               new BuildingBlueprint("quarry", new Vector2(1, 1));
    //public static readonly BuildingBlueprint SHIPYARD =             new BuildingBlueprint("shipyard", new Vector2(1, 1));
    //public static readonly BuildingBlueprint SMITHY =               new BuildingBlueprint("smithy", new Vector2(1, 1));
    //public static readonly BuildingBlueprint STABLES =              new BuildingBlueprint("stables", new Vector2(1, 1));
    //public static readonly BuildingBlueprint STEEL_FORGE =          new BuildingBlueprint("steel_forge", new Vector2(1, 1));
    //public static readonly BuildingBlueprint STOREHOUSE =           new BuildingBlueprint("storehouse", new Vector2(1, 1));
    //public static readonly BuildingBlueprint TAVERN =               new BuildingBlueprint("tavern", new Vector2(1, 1));
    //public static readonly BuildingBlueprint THEATRE =              new BuildingBlueprint("theatre", new Vector2(1, 1));
    //public static readonly BuildingBlueprint TRADE_DEPOT =          new BuildingBlueprint("trade_depot", new Vector2(1, 1));
    //public static readonly BuildingBlueprint UNIVERSITY =           new BuildingBlueprint("university", new Vector2(1, 1));
    //public static readonly BuildingBlueprint WATERMILL =            new BuildingBlueprint("watermill", new Vector2(1, 1));
    //public static readonly BuildingBlueprint WEAVER =               new BuildingBlueprint("weaver", new Vector2(1, 1));
    //public static readonly BuildingBlueprint WHEAT_FARM =           new BuildingBlueprint("wheat_farm", new Vector2(1, 1));
    //public static readonly BuildingBlueprint WOODCUTTER =           new BuildingBlueprint("woodcutter", new Vector2(1, 1));
    //public static readonly BuildingBlueprint WORKSHOP =             new BuildingBlueprint("workshop", new Vector2(1, 1));
}
