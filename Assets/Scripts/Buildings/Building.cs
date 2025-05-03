using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;
using UnityEngine.UI;

public enum BuildingEnum
{
    BAKERY,
    BANK,
    BARRACKS,
    BREWERY,
    CASTLE,
    CHAPEL,
    CLAY_PIT,
    COAL_MINE,
    CONSTRUCTION_GUILD,
    COURTHOUSE,
    FISHING_WHARF,
    FLAX_FARM,
    GOLD_MINE,
    GRANARY,
    HOUSE,
    HUNTING_LODGE,
    IRON_MINE,
    LEATHERWORK,
    LIBRARY,
    LIGHTHOUSE,
    LUMBERMILL,
    MARKET,
    PHYSICIAN,
    PIG_FARM,
    POTTER,
    PRISON,
    QUARRY,
    SHIPYARD,
    SMITHY,
    STABLES,
    STEEL_FORGE,
    STOREHOUSE,
    TAVERN,
    THEATRE,
    TRADE_DEPOT,
    UNIVERSITY,
    WATERMILL,
    WEAVER,
    WHEAT_FARM,
    WOODCUTTER,
    WORKSHOP,
}

//TODO replace dictionary key of BuildingEnum, use this
public struct BuildingBlueprint
{
    public string BuildingName { get; private set; }
    public Sprite Sprite { get; private set; }
    public Vector2 SpriteSize { get; private set; }

    public BuildingBlueprint(string name, Vector2 size)
    {
        BuildingName = name;
        SpriteSize = size;
        Sprite = Resources.Load<Sprite>(BuildingName);
    }
}

public class Building
{
    public GridCell GridCell { get; set; }  //TODO this is bi-directional - keep this?

    public Vector2 SpriteSize { get; protected set; }
    public BuildingEnum BuildingType { get; protected set; }
    public string BuildingName { get; set; }
    public virtual int Level { get; protected set; }
    public int Tier { get; set; }   //civ tier
    public int CoinCost { get; set; }
    public int CoinUpkeep { get; set; }
    public int ProductionCost { get; set; }
    public int PopulationIncrease { get; protected set; } = 0;
    public int Culture { get; protected set; }
    public GoodsCollection BuildingCost { get; set; }
    public GoodsCollection MaterialsRequired { get; set; }
    public GoodsCollection MaterialsProduced { get; set; }
    public Action<GoodsCollection> BuildingEffect { get; set; }

    public List<Action<GoodsCollection>> BuildingEffects { get; set; } = new List<Action<GoodsCollection>>();

    public Sprite Sprite { get; set; }
    public BuildingButton BuildingButton { get; set; }
    public int ProductionLeft { get; set; }

    public void ResetProduction()
    {
        ProductionLeft = ProductionCost;
    }

    public virtual bool HandleGoods(GoodsCollection inventory)
    {
        if (ProductionLeft <= 0)
        {
            //check required materials
            foreach (Good good in MaterialsRequired.Keys)
            {
                if (inventory[good] < MaterialsRequired[good])
                    return false;
            }

            //+- goods
            foreach (Good good in inventory.Keys.ToArray())
            {
                if (MaterialsRequired.ContainsKey(good))
                    inventory[good] -= MaterialsRequired[good];

                if (MaterialsProduced.ContainsKey(good))
                    inventory[good] += MaterialsProduced[good];
            }

                BuildingEffect?.Invoke(inventory);
        }

        return true;
    }

    public virtual int GetUpkeep(GoodsCollection inventory)
    {
        return CoinUpkeep;
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
        foreach (Good good in BuildingCost.Keys)
        {
            var delta = inventory[good] - BuildingCost[good];
            if (delta < 0)
                missingGoods.Add(good, -delta);
        }

        if (missingGoods.Count > 0)
            return missingGoods;

        //+- goods
        foreach (Good good in inventory.Keys.ToArray())
        {
            if (BuildingCost.ContainsKey(good))
                inventory[good] -= BuildingCost[good];
        }

        return missingGoods;
    }

    public virtual string GetMaterialsProducedString()
    {
        return MaterialsProduced.ToString();
    }
}
