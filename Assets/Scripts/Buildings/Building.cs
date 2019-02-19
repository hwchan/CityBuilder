using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;
using UnityEngine.UI;

public class Building {

    public GameObject gObject;

    public string BuildingName { get; set; }
    public virtual int Level { get; protected set; }
    public int Tier { get; set; }   //civ tier
    public int CoinCost { get; set; }
    public int CoinUpkeep { get; set; }
    public int ProductionCost { get; set; }
    public int WorkerCapacity { get; set; }
    public int Workers { get; protected set; }
    public int PopulationIncrease { get; protected set; } = 0;
    public GoodsCollection BuildingCost { get; set; }
    public GoodsCollection MaterialsRequired { get; set; }
    public GoodsCollection MaterialsProduced { get; set; }
    public Action<GoodsCollection> BuildingEffect { get; set; }

    public Sprite Sprite { get; set; }
    public BuildingButton BuildingButton { get; set; }
    public int CurrentProduction { get; set; }

    public void Initialize()
    {
        CurrentProduction = ProductionCost;
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
        if (MaterialsRequired.Keys.Count > 0)
            return true;

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

            if (BuildingEffect != null)
                BuildingEffect(inventory);
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
}
