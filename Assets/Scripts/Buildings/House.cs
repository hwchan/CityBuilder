using UnityEngine;
using System.Collections;
using System.Linq;

public class House : Building
{
    public House()
    {
        BuildingName = "house";
        Tier = 1;
        CoinCost = 15;
        //CoinUpkeep = -10;
        ProductionCost = 1;
        WorkerCapacity = 0;
        BuildingCost = new GoodsCollection { { Good.Wood, 1 } };
        MaterialsRequired = new GoodsCollection();
        MaterialsProduced = new GoodsCollection();
        BuildingEffect = null;
    }

    private Building GetHouseStats(int level)
    {
        var b = new House { Level = level };

        switch (level)
        {
            case 1:
                b.CoinUpkeep = -10;
                b.BuildingCost = new GoodsCollection { { Good.Wood, 1 } };
                b.PopulationIncrease = 5;
                break;
            case 2:
                b.CoinUpkeep = -20;
                break;
            case 3:
                b.CoinUpkeep = -40;
                b.BuildingCost = new GoodsCollection { { Good.Wood, 2 }, { Good.Stone, 1 } };
                b.MaterialsRequired = new GoodsCollection { { Good.Grain, 1 } };
                break;
            case 4:
                b.CoinUpkeep = -60;
                b.MaterialsRequired = new GoodsCollection { { Good.Grain, 2 } };
                break;
            case 5:
            case 6:
            case 7:
            case 8:
            case 9:
            case 10:
                b.CoinUpkeep = -90;
                b.BuildingCost = new GoodsCollection { { Good.Wood, 3 }, { Good.Stone, 2 }, { Good.Tool, 1 } };
                b.MaterialsRequired = new GoodsCollection { { Good.Grain, 3 }, { Good.Wood, 2 } };
                break;
            //...
            case 11:
                b.CoinUpkeep = -1000;
                b.MaterialsRequired = new GoodsCollection {
                    { Good.Grain, 9 },
                    { Good.Wood, 8 },
                    { Good.Meat, 5 },
                    { Good.Ceramic, 3 },
                    { Good.Ale, 3 },
                    { Good.Cloth, 5 },
                    { Good.Artisan, 1 },
                };
                break;
        }
        return b;
    }

    private Building GetHighestLevelHouse(GoodsCollection inventory)
    {
        Building b = GetHouseStats(Level);

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
