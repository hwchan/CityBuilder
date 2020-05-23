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

//this is like a BuildingTemplate - 1 of each building type
//will need another thing for each instance with coord + workers?
//NVM
public class Building
{
    //public GameObject gObject;
    public GridCell GridCell { get; set; }  //TODO this is bi-directional - keep this?

    public Vector2 SpriteSize { get; protected set; }
    public BuildingEnum BuildingType { get; protected set; }
    public string BuildingName { get; set; }
    public virtual int Level { get; protected set; }    //is sorta count - each time we improve, Level++
    public int Tier { get; set; }   //civ tier
    public int CoinCost { get; set; }
    public int CoinUpkeep { get; set; }
    public int ProductionCost { get; set; }
    public int WorkerCapacity { get; set; }
    public int Workers { get; protected set; }
    public int PopulationIncrease { get; protected set; } = 0;
    public int Culture { get; protected set; }
    public GoodsCollection BuildingCost { get; set; }
    public GoodsCollection MaterialsRequired { get; set; }
    public GoodsCollection MaterialsProduced { get; set; }
    public Action<GoodsCollection> BuildingEffect { get; set; }

    public List<Action<GoodsCollection>> BuildingEffects { get; set; } = new List<Action<GoodsCollection>>();

    public Sprite Sprite { get; set; }
    public BuildingButton BuildingButton { get; set; }
    public int CurrentProduction { get; set; }

    //public string MaterialsProducedString { get; set; }

    //public Building()
    //{
    //    Sprite = Resources.Load<Sprite>(BuildingName);
    //}

    public void Initialize()
    {
        CurrentProduction = ProductionCost;
        //MaterialsProducedString = MaterialsProduced.ToString();
    }

    public bool TryAddWorker(int val)
    {
        var total = Workers + val;
        if (total < 0 || total > WorkerCapacity)
            return false;

        Workers += val;
        return true;
    }

    public virtual bool HandleGoods(GoodsCollection inventory)
    {
        for (int i = 0; i < Workers; i++)
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
        return Workers * CoinUpkeep;
    }

    public virtual void AddLevel(int value)
    {
        Level += value;
        WorkerCapacity = Level * 1;
    }

    /// <summary> Decrement BuildingCost from Inventory, otherwise return GoodsCollection of missing goods </summary>
    public virtual GoodsCollection TryStartConstruction(GoodsCollection inventory)
    {
        var missingGoods = new GoodsCollection();

        //check required materials
        foreach (Good good in BuildingCost.Keys)
        {
            var foo = inventory[good] - BuildingCost[good];
            if (foo < 0)
                missingGoods.Add(good, -foo);
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
