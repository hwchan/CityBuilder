using System.Collections.Generic;
using System;
using System.Text;
using System.Linq;

public class BuildingsCollection
{
    private Dictionary<BuildingEnum, List<Building>> _dictionary;

    public BuildingsCollection()
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

                CheckBuildingConstruction(b);
                b.HandleGoods(inventory);
                incomeGold -= b.GetUpkeep(inventory);
                culture += b.Culture;
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
        if (b.ProductionLeft > 0 && (b.ProductionLeft -= Globals.CityManager.Production) <= 0)
        {
            b.AddLevel(1);
            Globals.CityManager.AddCoin(-b.CoinCost);
            Globals.CityManager.SetIncome(Globals.CityManager.Income - b.CoinUpkeep);
        }

        b.GridCell.SetTimerText(b.ProductionLeft);
    }
}

public static class BuildingBlueprints
{
    public static Dictionary<BuildingEnum, Building> Instance = new Dictionary<BuildingEnum, Building>
    {
        { BuildingEnum.HOUSE, new House() },
        { BuildingEnum.BAKERY, new Bakery() },
        { BuildingEnum.BANK, new Bank() },
        { BuildingEnum.BARRACKS, new Barracks() },
        { BuildingEnum.BREWERY, new Brewery() },
        { BuildingEnum.CASTLE, new Castle() },
        { BuildingEnum.CHAPEL, new Chapel() },
        { BuildingEnum.CLAY_PIT, new ClayPit() },
        { BuildingEnum.COAL_MINE, new CoalMine() },
        { BuildingEnum.CONSTRUCTION_GUILD, new ConstructionGuild() },
        { BuildingEnum.COURTHOUSE, new Courthouse() },
        { BuildingEnum.FISHING_WHARF, new FishingWharf() },
        { BuildingEnum.FLAX_FARM, new FlaxFarm() },
        { BuildingEnum.GOLD_MINE, new GoldMine() },
        { BuildingEnum.GRANARY, new Granary() },
        { BuildingEnum.HUNTING_LODGE, new HuntingLodge() },
        { BuildingEnum.IRON_MINE, new IronMine() },
        { BuildingEnum.LEATHERWORK, new Leatherwork() },
        { BuildingEnum.LIBRARY, new Library() },
        { BuildingEnum.LIGHTHOUSE, new Lighthouse() },
        { BuildingEnum.LUMBERMILL, new Lumbermill() },
        { BuildingEnum.MARKET, new Market() },
        { BuildingEnum.PHYSICIAN, new Physician() },
        { BuildingEnum.PIG_FARM, new PigFarm() },
        { BuildingEnum.POTTER, new Potter() },
        { BuildingEnum.PRISON, new Prison() },
        { BuildingEnum.QUARRY, new Quarry() },
        { BuildingEnum.SHIPYARD, new Shipyard() },
        { BuildingEnum.SMITHY, new Smithy() },
        { BuildingEnum.STABLES, new Stables() },
        { BuildingEnum.STEEL_FORGE, new SteelForge() },
        { BuildingEnum.STOREHOUSE, new Storehouse() },
        { BuildingEnum.TAVERN, new Tavern() },
        { BuildingEnum.THEATRE, new Theatre() },
        { BuildingEnum.TRADE_DEPOT, new TradeDepot() },
        { BuildingEnum.UNIVERSITY, new University() },
        { BuildingEnum.WATERMILL, new Watermill() },
        { BuildingEnum.WEAVER, new Weaver() },
        { BuildingEnum.WHEAT_FARM, new WheatFarm() },
        { BuildingEnum.WOODCUTTER, new Woodcutter() },
        { BuildingEnum.WORKSHOP, new Workshop() }
    };
}