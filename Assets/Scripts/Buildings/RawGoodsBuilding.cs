using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Bakery : Building
{
    public Bakery()
    {
        SpriteSize = new Vector2(2, 1);
        BuildingType = BuildingEnum.BAKERY;
        BuildingName = "bakery";
        Tier = 2;
        CoinCost = 10;
        CoinUpkeep = 1;
        ProductionCost = 3;
        BuildingCost = new GoodsCollection { { Good.WOOD, 3 }, { Good.STONE, 5 }, { Good.IRON, 2 }, { Good.TOOL, 3 } };
        MaterialsRequired = new GoodsCollection { { Good.GRAIN, 1 }, { Good.WOOD, 1 } };
        MaterialsProduced = new GoodsCollection { { Good.GRAIN, 3 } };
        BuildingEffect = null;
    }
}

public class Bank : Building
{
    public Bank()
    {
        SpriteSize = new Vector2(2, 1);
        BuildingType = BuildingEnum.BANK;
        BuildingName = "bank";
        Tier = 3;
        CoinCost = 10;
        CoinUpkeep = 1;
        ProductionCost = 3;
        BuildingCost = new GoodsCollection { { Good.WOOD, 5 }, { Good.STONE, 2 }, { Good.TOOL, 3 } };
        MaterialsRequired = new GoodsCollection { { Good.FLAX, 1 } };
        MaterialsProduced = new GoodsCollection();
        BuildingEffect = null;
    }
}

public class Barracks : Building
{
    public Barracks()
    {
        SpriteSize = new Vector2(2, 1);
        BuildingType = BuildingEnum.BARRACKS;
        BuildingName = "barracks";
        Tier = 3;
        CoinCost = 10;
        CoinUpkeep = 1;
        ProductionCost = 3;
        BuildingCost = new GoodsCollection { { Good.WOOD, 5 }, { Good.STONE, 2 }, { Good.TOOL, 3 } };
        MaterialsRequired = new GoodsCollection { { Good.FLAX, 1 } };
        MaterialsProduced = new GoodsCollection();
        BuildingEffect = null;
    }
}

public class Brewery : Building
{
    public Brewery()
    {
        SpriteSize = new Vector2(2, 1);
        BuildingType = BuildingEnum.BREWERY;
        BuildingName = "brewery";
        Tier = 2;
        CoinCost = 10;
        CoinUpkeep = 1;
        ProductionCost = 3;
        BuildingCost = new GoodsCollection { { Good.WOOD, 3 }, { Good.STONE, 5 }, { Good.IRON, 2 }, { Good.TOOL, 3 } };
        MaterialsRequired = new GoodsCollection { { Good.GRAIN, 1 }, { Good.HERB, 1 } };
        MaterialsProduced = new GoodsCollection { { Good.ALE, 1 } };
        BuildingEffect = null;
    }
}

public class Castle : Building
{
    public Castle()
    {
        SpriteSize = new Vector2(3, 2);
        BuildingType = BuildingEnum.CASTLE;
        BuildingName = "castle";
        Tier = 1;
        CoinCost = 10;
        CoinUpkeep = 1;
        ProductionCost = 3;
        BuildingCost = new GoodsCollection { { Good.WOOD, 50 }, { Good.STONE, 50 }, { Good.TOOL, 50 } };
        MaterialsRequired = new GoodsCollection();
        MaterialsProduced = new GoodsCollection { { Good.WOOD, 1 }, { Good.STONE, 1 }, { Good.IRON, 1 }, { Good.TOOL, 1 }, { Good.GRAIN, 1 }, { Good.MEAT, 1 }, { Good.CLAY, 1 }, { Good.COAL, 1 }, { Good.FLAX, 1 }, { Good.HERB, 1 }, { Good.GOLD, 1 }, { Good.CERAMIC, 1 }, { Good.CLOTH, 1 }, { Good.ALE, 1 }, { Good.PAPER, 1 }, { Good.WEAPON, 1 }, { Good.ARTISAN, 1 }, };
        BuildingEffect = null;
    }
}

