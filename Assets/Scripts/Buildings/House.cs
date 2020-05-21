using UnityEngine;
using System.Collections;
using System.Linq;

public class House : Building
{
    public int CultureRequirement { get; set; }

    public House()
    {
        BuildingName = "house";
        Tier = 1;
        CoinCost = 15;
        ProductionCost = 1;
        WorkerCapacity = 0;
        BuildingCost = new GoodsCollection { { Good.WOOD, 1 } };
        MaterialsRequired = new GoodsCollection();
        MaterialsProduced = new GoodsCollection();
        BuildingEffect = null;
    }

    private House GetHouseStats(int level)
    {
        var b = new House { Level = level };

        switch (level)
        {
            case 1:
                b.CoinUpkeep = -10;
                b.BuildingCost = new GoodsCollection { { Good.WOOD, 1 } };
                b.PopulationIncrease = 5;
                break;
            case 2:
                b.CoinUpkeep = -20;
                break;
            case 3:
                b.CoinUpkeep = -40;
                b.BuildingCost = new GoodsCollection { { Good.WOOD, 2 }, { Good.STONE, 1 } };
                b.MaterialsRequired = new GoodsCollection { { Good.GRAIN, 1 } };
                break;
            case 4:
                b.CoinUpkeep = -60;
                b.MaterialsRequired = new GoodsCollection { { Good.GRAIN, 2 } };
                break;
            case 5:
            case 6:
            case 7:
            case 8:
            case 9:
            case 10:
                b.CoinUpkeep = -90;
                b.BuildingCost = new GoodsCollection { { Good.WOOD, 3 }, { Good.STONE, 2 }, { Good.TOOL, 1 } };
                b.MaterialsRequired = new GoodsCollection { { Good.GRAIN, 3 }, { Good.WOOD, 2 } };
                break;
            //...
            case 11:
                b.CoinUpkeep = -1000;
                b.MaterialsRequired = new GoodsCollection {
                    { Good.GRAIN, 9 },
                    { Good.WOOD, 8 },
                    { Good.MEAT, 5 },
                    { Good.CERAMIC, 3 },
                    { Good.ALE, 3 },
                    { Good.CLOTH, 5 },
                    { Good.ARTISAN, 1 },
                };
                break;
        }
        return b;
    }

    private Building GetHighestLevelHouse(GoodsCollection inventory)
    {
        House b = GetHouseStats(Level);

        //find the highest level of House we can support with our goods
        for (int i = Level; i > 0; i--)
        {
            bool canSupport = true;
            b = GetHouseStats(i);
            foreach (Good good in b.MaterialsRequired.Keys)
            {
                if (inventory[good] < b.MaterialsRequired[good])
                    canSupport = false;
            }

            if (b.CultureRequirement > Globals.CityManager.Culture)
            {
                canSupport = false;
            }

            if (canSupport)
            {
                //we have the highest level of House we can support
                break;
            }
        }

        CoinUpkeep = b.CoinUpkeep;
        BuildingCost = b.BuildingCost;
        MaterialsRequired = b.MaterialsRequired;
        MaterialsProduced = b.MaterialsProduced;
        return b;
    }

    public override bool HandleGoods(GoodsCollection inventory)
    {
        Building b = GetHighestLevelHouse(inventory);

        //+- goods
        foreach (Good good in inventory.Keys.ToArray())
        {
            if (b.MaterialsRequired.ContainsKey(good))
                inventory[good] -= b.MaterialsRequired[good];

            if (b.MaterialsProduced.ContainsKey(good))
                inventory[good] += b.MaterialsProduced[good];
        }

        if (BuildingEffect != null)
            BuildingEffect(inventory);

        return true;
    }

    public override int GetUpkeep(GoodsCollection inventory)
    {
        //Debug.Log("Tax: " + CoinUpkeep);
        return CoinUpkeep;
    }

    public override void AddLevel(int value)
    {
        base.AddLevel(value);
        var pop = GetHouseStats(Level).PopulationIncrease;
        Globals.CityManager.TryAddPopulation(pop);
    }
}
