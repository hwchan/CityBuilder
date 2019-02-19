using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Bakery : Building
{

    public Bakery()
    {
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
        BuildingName = "castle";
        Tier = 1;
        CoinCost = 10;
        CoinUpkeep = 1;
        ProductionCost = 3;
        BuildingCost = new GoodsCollection { { Good.WOOD, 5 }, { Good.STONE, 2 }, { Good.TOOL, 3 } };
        MaterialsRequired = new GoodsCollection();
        MaterialsProduced = new GoodsCollection { { Good.WOOD, 1 }, { Good.STONE, 1 }, { Good.IRON, 1 }, { Good.TOOL, 1 }, { Good.GRAIN, 1 }, { Good.MEAT, 1 }, { Good.CLAY, 1 }, { Good.COAL, 1 }, { Good.FLAX, 1 }, { Good.HERB, 1 }, { Good.GOLD, 1 }, { Good.CERAMIC, 1 }, { Good.CLOTH, 1 }, { Good.ALE, 1 }, { Good.PAPER, 1 }, { Good.WEAPON, 1 }, { Good.ARTISAN, 1 }, };
        BuildingEffect = null;
    }
}

public class Chapel : Building
{

    public Chapel()
    {
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
        BuildingName = "coal_mine";
        Tier = 2;
        CoinCost = 15;
        CoinUpkeep = 2;
        ProductionCost = 3;
        BuildingCost = new GoodsCollection { { Good.WOOD, 1 }, { Good.STONE, 1 }, { Good.TOOL, 2 } };
        MaterialsRequired = new GoodsCollection();
        MaterialsProduced = new GoodsCollection { { Good.COAL, 1 } };
        BuildingEffect = null;
    }
}

public class ConstructionGuild : Building
{

    public ConstructionGuild()
    {
        BuildingName = "construction_guild";
        Tier = 2;
        CoinCost = 15;
        CoinUpkeep = 2;
        ProductionCost = 3;
        BuildingCost = new GoodsCollection { { Good.WOOD, 1 }, { Good.STONE, 1 }, { Good.TOOL, 2 } };
        MaterialsRequired = new GoodsCollection();
        MaterialsProduced = new GoodsCollection { { Good.COAL, 1 } };
        BuildingEffect = null;
    }
}

public class Courthouse : Building
{

    public Courthouse()
    {
        BuildingName = "courthouse";
        Tier = 3;
        CoinCost = 10;
        CoinUpkeep = 1;
        ProductionCost = 3;
        BuildingCost = new GoodsCollection { { Good.WOOD, 6 }, { Good.STONE, 8 }, { Good.IRON, 3 }, { Good.TOOL, 6 } };
        MaterialsRequired = new GoodsCollection { { Good.PAPER, 1 } };
        MaterialsProduced = new GoodsCollection();
        BuildingEffect = HousingPolicy;
    }

    private void HousingPolicy(GoodsCollection goods)
    {
        MaterialsRequired = new GoodsCollection { { Good.PAPER, 1 } };
        CoinUpkeep = 10;
        //growth+
    }

    private void ConscriptionPolicy(GoodsCollection goods)
    {
        MaterialsRequired = new GoodsCollection { { Good.PAPER, 3 } };
        CoinUpkeep = 15;
        //military upkeep-
    }

    private void TaxPolicy(GoodsCollection goods)
    {
        MaterialsRequired = new GoodsCollection { { Good.PAPER, 2 } };
        CoinUpkeep = 20;
        //tax+
    }
}

public class FishingWharf : Building
{

    public FishingWharf()
    {
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
        BuildingName = "steel_forge";
        Tier = 3;
        CoinCost = 10;
        CoinUpkeep = 1;
        ProductionCost = 3;
        BuildingCost = new GoodsCollection { { Good.WOOD, 6 }, { Good.STONE, 8 }, { Good.IRON, 3 }, { Good.TOOL, 6 } };
        MaterialsRequired = new GoodsCollection();
        MaterialsProduced = new GoodsCollection();
        BuildingEffect = ProduceSteel;
    }

    private void ProduceSteel(GoodsCollection goods)
    {
        MaterialsRequired = new GoodsCollection { { Good.IRON, 7 }, { Good.COAL, 3 } };
        MaterialsProduced = new GoodsCollection { { Good.IRON, 12 } };
        CoinUpkeep = 10;
    }

    private void ProduceTools(GoodsCollection goods)
    {
        MaterialsRequired = new GoodsCollection { { Good.IRON, 6 }, { Good.COAL, 3 } };
        MaterialsProduced = new GoodsCollection { { Good.TOOL, 12 } };
        CoinUpkeep = 15;
    }

    private void ProduceWeapons(GoodsCollection goods)
    {
        MaterialsRequired = new GoodsCollection { { Good.IRON, 10 }, { Good.COAL, 4 } };
        MaterialsProduced = new GoodsCollection { { Good.WEAPON, 10 } };
        CoinUpkeep = 20;
    }

    private void ProduceBuildingMaterials(GoodsCollection good)
    {
        MaterialsRequired = new GoodsCollection { { Good.IRON, 10 }, { Good.COAL, 4 }, { Good.TOOL, 8 } };
        CoinUpkeep = 20;
        //production+
    }
}

public class Storehouse : Building
{
    public Storehouse()
    {
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





