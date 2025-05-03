using System.Collections.Generic;
using System;
using System.Text;
using System.Linq;

public class BuildingsCollection2
{
    private Dictionary<string, BuildingBlueprint> _blueprints;
    private Dictionary<string, List<Building>> _dictionary;

    public BuildingsCollection2()
    {
        _blueprints = new Dictionary<string, BuildingBlueprint>
        {
            { "bakery",             new Bakery() },
            { "bank",               new Bank() },
            { "barracks",           new Barracks() },
            { "brewery",            new Brewery() },
            { "castle",             new Castle() },
            { "chapel",             new Chapel() },
            { "clay_pit",           new ClayPit() },
            { "coal_mine",          new CoalMine() },
            { "construction_guild", new ConstructionGuild() },
            { "courthouse",         new Courthouse() },
            { "fishing_wharf",      new FishingWharf() },
            { "flax_farm",          new FlaxFarm() },
            { "gold_mine",          new GoldMine() },
            { "granary",            new Granary() },
            { "hunting_lodge",      new HuntingLodge() },
            { "iron_mine",          new IronMine() },
            { "leatherwork",        new Leatherwork() },
            { "library",            new Library() },
            { "lighthouse",         new Lighthouse() },
            { "lumbermill",         new Lumbermill() },
            { "market",             new Market() },
            { "physician",          new Physician() },
            { "pig_farm",           new PigFarm() },
            { "potter",             new Potter() },
            { "prison",             new Prison() },
            { "quarry",             new Quarry() },
            { "shipyard",           new Shipyard() },
            { "smithy",             new Smithy() },
            { "stables",            new Stables() },
            { "steel_forge",        new SteelForge() },
            { "storehouse",         new Storehouse() },
            { "tavern",             new Tavern() },
            { "theatre",            new Theatre() },
            { "trade_depot",        new TradeDepot() },
            { "university",         new University() },
            { "watermill",          new Watermill() },
            { "weaver",             new Weaver() },
            { "wheat_farm",         new WheatFarm() },
            { "woodcutter",         new Woodcutter() },
            { "workshop",           new Workshop() },
        };

        _dictionary = new Dictionary<string, List<Building>>
        {
            { "bakery",             new List<Building>() },
            { "bank",               new List<Building>() },
            { "barracks",           new List<Building>() },
            { "brewery",            new List<Building>() },
            { "castle",             new List<Building>() },
            { "chapel",             new List<Building>() },
            { "clay_pit",           new List<Building>() },
            { "coal_mine",          new List<Building>() },
            { "construction_guild", new List<Building>() },
            { "courthouse",         new List<Building>() },
            { "fishing_wharf",      new List<Building>() },
            { "flax_farm",          new List<Building>() },
            { "gold_mine",          new List<Building>() },
            { "granary",            new List<Building>() },
            { "hunting_lodge",      new List<Building>() },
            { "iron_mine",          new List<Building>() },
            { "leatherwork",        new List<Building>() },
            { "library",            new List<Building>() },
            { "lighthouse",         new List<Building>() },
            { "lumbermill",         new List<Building>() },
            { "market",             new List<Building>() },
            { "physician",          new List<Building>() },
            { "pig_farm",           new List<Building>() },
            { "potter",             new List<Building>() },
            { "prison",             new List<Building>() },
            { "quarry",             new List<Building>() },
            { "shipyard",           new List<Building>() },
            { "smithy",             new List<Building>() },
            { "stables",            new List<Building>() },
            { "steel_forge",        new List<Building>() },
            { "storehouse",         new List<Building>() },
            { "tavern",             new List<Building>() },
            { "theatre",            new List<Building>() },
            { "trade_depot",        new List<Building>() },
            { "university",         new List<Building>() },
            { "watermill",          new List<Building>() },
            { "weaver",             new List<Building>() },
            { "wheat_farm",         new List<Building>() },
            { "woodcutter",         new List<Building>() },
            { "workshop",           new List<Building>() },
        };

        //foreach (var bEnum in (BuildingEnum[])Enum.GetValues(typeof(BuildingEnum)))
        //{
        //    _dictionary.Add(bEnum, new List<Building>());
        //}
    }

    public void Add(Building b)
    {
        _dictionary[b.Blueprint.BuildingName].Add(b);
    }

    public void Remove(Building b)
    {
        _dictionary[b.Blueprint.BuildingName].Remove(b);
    }

    public string[] Keys => _dictionary.Keys.ToArray();
    //public BuildingBlueprint[] Blueprints => _dictionary.Keys.ToArray();

    public List<Building> this[string b] => _dictionary[b];

    public BuildingBlueprint GetBlueprint(string b)
    {
        return _blueprints[b];
    }

    public GoodsCollection HandleBuildingsOnEndTurn(GoodsCollection inventory)
    {
        int incomeGold = 0;
        int culture = 0;
        var prevGoods = new GoodsCollection(inventory);

        foreach (var kvp in _dictionary)
        {
            for (int i = 0; i < kvp.Value.Count; i++)
            {
                Building b = kvp.Value[i];
                b.HandleGoods(inventory);
                incomeGold -= b.GetUpkeep(inventory);
                culture += b.Culture;

                CheckBuildingConstruction(b);

                //if (i == kvp.Value.Count - 1)
                //    b.BuildingButton.UpdateBuildingButton();
            }
        }

        Globals.CityManager.AddCoin(incomeGold);
        Globals.CityManager.SetIncome(incomeGold);
        Globals.CityManager.SetCulture(culture);

        //calculate the difference in resources
        var incomeInventory = new GoodsCollection(inventory);
        incomeInventory.Subtract(prevGoods);
        //GuiManager.UpdateGui(Inventory);  //NO NEED WITH OnCollectionChange HOHOHO 
        return incomeInventory;
    }