public class Chapel : Building
{
    public Chapel()
    {
        SpriteSize = new Vector2(2, 1);
        BuildingType = BuildingEnum.CHAPEL;
        BuildingName = "chapel";
        Tier = 1;
        CoinCost = 10;
        CoinUpkeep = 1;
        ProductionCost = 3;
        BuildingCost = new GoodsCollection { { Good.WOOD, 5 }, { Good.STONE, 2 }, { Good.TOOL, 3 } };
        MaterialsRequired = new GoodsCollection();
        MaterialsProduced = new GoodsCollection();
        BuildingEffect = null;
    }
}

public class ClayPit : Building
{
    public ClayPit()
    {
        SpriteSize = new Vector2(2, 1);
        BuildingType = BuildingEnum.CLAY_PIT;
        BuildingName = "claypit";
        Tier = 1;
        CoinCost = 15;
        CoinUpkeep = 2;
        ProductionCost = 3;
        BuildingCost = new GoodsCollection { { Good.WOOD, 1 }, { Good.STONE, 1 }, { Good.TOOL, 1 } };
        MaterialsRequired = new GoodsCollection();
        MaterialsProduced = new GoodsCollection { { Good.CLAY, 1 } };
        BuildingEffect = null;
    }
}

public class CoalMine : Building
{
    public CoalMine()
    {
        SpriteSize = new Vector2(2, 1);
        BuildingType = BuildingEnum.COAL_MINE;
        BuildingName = "coal_mine";
        Tier = 2;
        CoinCost = 15;
        CoinUpkeep = 2;
        Culture = 3;
        ProductionCost = 3;
        BuildingCost = new GoodsCollection { { Good.WOOD, 1 }, { Good.STONE, 1 }, { Good.TOOL, 2 } };
        MaterialsRequired = new GoodsCollection();
        MaterialsProduced = new GoodsCollection { { Good.COAL, 1 } };
        BuildingEffect = null;
    }
}

public class ConstructionGuild : Building
{
    private string _materialsProducedString;

    public ConstructionGuild()
    {
        SpriteSize = new Vector2(2, 1);
        BuildingType = BuildingEnum.CONSTRUCTION_GUILD;
        BuildingName = "construction_guild";
        Tier = 2;
        CoinCost = 15;
        CoinUpkeep = 2;
        ProductionCost = 3;
        BuildingCost = new GoodsCollection { { Good.WOOD, 1 }, { Good.STONE, 1 }, { Good.TOOL, 2 } };
        MaterialsRequired = new GoodsCollection();
        MaterialsProduced = new GoodsCollection { { Good.COAL, 1 } };
        BuildingEffect = Carpenters;

        BuildingEffects.Add(Carpenters);
        BuildingEffects.Add(Guilds);
        BuildingEffects.Add(Architects);
    }

    private void Carpenters(GoodsCollection goods)
    {
        MaterialsRequired = new GoodsCollection { { Good.WOOD, 3 }, { Good.TOOL, 1 } };
        CoinUpkeep = 10;
        _materialsProducedString = "production+";
        Globals.CityManager.SetProduction(2);
    }

    private void Guilds(GoodsCollection goods)
    {
        MaterialsRequired = new GoodsCollection { { Good.WOOD, 3 }, { Good.STONE, 3 }, { Good.TOOL, 3 } };
        CoinUpkeep = 15;
        _materialsProducedString = "construction cost-";
    }

    private void Architects(GoodsCollection goods)
    {
        MaterialsRequired = new GoodsCollection { { Good.TOOL, 3 }, { Good.PAPER, 5 } };
        CoinUpkeep = 20;
        _materialsProducedString = "upkeep+, culture+";
    }

    public override string GetMaterialsProducedString()
    {
        return _materialsProducedString;
    }
}

public class Courthouse : Building
{
    private string _materialsProducedString;

    public Courthouse()
    {
        SpriteSize = new Vector2(2, 1);
        BuildingType = BuildingEnum.COURTHOUSE;
        BuildingName = "courthouse";
        Tier = 3;
        CoinCost = 10;
        CoinUpkeep = 1;
        ProductionCost = 3;
        BuildingCost = new GoodsCollection { { Good.WOOD, 6 }, { Good.STONE, 8 }, { Good.IRON, 3 }, { Good.TOOL, 6 } };
        MaterialsRequired = new GoodsCollection { { Good.PAPER, 1 } };
        MaterialsProduced = new GoodsCollection();
        BuildingEffect = HousingPolicy;

        BuildingEffects.Add(HousingPolicy);
        BuildingEffects.Add(ConscriptionPolicy);
        BuildingEffects.Add(TaxPolicy);
    }

