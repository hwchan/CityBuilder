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
        BuildingCost = new GoodsCollection { { Good.Wood, 3 }, { Good.Stone, 5 }, { Good.Iron, 2 }, { Good.Tool, 3 } };
        MaterialsRequired = new GoodsCollection { { Good.Grain, 1 }, { Good.Wood, 1 } };
        MaterialsProduced = new GoodsCollection { { Good.Grain, 3 } };
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
        BuildingCost = new GoodsCollection { { Good.Wood, 5 }, { Good.Stone, 2 }, { Good.Tool, 3 } };
        MaterialsRequired = new GoodsCollection { { Good.Flax, 1 } };
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
        BuildingCost = new GoodsCollection { { Good.Wood, 5 }, { Good.Stone, 2 }, { Good.Tool, 3 } };
        MaterialsRequired = new GoodsCollection { { Good.Flax, 1 } };
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
        BuildingCost = new GoodsCollection { { Good.Wood, 3 }, { Good.Stone, 5 }, { Good.Iron, 2 }, { Good.Tool, 3 } };
        MaterialsRequired = new GoodsCollection { { Good.Grain, 1 }, { Good.Herb, 1 } };
        MaterialsProduced = new GoodsCollection { { Good.Ale, 1 } };
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
        BuildingCost = new GoodsCollection { { Good.Wood, 5 }, { Good.Stone, 2 }, { Good.Tool, 3 } };
        MaterialsRequired = new GoodsCollection();
        MaterialsProduced = new GoodsCollection { { Good.Wood, 1 }, { Good.Stone, 1 }, { Good.Iron, 1 }, { Good.Tool, 1 }, { Good.Grain, 1 }, { Good.Meat, 1 }, { Good.Clay, 1 }, { Good.Coal, 1 }, { Good.Flax, 1 }, { Good.Herb, 1 }, { Good.Gold, 1 }, { Good.Ceramic, 1 }, { Good.Cloth, 1 }, { Good.Ale, 1 }, { Good.Paper, 1 }, { Good.Weapon, 1 }, { Good.Artisan, 1 }, };
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
        BuildingCost = new GoodsCollection { { Good.Wood, 5 }, { Good.Stone, 2 }, { Good.Tool, 3 } };
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
        BuildingCost = new GoodsCollection { { Good.Wood, 1 }, { Good.Stone, 1 }, { Good.Tool, 1 } };
        MaterialsRequired = new GoodsCollection();
        MaterialsProduced = new GoodsCollection { { Good.Clay, 1 } };
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
        BuildingCost = new GoodsCollection { { Good.Wood, 1 }, { Good.Stone, 1 }, { Good.Tool, 2 } };
        MaterialsRequired = new GoodsCollection();
        MaterialsProduced = new GoodsCollection { { Good.Coal, 1 } };
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
        BuildingCost = new GoodsCollection { { Good.Wood, 1 }, { Good.Stone, 1 }, { Good.Tool, 2 } };
        MaterialsRequired = new GoodsCollection();
        MaterialsProduced = new GoodsCollection { { Good.Coal, 1 } };
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
        BuildingCost = new GoodsCollection { { Good.Wood, 6 }, { Good.Stone, 8 }, { Good.Iron, 3 }, { Good.Tool, 6 } };
        MaterialsRequired = new GoodsCollection { { Good.Paper, 1 } };
        MaterialsProduced = new GoodsCollection();
        BuildingEffect = HousingPolicy;
    }

    private void HousingPolicy(GoodsCollection goods)
    {
        MaterialsRequired = new GoodsCollection { { Good.Paper, 1 } };
        CoinUpkeep = 10;
        //growth+
    }

    private void ConscriptionPolicy(GoodsCollection goods)
    {
        MaterialsRequired = new GoodsCollection { { Good.Paper, 3 } };
        CoinUpkeep = 15;
        //military upkeep-
    }

    private void TaxPolicy(GoodsCollection goods)
    {
        MaterialsRequired = new GoodsCollection { { Good.Paper, 2 } };
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
        BuildingCost = new GoodsCollection { { Good.Wood, 2 }, { Good.Tool, 1 } };
        MaterialsRequired = new GoodsCollection();
        MaterialsProduced = new GoodsCollection { { Good.Meat, 1 } };
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
        BuildingCost = new GoodsCollection { { Good.Wood, 2 }, { Good.Tool, 1 } };
        MaterialsRequired = new GoodsCollection();
        MaterialsProduced = new GoodsCollection { { Good.Flax, 1 } };
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
        BuildingCost = new GoodsCollection { { Good.Wood, 1 }, { Good.Stone, 3 }, { Good.Iron, 1 }, { Good.Tool, 2 } };
        MaterialsRequired = new GoodsCollection();
        MaterialsProduced = new GoodsCollection { { Good.Gold, 1 } };
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
        BuildingCost = new GoodsCollection { { Good.Wood, 1 }, { Good.Stone, 3 }, { Good.Iron, 1 }, { Good.Tool, 2 } };
        MaterialsRequired = new GoodsCollection();
        MaterialsProduced = new GoodsCollection { { Good.Gold, 1 } };
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
        BuildingCost = new GoodsCollection { { Good.Wood, 1 }, { Good.Stone, 3 }, { Good.Iron, 1 }, { Good.Tool, 2 } };
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
        BuildingCost = new GoodsCollection { { Good.Wood, 1 }, { Good.Stone, 1 }, { Good.Tool, 2 } };
        MaterialsRequired = new GoodsCollection();
        MaterialsProduced = new GoodsCollection { { Good.Iron, 1 } };
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
        BuildingCost = new GoodsCollection { { Good.Wood, 1 }, { Good.Stone, 1 }, { Good.Tool, 2 } };
        MaterialsRequired = new GoodsCollection();
        MaterialsProduced = new GoodsCollection { { Good.Iron, 1 } };
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
        BuildingCost = new GoodsCollection { { Good.Wood, 6 }, { Good.Stone, 8 }, { Good.Iron, 3 }, { Good.Tool, 6 } };
        MaterialsRequired = new GoodsCollection { { Good.Paper, 1 } };
        MaterialsProduced = new GoodsCollection();
        BuildingEffect = Research;
    }

    private void Research(GoodsCollection goods)
    {
        MaterialsRequired = new GoodsCollection { { Good.Paper, 1 } };
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
        BuildingCost = new GoodsCollection { { Good.Wood, 6 }, { Good.Stone, 8 }, { Good.Iron, 3 }, { Good.Tool, 6 } };
        MaterialsRequired = new GoodsCollection { { Good.Paper, 1 } };
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
        BuildingCost = new GoodsCollection { { Good.Wood, 5 }, { Good.Stone, 2 }, { Good.Tool, 3 } };
        MaterialsRequired = new GoodsCollection { { Good.Flax, 1 } };
        MaterialsProduced = new GoodsCollection { { Good.Cloth, 1 } };
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
        BuildingCost = new GoodsCollection { { Good.Wood, 5 }, { Good.Stone, 2 }, { Good.Tool, 3 } };
        MaterialsRequired = new GoodsCollection { { Good.Flax, 1 } };
        MaterialsProduced = new GoodsCollection { { Good.Cloth, 1 } };
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
        BuildingCost = new GoodsCollection { { Good.Wood, 5 }, { Good.Stone, 2 }, { Good.Tool, 3 } };
        MaterialsRequired = new GoodsCollection { { Good.Flax, 1 } };
        MaterialsProduced = new GoodsCollection { { Good.Cloth, 1 } };
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
        BuildingCost = new GoodsCollection { { Good.Wood, 3 }, { Good.Stone, 1 }, { Good.Tool, 2 } };
        MaterialsRequired = new GoodsCollection();
        MaterialsProduced = new GoodsCollection { { Good.Meat, 1 } };
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
        BuildingCost = new GoodsCollection { { Good.Wood, 3 }, { Good.Stone, 3 }, { Good.Tool, 2 } };
        MaterialsRequired = new GoodsCollection { { Good.Clay, 1 } };
        MaterialsProduced = new GoodsCollection { { Good.Ceramic, 1 } };
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
        BuildingCost = new GoodsCollection { { Good.Wood, 3 }, { Good.Stone, 3 }, { Good.Tool, 2 } };
        MaterialsRequired = new GoodsCollection { { Good.Clay, 1 } };
        MaterialsProduced = new GoodsCollection { { Good.Ceramic, 1 } };
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
        BuildingCost = new GoodsCollection { { Good.Wood, 1 }, { Good.Tool, 3 } };
        MaterialsRequired = new GoodsCollection();
        MaterialsProduced = new GoodsCollection { { Good.Stone, 1 } };
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
        BuildingCost = new GoodsCollection { { Good.Wood, 1 }, { Good.Tool, 3 } };
        MaterialsRequired = new GoodsCollection();
        MaterialsProduced = new GoodsCollection { { Good.Stone, 1 } };
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
        BuildingCost = new GoodsCollection { { Good.Wood, 2 }, { Good.Stone, 1 }, { Good.Tool, 1 } };
        MaterialsRequired = new GoodsCollection { { Good.Iron, 1 } };
        MaterialsProduced = new GoodsCollection { { Good.Tool, 1 } };
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
        BuildingCost = new GoodsCollection { { Good.Wood, 2 }, { Good.Stone, 1 }, { Good.Tool, 1 } };
        MaterialsRequired = new GoodsCollection { { Good.Iron, 1 } };
        MaterialsProduced = new GoodsCollection { { Good.Tool, 1 } };
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
        BuildingCost = new GoodsCollection { { Good.Wood, 6 }, { Good.Stone, 8 }, { Good.Iron, 3 }, { Good.Tool, 6 } };
        MaterialsRequired = new GoodsCollection();
        MaterialsProduced = new GoodsCollection();
        BuildingEffect = ProduceSteel;
    }

    private void ProduceSteel(GoodsCollection goods)
    {
        MaterialsRequired = new GoodsCollection { { Good.Iron, 7 }, { Good.Coal, 3 } };
        MaterialsProduced = new GoodsCollection { { Good.Iron, 12 } };
        CoinUpkeep = 10;
    }

    private void ProduceTools(GoodsCollection goods)
    {
        MaterialsRequired = new GoodsCollection { { Good.Iron, 6 }, { Good.Coal, 3 } };
        MaterialsProduced = new GoodsCollection { { Good.Tool, 12 } };
        CoinUpkeep = 15;
    }

    private void ProduceWeapons(GoodsCollection goods)
    {
        MaterialsRequired = new GoodsCollection { { Good.Iron, 10 }, { Good.Coal, 4 } };
        MaterialsProduced = new GoodsCollection { { Good.Weapon, 10 } };
        CoinUpkeep = 20;
    }

    private void ProduceBuildingMaterials(GoodsCollection good)
    {
        MaterialsRequired = new GoodsCollection { { Good.Iron, 10 }, { Good.Coal, 4 }, { Good.Tool, 8 } };
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
        BuildingCost = new GoodsCollection { { Good.Wood, 5 }, { Good.Stone, 2 }, { Good.Tool, 3 } };
        MaterialsRequired = new GoodsCollection { { Good.Flax, 1 } };
        MaterialsProduced = new GoodsCollection { { Good.Cloth, 1 } };
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
        BuildingCost = new GoodsCollection { { Good.Wood, 5 }, { Good.Stone, 2 }, { Good.Tool, 3 } };
        MaterialsRequired = new GoodsCollection { { Good.Flax, 1 } };
        MaterialsProduced = new GoodsCollection { { Good.Cloth, 1 } };
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
        BuildingCost = new GoodsCollection { { Good.Wood, 5 }, { Good.Stone, 2 }, { Good.Tool, 3 } };
        MaterialsRequired = new GoodsCollection { { Good.Flax, 1 } };
        MaterialsProduced = new GoodsCollection { { Good.Cloth, 1 } };
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
        BuildingCost = new GoodsCollection { { Good.Wood, 5 }, { Good.Stone, 2 }, { Good.Tool, 3 } };
        MaterialsRequired = new GoodsCollection { { Good.Flax, 1 } };
        MaterialsProduced = new GoodsCollection { { Good.Cloth, 1 } };
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
        BuildingCost = new GoodsCollection { { Good.Wood, 5 }, { Good.Stone, 2 }, { Good.Tool, 3 } };
        MaterialsRequired = new GoodsCollection { { Good.Flax, 1 } };
        MaterialsProduced = new GoodsCollection { { Good.Cloth, 1 } };
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
        BuildingCost = new GoodsCollection { { Good.Wood, 5 }, { Good.Stone, 2 }, { Good.Tool, 3 } };
        MaterialsRequired = new GoodsCollection { { Good.Flax, 1 } };
        MaterialsProduced = new GoodsCollection { { Good.Cloth, 1 } };
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
        BuildingCost = new GoodsCollection { { Good.Wood, 5 }, { Good.Stone, 2 }, { Good.Tool, 3 } };
        MaterialsRequired = new GoodsCollection { { Good.Flax, 1 } };
        MaterialsProduced = new GoodsCollection { { Good.Cloth, 1 } };
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
        BuildingCost = new GoodsCollection { { Good.Wood, 1 }, { Good.Tool, 1 } };
        MaterialsRequired = new GoodsCollection();
        MaterialsProduced = new GoodsCollection { { Good.Grain, 1 } };
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
        BuildingCost = new GoodsCollection { { Good.Wood, 1 }, { Good.Tool, 1 } };
        MaterialsRequired = new GoodsCollection();
        MaterialsProduced = new GoodsCollection { { Good.Wood, 1 } };
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
        BuildingCost = new GoodsCollection { { Good.Wood, 5 }, { Good.Stone, 2 }, { Good.Tool, 3 } };
        MaterialsRequired = new GoodsCollection { { Good.Flax, 1 } };
        MaterialsProduced = new GoodsCollection { { Good.Cloth, 1 } };
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