    private void CheckBuildingConstruction(Building b)
    {
        if (b.CurrentProduction > 0 && (b.CurrentProduction -= Globals.CityManager.Production) <= 0)
        {
            //TransitionAnimation.CreateImage(b.Sprite, b.gObject.transform.position, b.gObject.transform.localScale, b.gObject.transform.localScale*2, .75f);
            //b.gObject.GetComponent<SpriteRenderer>().color = Color.white;
            //Destroy(b.gObject.transform.Find("TIME(Clone)").gameObject);

            //if (b == null)
            //    b = CurrentBuilding;

            b.AddLevel(1);
            //b.BuildingButton.OnClick();
            Globals.CityManager.AddCoin(-b.Blueprint.CoinCost);
            Globals.CityManager.SetIncome(Globals.CityManager.Income - b.Blueprint.CoinUpkeep);
        }

        b.GridCell.SetTimerText(b.CurrentProduction);
    }
}

//public class BuildingsCollection : Dictionary<BuildingEnum, Building>
//{
//    public BuildingsCollection()
//    {
//        Add(BuildingEnum.BAKERY, new Bakery());
//        Add(BuildingEnum.BANK, new Bank());
//        Add(BuildingEnum.BARRACKS, new Barracks());
//        Add(BuildingEnum.BREWERY, new Brewery());
//        Add(BuildingEnum.CASTLE, new Castle());
//        Add(BuildingEnum.CHAPEL, new Chapel());
//        Add(BuildingEnum.CLAY_PIT, new ClayPit());
//        Add(BuildingEnum.COAL_MINE, new CoalMine());
//        Add(BuildingEnum.CONSTRUCTION_GUILD, new ConstructionGuild());
//        Add(BuildingEnum.COURTHOUSE, new Courthouse());
//        Add(BuildingEnum.FISHING_WHARF, new FishingWharf());
//        Add(BuildingEnum.FLAX_FARM, new FlaxFarm());
//        Add(BuildingEnum.GOLD_MINE, new GoldMine());
//        Add(BuildingEnum.GRANARY, new Granary());
//        Add(BuildingEnum.HUNTING_LODGE, new HuntingLodge());
//        Add(BuildingEnum.IRON_MINE, new IronMine());
//        Add(BuildingEnum.LEATHERWORK, new Leatherwork());
//        Add(BuildingEnum.LIBRARY, new Library());
//        Add(BuildingEnum.LIGHTHOUSE, new Lighthouse());
//        Add(BuildingEnum.LUMBERMILL, new Lumbermill());
//        Add(BuildingEnum.MARKET, new Market());
//        Add(BuildingEnum.PHYSICIAN, new Physician());
//        Add(BuildingEnum.PIG_FARM, new PigFarm());
//        Add(BuildingEnum.POTTER, new Potter());
//        Add(BuildingEnum.PRISON, new Prison());
//        Add(BuildingEnum.QUARRY, new Quarry());
//        Add(BuildingEnum.SHIPYARD, new Shipyard());
//        Add(BuildingEnum.SMITHY, new Smithy());
//        Add(BuildingEnum.STABLES, new Stables());
//        Add(BuildingEnum.STEEL_FORGE, new SteelForge());
//        Add(BuildingEnum.STOREHOUSE, new Storehouse());
//        Add(BuildingEnum.TAVERN, new Tavern());
//        Add(BuildingEnum.THEATRE, new Theatre());
//        Add(BuildingEnum.TRADE_DEPOT, new TradeDepot());
//        Add(BuildingEnum.UNIVERSITY, new University());
//        Add(BuildingEnum.WATERMILL, new Watermill());
//        Add(BuildingEnum.WEAVER, new Weaver());
//        Add(BuildingEnum.WHEAT_FARM, new WheatFarm());
//        Add(BuildingEnum.WOODCUTTER, new Woodcutter());
//        Add(BuildingEnum.WORKSHOP, new Workshop());
//    }

//    public BuildingsCollection(BuildingsCollection buildings)
//    {
//        foreach (KeyValuePair<BuildingEnum, Building> kvp in buildings)
//        {
//            if (ContainsKey(kvp.Key))
//                this[kvp.Key].AddLevel(kvp.Value.Level);
//            else
//                Add(kvp.Key, kvp.Value);
//        }
//    }

//    public new Building this[BuildingEnum b]
//    {
//        get
//        {
//            if (ContainsKey(b))
//                return base[b];
//            return null;
//        }
//        //set
//        //{
//        //    if (ContainsKey(b))
//        //        base[b] = value;
//        //    else
//        //        Add(b, value);
//        //}
//    }

//    public static BuildingsCollection operator -(BuildingsCollection a, BuildingsCollection b)
//    {
//        if (b == null)
//            return a;

//        var ret = new BuildingsCollection(a);

//        foreach (var key in b.Keys)
//        {
//            ret[key].AddLevel(-b[key].Level);
//        }

//        return ret;
//    }

//    public static BuildingsCollection operator +(BuildingsCollection a, BuildingsCollection b)
//    {
//        if (b == null)
//            return a;

//        var ret = new BuildingsCollection(a);

//        foreach (var key in b.Keys)
//        {
//            ret[key].AddLevel(b[key].Level);
//        }

//        return ret;
//    }

//    public override string ToString()
//    {
//        StringBuilder build = new StringBuilder();
//        foreach (KeyValuePair<BuildingEnum, Building> kvp in this)
//            build.AppendLine(kvp.Key.ToString() + ":" + kvp.Value.Level);

//        return build.ToString();
//    }
//}