    private void HousingPolicy(GoodsCollection goods)
    {
        MaterialsRequired = new GoodsCollection { { Good.PAPER, 1 } };
        CoinUpkeep = 10;
        _materialsProducedString = "growth+";
    }

    private void ConscriptionPolicy(GoodsCollection goods)
    {
        MaterialsRequired = new GoodsCollection { { Good.PAPER, 3 } };
        CoinUpkeep = 15;
        _materialsProducedString = "military upkeep-";
    }

    private void TaxPolicy(GoodsCollection goods)
    {
        MaterialsRequired = new GoodsCollection { { Good.PAPER, 2 } };
        CoinUpkeep = 20;
        _materialsProducedString = "tax+";
    }

    public override string GetMaterialsProducedString()
    {
        return _materialsProducedString;
    }
}

public class FishingWharf : Building
{
    public FishingWharf()
    {
        SpriteSize = new Vector2(1, 1);
        BuildingType = BuildingEnum.FISHING_WHARF;
        BuildingName = "fishing_wharf";
        Tier = 1;
        CoinCost = 15;
        CoinUpkeep = 2;
        ProductionCost = 3;
        BuildingCost = new GoodsCollection { { Good.WOOD, 2 }, { Good.TOOL, 1 } };
        MaterialsRequired = new GoodsCollection();
        MaterialsProduced = new GoodsCollection { { Good.MEAT, 1 } };
        BuildingEffect = null;
    }
}

public class FlaxFarm : Building
{
    public FlaxFarm()
    {
        SpriteSize = new Vector2(4, 2);
        BuildingType = BuildingEnum.FLAX_FARM;
        BuildingName = "flax_farm";
        Tier = 1;
        CoinCost = 15;
        CoinUpkeep = 2;
        ProductionCost = 3;
        BuildingCost = new GoodsCollection { { Good.WOOD, 2 }, { Good.TOOL, 1 } };
        MaterialsRequired = new GoodsCollection();
        MaterialsProduced = new GoodsCollection { { Good.FLAX, 1 } };
        BuildingEffect = null;
    }
}

public class GoldMine : Building
{
    public GoldMine()
    {
        SpriteSize = new Vector2(2, 1);
        BuildingType = BuildingEnum.GOLD_MINE;
        BuildingName = "gold_mine";
        Tier = 2;
        CoinCost = 15;
        CoinUpkeep = 2;
        ProductionCost = 3;
        BuildingCost = new GoodsCollection { { Good.WOOD, 1 }, { Good.STONE, 3 }, { Good.IRON, 1 }, { Good.TOOL, 2 } };
        MaterialsRequired = new GoodsCollection();
        MaterialsProduced = new GoodsCollection { { Good.GOLD, 1 } };
        BuildingEffect = null;
    }
}

public class Granary : Building
{
    public Granary()
    {
        SpriteSize = new Vector2(2, 1);
        BuildingType = BuildingEnum.GRANARY;
        BuildingName = "granary";
        Tier = 2;
        CoinCost = 15;
        CoinUpkeep = 2;
        ProductionCost = 3;
        BuildingCost = new GoodsCollection { { Good.WOOD, 1 }, { Good.STONE, 3 }, { Good.IRON, 1 }, { Good.TOOL, 2 } };
        MaterialsRequired = new GoodsCollection();
        MaterialsProduced = new GoodsCollection { { Good.GOLD, 1 } };
        BuildingEffect = null;
    }
}

public class HuntingLodge : Building
{
    public HuntingLodge()
    {
        SpriteSize = new Vector2(2, 1);
        BuildingType = BuildingEnum.HUNTING_LODGE;
        BuildingName = "hunting_lodge";
        Tier = 1;
        CoinCost = 15;
        CoinUpkeep = 2;
        ProductionCost = 3;
        BuildingCost = new GoodsCollection { { Good.WOOD, 1 }, { Good.STONE, 3 }, { Good.IRON, 1 }, { Good.TOOL, 2 } };
        MaterialsRequired = new GoodsCollection();
        MaterialsProduced = new GoodsCollection();
        BuildingEffect = null;
    }
}

