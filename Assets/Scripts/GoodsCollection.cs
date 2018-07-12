using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GoodsCollection : Dictionary<Good, int> {

    public GoodsCollection()
    {

    }

    public GoodsCollection(int amount)
    {
        Add(Good.Wood, amount);
        Add(Good.Stone, amount);
        Add(Good.Iron, amount);
        Add(Good.Tool, amount);

        Add(Good.Grain, amount);
        Add(Good.Meat, amount);

        Add(Good.Clay, amount);
        Add(Good.Coal, amount);
        Add(Good.Flax, amount);
        Add(Good.Herb, amount);
        Add(Good.Gold, amount);

        Add(Good.Ceramic, amount);
        Add(Good.Cloth, amount);
        Add(Good.Paper, amount);
        Add(Good.Ale, amount);
        Add(Good.Weapon, amount);
        Add(Good.Artisan, amount);
    }

    public GoodsCollection(GoodsCollection goods)
    {
        foreach(KeyValuePair<Good, int> kvp in goods)
        {
            if (ContainsKey(kvp.Key))
                this[kvp.Key] += kvp.Value;
            else
                Add(kvp.Key, kvp.Value);
        }
    }

    public string GetKvp(Good good)
    {
        return good + ": " + this[good];
    }
}
