using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;
using UnityEngine.UI;

public class Building {

    private int _level;
    public GameObject gObject;

    public string BuildingName { get; set; }
    public int Level
    {
        get { return _level; }
        set
        {
            _level = value;
            WorkerCapacity = Level * 1;
        }
    }
    public int Tier { get; set; }   //civ tier
    public int CoinCost { get; set; }
    public int CoinUpkeep { get; set; }
    public int ProductionCost { get; set; }
    public int WorkerCapacity { get; set; }
    public int Workers { get; private set; }
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

    public void HandleGoods(GoodsCollection inventory, int numberOfBuildings)
    {
        //check required materials
        foreach(Good good in MaterialsRequired.Keys)
        {
            if(inventory[good] < MaterialsRequired[good] * numberOfBuildings)
                return;
        }

        //+- goods
        foreach (Good good in inventory.Keys.ToArray())
        {
            if (MaterialsRequired.ContainsKey(good))
                inventory[good] -= (MaterialsRequired[good] * numberOfBuildings);

            if (MaterialsProduced.ContainsKey(good))
                inventory[good] += (MaterialsProduced[good] * numberOfBuildings);
        }

        if(BuildingEffect != null)
            BuildingEffect(inventory);
    }
}