public class IronMine : Building
{
    public IronMine()
    {
        SpriteSize = new Vector2(2, 1);
        BuildingType = BuildingEnum.IRON_MINE;
        BuildingName = "iron_mine";
        Tier = 1;
        CoinCost = 15;
        CoinUpkeep = 2;
        ProductionCost = 3;
        BuildingCost = new GoodsCollection { { Good.WOOD, 1 }, { Good.STONE, 1 }, { Good.TOOL, 2 } };
        MaterialsRequired = new GoodsCollection();
        MaterialsProduced = new GoodsCollection { { Good.IRON, 1 } };
        BuildingEffect = null;
    }
}

public class Leatherwork : Building
{
    public Leatherwork()
    {
        SpriteSize = new Vector2(2, 1);
        BuildingType = BuildingEnum.LEATHERWORK;
        BuildingName = "leatherwork";
        Tier = 1;
        CoinCost = 15;
        CoinUpkeep = 2;
        ProductionCost = 3;
        BuildingCost = new GoodsCollection { { Good.WOOD, 1 }, { Good.STONE, 1 }, { Good.TOOL, 2 } };
        MaterialsRequired = new GoodsCollection();
        MaterialsProduced = new GoodsCollection { { Good.IRON, 1 } };
        BuildingEffect = null;
    }
}

public class Library : Building
{
    public Library()
    {
        SpriteSize = new Vector2(2, 1);
        BuildingType = BuildingEnum.LIBRARY;
        BuildingName = "library";
        Tier = 1;
        CoinCost = 10;
        CoinUpkeep = 1;
        ProductionCost = 3;
        BuildingCost = new GoodsCollection { { Good.WOOD, 6 }, { Good.STONE, 8 }, { Good.IRON, 3 }, { Good.TOOL, 6 } };
        MaterialsRequired = new GoodsCollection { { Good.PAPER, 1 } };
        MaterialsProduced = new GoodsCollection();
        BuildingEffect = Research;
    }

    private void Research(GoodsCollection goods)
    {
        MaterialsRequired = new GoodsCollection { { Good.PAPER, 1 } };
        CoinUpkeep = 10;
        //research+
    }
}

public class Lighthouse : Building
{
    public Lighthouse()
    {
        SpriteSize = new Vector2(1, 2);
        BuildingType = BuildingEnum.LIGHTHOUSE;
        BuildingName = "lighthouse";
        Tier = 1;
        CoinCost = 10;
        CoinUpkeep = 1;
        ProductionCost = 3;
        BuildingCost = new GoodsCollection { { Good.WOOD, 6 }, { Good.STONE, 8 }, { Good.IRON, 3 }, { Good.TOOL, 6 } };
        MaterialsRequired = new GoodsCollection { { Good.PAPER, 1 } };
        MaterialsProduced = new GoodsCollection();
        BuildingEffect = null;
    }
}

public class Lumbermill : Building
{
    public Lumbermill()
    {
        SpriteSize = new Vector2(2, 1);
        BuildingType = BuildingEnum.LUMBERMILL;
        BuildingName = "lumbermill";
        Tier = 1;
        CoinCost = 10;
        CoinUpkeep = 1;
        ProductionCost = 3;
        BuildingCost = new GoodsCollection { { Good.WOOD, 5 }, { Good.STONE, 2 }, { Good.TOOL, 3 } };
        MaterialsRequired = new GoodsCollection { { Good.FLAX, 1 } };
        MaterialsProduced = new GoodsCollection { { Good.CLOTH, 1 } };
        BuildingEffect = null;
    }
}

public class Market : Building
{
    public Market()
    {
        SpriteSize = new Vector2(2, 1);
        BuildingType = BuildingEnum.MARKET;
        BuildingName = "market";
        Tier = 1;
        CoinCost = 10;
        CoinUpkeep = 1;
        ProductionCost = 3;
        BuildingCost = new GoodsCollection { { Good.WOOD, 5 }, { Good.STONE, 2 }, { Good.TOOL, 3 } };
        MaterialsRequired = new GoodsCollection { { Good.FLAX, 1 } };
        MaterialsProduced = new GoodsCollection { { Good.CLOTH, 1 } };
        BuildingEffect = null;
    }
}

