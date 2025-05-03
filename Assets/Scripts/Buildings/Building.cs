using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;
using UnityEngine.UI;

//public enum BuildingEnum
//{
//    BAKERY,
//    BANK,
//    BARRACKS,
//    BREWERY,
//    CASTLE,
//    CHAPEL,
//    CLAY_PIT,
//    COAL_MINE,
//    CONSTRUCTION_GUILD,
//    COURTHOUSE,
//    FISHING_WHARF,
//    FLAX_FARM,
//    GOLD_MINE,
//    GRANARY,
//    HUNTING_LODGE,
//    IRON_MINE,
//    LEATHERWORK,
//    LIBRARY,
//    LIGHTHOUSE,
//    LUMBERMILL,
//    MARKET,
//    PHYSICIAN,
//    PIG_FARM,
//    POTTER,
//    PRISON,
//    QUARRY,
//    SHIPYARD,
//    SMITHY,
//    STABLES,
//    STEEL_FORGE,
//    STOREHOUSE,
//    TAVERN,
//    THEATRE,
//    TRADE_DEPOT,
//    UNIVERSITY,
//    WATERMILL,
//    WEAVER,
//    WHEAT_FARM,
//    WOODCUTTER,
//    WORKSHOP,
//}



public class Building
{
    //public GameObject gObject;
    public GridCell GridCell { get; set; }  //TODO this is bi-directional - keep this?

    //public Vector2 SpriteSize { get; protected set; }
    //public BuildingEnum BuildingType { get; protected set; }
    public BuildingBlueprint Blueprint { get; protected set; }
    //public string BuildingName { get; set; }
    public virtual int Level { get; protected set; }    //is sorta count - each time we improve, Level++
    //public int Tier { get; set; }   //civ tier
    //public int CoinCost { get; set; }
    //public int CoinUpkeep { get; set; }
    //public int ProductionCost { get; set; }
    //public int PopulationIncrease { get; protected set; } = 0;
    public int Culture { get; protected set; }
    //public GoodsCollection BuildingCost { get; set; }
    //public GoodsCollection MaterialsRequired { get; set; }
    //public GoodsCollection MaterialsProduced { get; set; }
    public Action<GoodsCollection> BuildingEffect { get; set; }

    //public List<Action<GoodsCollection>> BuildingEffects { get; set; } = new List<Action<GoodsCollection>>();

    //public Sprite Sprite { get; set; }
    //public BuildingButton BuildingButton { get; set; }
    public int CurrentProduction { get; set; }

    public Building(BuildingBlueprint blueprint)
    {
        Blueprint = blueprint;
    }

    public void Initialize()
    {
        CurrentProduction = Blueprint.ProductionCost;
    }

    public virtual bool HandleGoods(GoodsCollection inventory)
    {
        if (CurrentProduction <= 0)
        {
            //check required materials
            foreach (Good good in Blueprint.MaterialsRequired.Keys)
            {
                if (inventory[good] < Blueprint.MaterialsRequired[good])
                    return false;
            }

            //+- goods
            foreach (Good good in inventory.Keys.ToArray())
            {
                if (Blueprint.MaterialsRequired.ContainsKey(good))
                    inventory[good] -= Blueprint.MaterialsRequired[good];

                if (Blueprint.MaterialsProduced.ContainsKey(good))
                    inventory[good] += Blueprint.MaterialsProduced[good];
            }

                BuildingEffect?.Invoke(inventory);
        }

        return true;
    }

    public virtual int GetUpkeep(GoodsCollection inventory)
    {
        return Blueprint.CoinUpkeep;
    }

    public virtual void AddLevel(int value)
    {
        Level += value;
    }

    /// <summary> Decrement BuildingCost from Inventory, otherwise return GoodsCollection of missing goods </summary>
    public virtual GoodsCollection TryStartConstruction(GoodsCollection inventory)
    {
        var missingGoods = new GoodsCollection();

        //check required materials
        foreach (Good good in Blueprint.BuildingCost.Keys)
        {
            var foo = inventory[good] - Blueprint.BuildingCost[good];
            if (foo < 0)
                missingGoods.Add(good, -foo);
        }

        if (missingGoods.Count > 0)
            return missingGoods;

        //+- goods
        foreach (Good good in inventory.Keys.ToArray())
        {
            if (Blueprint.BuildingCost.ContainsKey(good))
                inventory[good] -= Blueprint.BuildingCost[good];
        }

        return missingGoods;
    }

    public virtual string GetMaterialsProducedString()
    {
        return Blueprint.MaterialsProduced.ToString();
    }
}
