using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;

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

    public new int this[Good good]
    {
        get
        {
            if (ContainsKey(good))
                return base[good];
            return 0;
        }
        set
        {
            if (ContainsKey(good))
                base[good] = value;
            else
                Add(good, value);
        }
    }

    public string GetKvp(Good good)
    {
        return good + ": " + this[good];
    }

    public override string ToString()
    {
        StringBuilder build = new StringBuilder();
        foreach (KeyValuePair<Good, int> kvp in this)
            build.Append(kvp.Key.ToString() + ":" + kvp.Value + " ");

        return build.ToString();
    }
}