public class Physician : Building
{
    public Physician()
    {
        SpriteSize = new Vector2(2, 1);
        BuildingType = BuildingEnum.PHYSICIAN;
        BuildingName = "physician";
        Tier = 1;
        CoinCost = 10;
        CoinUpkeep = 1;
        ProductionCost = 3;
        BuildingCost = new GoodsCollection { { Good.WOOD, 5 }, { Good.STONE, 2 }, { Good.TOOL, 3 } };
        MaterialsRequired = new GoodsCollection { { Good.FLAX, 1 } };
        MaterialsProduced = new GoodsCollection { { Good.CLOTH, 1 } };
        BuildingEffect = null;
    }
}

public class PigFarm : Building
{
    public PigFarm()
    {
        SpriteSize = new Vector2(2, 1);
        BuildingType = BuildingEnum.PIG_FARM;
        BuildingName = "pig_farm";
        Tier = 1;
        CoinCost = 15;
        CoinUpkeep = 2;
        ProductionCost = 3;
        BuildingCost = new GoodsCollection { { Good.WOOD, 3 }, { Good.STONE, 1 }, { Good.TOOL, 2 } };
        MaterialsRequired = new GoodsCollection();
        MaterialsProduced = new GoodsCollection { { Good.MEAT, 1 } };
        BuildingEffect = null;
    }
}

public class Potter : Building
{
    public Potter()
    {
        SpriteSize = new Vector2(2, 1);
        BuildingType = BuildingEnum.POTTER;
        BuildingName = "potter";
        Tier = 1;
        CoinCost = 10;
        CoinUpkeep = 1;
        ProductionCost = 3;
        BuildingCost = new GoodsCollection { { Good.WOOD, 3 }, { Good.STONE, 3 }, { Good.TOOL, 2 } };
        MaterialsRequired = new GoodsCollection { { Good.CLAY, 1 } };
        MaterialsProduced = new GoodsCollection { { Good.CERAMIC, 1 } };
        BuildingEffect = null;
    }
}

public class Prison : Building
{
    public Prison()
    {
        SpriteSize = new Vector2(2, 1);
        BuildingType = BuildingEnum.PRISON;
        BuildingName = "prison";
        Tier = 1;
        CoinCost = 10;
        CoinUpkeep = 1;
        ProductionCost = 3;
        BuildingCost = new GoodsCollection { { Good.WOOD, 3 }, { Good.STONE, 3 }, { Good.TOOL, 2 } };
        MaterialsRequired = new GoodsCollection { { Good.CLAY, 1 } };
        MaterialsProduced = new GoodsCollection { { Good.CERAMIC, 1 } };
        BuildingEffect = null;
    }
}

public class Quarry : Building
{
    public Quarry()
    {
        SpriteSize = new Vector2(2, 1);
        BuildingType = BuildingEnum.QUARRY;
        BuildingName = "quarry";
        Tier = 1;
        CoinCost = 15;
        CoinUpkeep = 2;
        ProductionCost = 3;
        BuildingCost = new GoodsCollection { { Good.WOOD, 1 }, { Good.TOOL, 3 } };
        MaterialsRequired = new GoodsCollection();
        MaterialsProduced = new GoodsCollection { { Good.STONE, 1 } };
        BuildingEffect = null;
    }
}

public class Shipyard : Building
{
    public Shipyard()
    {
        SpriteSize = new Vector2(2, 1);
        BuildingType = BuildingEnum.SHIPYARD;
        BuildingName = "shipyard";
        Tier = 1;
        CoinCost = 15;
        CoinUpkeep = 2;
        ProductionCost = 3;
        BuildingCost = new GoodsCollection { { Good.WOOD, 1 }, { Good.TOOL, 3 } };
        MaterialsRequired = new GoodsCollection();
        MaterialsProduced = new GoodsCollection { { Good.STONE, 1 } };
        BuildingEffect = null;
    }
}

public class Smithy : Building
{
    public Smithy()
    {
        SpriteSize = new Vector2(1, 1);
        BuildingType = BuildingEnum.SMITHY;
        BuildingName = "smithy";
        Tier = 1;
        CoinCost = 10;
        CoinUpkeep = 1;
        ProductionCost = 3;
        BuildingCost = new GoodsCollection { { Good.WOOD, 2 }, { Good.STONE, 1 }, { Good.TOOL, 1 } };
        MaterialsRequired = new GoodsCollection { { Good.IRON, 1 } };
        MaterialsProduced = new GoodsCollection { { Good.TOOL, 1 } };
        BuildingEffect = null;
    }
}

