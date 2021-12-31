using System.Collections.Generic;
using System;
using System.Text;
using System.Linq;

public class BuildingsCollection2
{
    private Dictionary<BuildingEnum, List<Building>> _dictionary;

    public BuildingsCollection2()
    {
        _dictionary = new Dictionary<BuildingEnum, List<Building>>();

        foreach (var bEnum in (BuildingEnum[])Enum.GetValues(typeof(BuildingEnum)))
        {
            _dictionary.Add(bEnum, new List<Building>());
        }
    }

    public void Add(Building b)
    {
        _dictionary[b.BuildingType].Add(b);
    }

    public void Remove(Building b)
    {
        _dictionary[b.BuildingType].Remove(b);
    }

    public BuildingEnum[] Types => _dictionary.Keys.ToArray();

    public List<Building> this[BuildingEnum b] => _dictionary[b];

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
            }
        }

        Globals.CityManager.AddCoin(incomeGold);
        Globals.CityManager.SetIncome(incomeGold);
        Globals.CityManager.SetCulture(culture);

        //calculate the difference in resources
        var incomeInventory = new GoodsCollection(inventory);
        incomeInventory.Subtract(prevGoods);
        return incomeInventory;
    }

    private void CheckBuildingConstruction(Building b)
    {
        if (b.CurrentProduction > 0 && (b.CurrentProduction -= Globals.CityManager.Production) <= 0)
        {
            b.AddLevel(1);
            Globals.CityManager.AddCoin(-b.CoinCost);
            Globals.CityManager.SetIncome(Globals.CityManager.Income - b.CoinUpkeep);
        }

        b.GridCell.SetTimerText(b.CurrentProduction);
    }
}

public class BuildingsCollection : Dictionary<BuildingEnum, Building>
{
    public BuildingsCollection()
    {
        Add(BuildingEnum.BAKERY, new Bakery());
        Add(BuildingEnum.BANK, new Bank());
        Add(BuildingEnum.BARRACKS, new Barracks());
        Add(BuildingEnum.BREWERY, new Brewery());
        Add(BuildingEnum.CASTLE, new Castle());
        Add(BuildingEnum.CHAPEL, new Chapel());
        Add(BuildingEnum.CLAY_PIT, new ClayPit());
        Add(BuildingEnum.COAL_MINE, new CoalMine());
        Add(BuildingEnum.CONSTRUCTION_GUILD, new ConstructionGuild());
        Add(BuildingEnum.COURTHOUSE, new Courthouse());
        Add(BuildingEnum.FISHING_WHARF, new FishingWharf());
        Add(BuildingEnum.FLAX_FARM, new FlaxFarm());
        Add(BuildingEnum.GOLD_MINE, new GoldMine());
        Add(BuildingEnum.GRANARY, new Granary());
        Add(BuildingEnum.HUNTING_LODGE, new HuntingLodge());
        Add(BuildingEnum.IRON_MINE, new IronMine());
        Add(BuildingEnum.LEATHERWORK, new Leatherwork());
        Add(BuildingEnum.LIBRARY, new Library());
        Add(BuildingEnum.LIGHTHOUSE, new Lighthouse());
        Add(BuildingEnum.LUMBERMILL, new Lumbermill());
        Add(BuildingEnum.MARKET, new Market());
        Add(BuildingEnum.PHYSICIAN, new Physician());
        Add(BuildingEnum.PIG_FARM, new PigFarm());
        Add(BuildingEnum.POTTER, new Potter());
        Add(BuildingEnum.PRISON, new Prison());
        Add(BuildingEnum.QUARRY, new Quarry());
        Add(BuildingEnum.SHIPYARD, new Shipyard());
        Add(BuildingEnum.SMITHY, new Smithy());
        Add(BuildingEnum.STABLES, new Stables());
        Add(BuildingEnum.STEEL_FORGE, new SteelForge());
        Add(BuildingEnum.STOREHOUSE, new Storehouse());
        Add(BuildingEnum.TAVERN, new Tavern());
        Add(BuildingEnum.THEATRE, new Theatre());
        Add(BuildingEnum.TRADE_DEPOT, new TradeDepot());
        Add(BuildingEnum.UNIVERSITY, new University());
        Add(BuildingEnum.WATERMILL, new Watermill());
        Add(BuildingEnum.WEAVER, new Weaver());
        Add(BuildingEnum.WHEAT_FARM, new WheatFarm());
        Add(BuildingEnum.WOODCUTTER, new Woodcutter());
        Add(BuildingEnum.WORKSHOP, new Workshop());
    }

    public BuildingsCollection(BuildingsCollection buildings)
    {
        foreach (KeyValuePair<BuildingEnum, Building> kvp in buildings)
        {
            if (ContainsKey(kvp.Key))
                this[kvp.Key].AddLevel(kvp.Value.Level);
            else
                Add(kvp.Key, kvp.Value);
        }
    }

    public new Building this[BuildingEnum b]
    {
        get
        {
            if (ContainsKey(b))
                return base[b];
            return null;
        }
        //set
        //{
        //    if (ContainsKey(b))
        //        base[b] = value;
        //    else
        //        Add(b, value);
        //}
    }

    public static BuildingsCollection operator -(BuildingsCollection a, BuildingsCollection b)
    {
        if (b == null)
            return a;

        var ret = new BuildingsCollection(a);

        foreach (var key in b.Keys)
        {
            ret[key].AddLevel(-b[key].Level);
        }

        return ret;
    }

    public static BuildingsCollection operator +(BuildingsCollection a, BuildingsCollection b)
    {
        if (b == null)
            return a;

        var ret = new BuildingsCollection(a);

        foreach (var key in b.Keys)
        {
            ret[key].AddLevel(b[key].Level);
        }

        return ret;
    }

    public override string ToString()
    {
        StringBuilder build = new StringBuilder();
        foreach (KeyValuePair<BuildingEnum, Building> kvp in this)
            build.AppendLine(kvp.Key.ToString() + ":" + kvp.Value.Level);

        return build.ToString();
    }
}