public class Stables : Building
{
    public Stables()
    {
        SpriteSize = new Vector2(2, 1);
        BuildingType = BuildingEnum.STABLES;
        BuildingName = "stables";
        Tier = 1;
        CoinCost = 10;
        CoinUpkeep = 1;
        ProductionCost = 3;
        BuildingCost = new GoodsCollection { { Good.WOOD, 2 }, { Good.STONE, 1 }, { Good.TOOL, 1 } };
        MaterialsRequired = new GoodsCollection { { Good.IRON, 1 } };
        MaterialsProduced = new GoodsCollection { { Good.TOOL, 1 } };
        BuildingEffect = null;
    }
}

public class SteelForge : Building
{
    public SteelForge()
    {
        SpriteSize = new Vector2(2, 1);
        BuildingType = BuildingEnum.STEEL_FORGE;
        BuildingName = "steel_forge";
        Tier = 3;
        CoinCost = 10;
        CoinUpkeep = 1;
        ProductionCost = 3;
        BuildingCost = new GoodsCollection { { Good.WOOD, 6 }, { Good.STONE, 8 }, { Good.IRON, 3 }, { Good.TOOL, 6 } };
        MaterialsRequired = new GoodsCollection();
        MaterialsProduced = new GoodsCollection();
        BuildingEffect = ProduceSteel;

        BuildingEffects.Add(ProduceSteel);
        BuildingEffects.Add(ProduceTools);
        BuildingEffects.Add(ProduceWeapons);
        BuildingEffects.Add(ProduceBuildingMaterials);
    }

    private void ProduceSteel(GoodsCollection goods)
    {
        Debug.Log("steel");
        MaterialsRequired = new GoodsCollection { { Good.IRON, 7 }, { Good.COAL, 3 } };
        MaterialsProduced = new GoodsCollection { { Good.IRON, 12 } };
        CoinUpkeep = 10;
    }

    private void ProduceTools(GoodsCollection goods)
    {
        Debug.Log("tools");
        MaterialsRequired = new GoodsCollection { { Good.IRON, 6 }, { Good.COAL, 3 } };
        MaterialsProduced = new GoodsCollection { { Good.TOOL, 12 } };
        CoinUpkeep = 15;
    }

    private void ProduceWeapons(GoodsCollection goods)
    {
        Debug.Log("weapons");
        MaterialsRequired = new GoodsCollection { { Good.IRON, 10 }, { Good.COAL, 4 } };
        MaterialsProduced = new GoodsCollection { { Good.WEAPON, 10 } };
        CoinUpkeep = 20;
    }

    private void ProduceBuildingMaterials(GoodsCollection goods)
    {
        Debug.Log("materials");
        MaterialsRequired = new GoodsCollection { { Good.IRON, 10 }, { Good.COAL, 4 }, { Good.TOOL, 8 } };
        MaterialsProduced = new GoodsCollection();
        CoinUpkeep = 20;
        //production+
    }
}

public class Storehouse : Building
{
    public Storehouse()
    {
        SpriteSize = new Vector2(2, 1);
        BuildingType = BuildingEnum.STOREHOUSE;
        BuildingName = "storehouse";
        Tier = 1;
        CoinCost = 10;
        CoinUpkeep = 1;
        ProductionCost = 3;
        BuildingCost = new GoodsCollection { { Good.WOOD, 5 }, { Good.STONE, 2 }, { Good.TOOL, 3 } };
        MaterialsRequired = new GoodsCollection { { Good.FLAX, 1 } };
        MaterialsProduced = new GoodsCollection { { Good.CLOTH, 1 } };
        BuildingEffect = null;
    }
}

public class Tavern : Building
{
    public Tavern()
    {
        SpriteSize = new Vector2(2, 1);
        BuildingType = BuildingEnum.TAVERN;
        BuildingName = "tavern";
        Tier = 1;
        CoinCost = 10;
        CoinUpkeep = 1;
        ProductionCost = 3;
        BuildingCost = new GoodsCollection { { Good.WOOD, 5 }, { Good.STONE, 2 }, { Good.TOOL, 3 } };
        MaterialsRequired = new GoodsCollection { { Good.FLAX, 1 } };
        MaterialsProduced = new GoodsCollection { { Good.CLOTH, 1 } };
        BuildingEffect = null;
    }
}

public class Theatre : Building
{
    public Theatre()
    {
        SpriteSize = new Vector2(2, 1);
        BuildingType = BuildingEnum.THEATRE;
        BuildingName = "theatre";
        Tier = 1;
        CoinCost = 10;
        CoinUpkeep = 1;
        ProductionCost = 3;
        BuildingCost = new GoodsCollection { { Good.WOOD, 5 }, { Good.STONE, 2 }, { Good.TOOL, 3 } };
        MaterialsRequired = new GoodsCollection { { Good.FLAX, 1 } };
        MaterialsProduced = new GoodsCollection { { Good.CLOTH, 1 } };
        BuildingEffect = null;
    }
}

public class TradeDepot : Building
{
    public TradeDepot()
    {
        SpriteSize = new Vector2(2, 1);
        BuildingType = BuildingEnum.TRADE_DEPOT;
        BuildingName = "trade_depot";
        Tier = 1;
        CoinCost = 10;
        CoinUpkeep = 1;
        ProductionCost = 3;
        BuildingCost = new GoodsCollection { { Good.WOOD, 5 }, { Good.STONE, 2 }, { Good.TOOL, 3 } };
        MaterialsRequired = new GoodsCollection { { Good.FLAX, 1 } };
        MaterialsProduced = new GoodsCollection { { Good.CLOTH, 1 } };
        BuildingEffect = null;
    }
}

public class University : Building
{
    public University()
    {
        SpriteSize = new Vector2(2, 1);
        BuildingType = BuildingEnum.UNIVERSITY;
        BuildingName = "university";
        Tier = 1;
        CoinCost = 10;
        CoinUpkeep = 1;
        ProductionCost = 3;
        BuildingCost = new GoodsCollection { { Good.WOOD, 5 }, { Good.STONE, 2 }, { Good.TOOL, 3 } };
        MaterialsRequired = new GoodsCollection { { Good.FLAX, 1 } };
        MaterialsProduced = new GoodsCollection { { Good.CLOTH, 1 } };
        BuildingEffect = null;
    }
}

public class Watermill : Building
{
    public Watermill()
    {
        SpriteSize = new Vector2(2, 1);
        BuildingType = BuildingEnum.WATERMILL;
        BuildingName = "watermill";
        Tier = 1;
        CoinCost = 10;
        CoinUpkeep = 1;
        ProductionCost = 3;
        BuildingCost = new GoodsCollection { { Good.WOOD, 5 }, { Good.STONE, 2 }, { Good.TOOL, 3 } };
        MaterialsRequired = new GoodsCollection { { Good.FLAX, 1 } };
        MaterialsProduced = new GoodsCollection { { Good.CLOTH, 1 } };
        BuildingEffect = null;
    }
}

public class Weaver : Building
{
    public Weaver()
    {
        SpriteSize = new Vector2(2, 1);
        BuildingType = BuildingEnum.WEAVER;
        BuildingName = "weaver";
        Tier = 1;
        CoinCost = 10;
        CoinUpkeep = 1;
        ProductionCost = 3;
        BuildingCost = new GoodsCollection { { Good.WOOD, 5 }, { Good.STONE, 2 }, { Good.TOOL, 3 } };
        MaterialsRequired = new GoodsCollection { { Good.FLAX, 1 } };
        MaterialsProduced = new GoodsCollection { { Good.CLOTH, 1 } };
        BuildingEffect = null;
    }
}

public class WheatFarm : Building
{
    public WheatFarm()
    {
        SpriteSize = new Vector2(4, 2);
        BuildingType = BuildingEnum.WHEAT_FARM;
        BuildingName = "wheat_farm";
        Tier = 1;
        CoinCost = 15;
        CoinUpkeep = 2;
        ProductionCost = 3;
        BuildingCost = new GoodsCollection { { Good.WOOD, 1 }, { Good.TOOL, 1 } };
        MaterialsRequired = new GoodsCollection();
        MaterialsProduced = new GoodsCollection { { Good.GRAIN, 1 } };
        BuildingEffect = null;
    }
}

public class Woodcutter : Building
{
    public Woodcutter()
    {
        SpriteSize = new Vector2(1, 1);
        BuildingType = BuildingEnum.WOODCUTTER;
        BuildingName = "woodcutter";
        Tier = 1;
        CoinCost = 10;
        CoinUpkeep = 1;
        ProductionCost = 3;
        BuildingCost = new GoodsCollection { { Good.WOOD, 1 }, { Good.TOOL, 1 } };
        MaterialsRequired = new GoodsCollection();
        MaterialsProduced = new GoodsCollection { { Good.WOOD, 1 } };
        BuildingEffect = null;
    }
}

public class Workshop : Building
{
    public Workshop()
    {
        SpriteSize = new Vector2(2, 1);
        BuildingType = BuildingEnum.WORKSHOP;
        BuildingName = "workshop";
        Tier = 1;
        CoinCost = 10;
        CoinUpkeep = 1;
        ProductionCost = 3;
        BuildingCost = new GoodsCollection { { Good.WOOD, 5 }, { Good.STONE, 2 }, { Good.TOOL, 3 } };
        MaterialsRequired = new GoodsCollection { { Good.FLAX, 1 } };
        MaterialsProduced = new GoodsCollection { { Good.CLOTH, 1 } };
        BuildingEffect = null;
    }
}





























//public class PaperMill : Building
//{

//    public PaperMill()
//    {
//        BuildingName = "PAPER_MILL";
//        Tier = 2;
//        CoinCost = 10;
//        CoinUpkeep = 1;
//        ProductionCost = 3;
//        BuildingCost = new GoodsCollection { { GoodEnum.Wood, 6 }, { GoodEnum.Stone, 2 }, { GoodEnum.Iron, 2 }, { GoodEnum.Tool, 4 } };
//        MaterialsRequired = new GoodsCollection { { GoodEnum.Wood, 1 }, { GoodEnum.Coal, 1 } };
//        MaterialsProduced = new GoodsCollection { { GoodEnum.Paper, 1 } };
//        BuildingEffect = null;
//    }
//}

//public class ArtisanShop : Building
//{

//    public ArtisanShop()
//    {
//        BuildingName = "ARTISAN_SHOP";
//        Tier = 3;
//        CoinCost = 10;
//        CoinUpkeep = 1;
//        ProductionCost = 3;
//        BuildingCost = new GoodsCollection { { GoodEnum.Wood, 4 }, { GoodEnum.Stone, 3 }, { GoodEnum.Iron, 2 }, { GoodEnum.Tool, 6 } };
//        MaterialsRequired = new GoodsCollection { { GoodEnum.Cloth, 1 }, { GoodEnum.Ceramic, 1 }, { GoodEnum.Tool, 1 } };
//        MaterialsProduced = new GoodsCollection { { GoodEnum.Artisan, 1 } };
//        BuildingEffect = null;
//    }
//}


//public class Mint : Building
//{

//    public Mint()
//    {
//        BuildingName = "MINT";
//        Tier = 2;
//        CoinCost = 10;
//        CoinUpkeep = 1;
//        ProductionCost = 3;
//        BuildingCost = new GoodsCollection { { GoodEnum.Wood, 2 }, { GoodEnum.Stone, 5 }, { GoodEnum.Iron, 3 }, { GoodEnum.Tool, 6 } };
//        MaterialsRequired = new GoodsCollection { { GoodEnum.Gold, 1 }, { GoodEnum.Coal, 1 } };
//        MaterialsProduced = new GoodsCollection();
//        BuildingEffect = ProduceCoin;
//    }

//    private void ProduceCoin(GoodsCollection goods)
//    {
//        Debug.Log("COIN+1");
//    }
//}

//public class Mill : Building
//{

//    public Mill()
//    {
//        BuildingName = "MILL";
//        Tier = 1;
//        CoinCost = 10;
//        CoinUpkeep = 1;
//        ProductionCost = 3;
//        BuildingCost = new GoodsCollection { { GoodEnum.Wood, 8 }, { GoodEnum.Stone, 1 }, { GoodEnum.Tool, 2 } };
//        MaterialsRequired = new GoodsCollection();
//        MaterialsProduced = new GoodsCollection();
//        BuildingEffect = ProduceGrain;
//    }

//    private void ProduceGrain(GoodsCollection goods)
//    {
//        goods[GoodEnum.Grain] *= (int)1.25f;
//    }
//}





