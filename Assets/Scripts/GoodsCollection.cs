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
        Add(Good.WOOD, amount);
        Add(Good.STONE, amount);
        Add(Good.IRON, amount);
        Add(Good.TOOL, amount);

        Add(Good.GRAIN, amount);
        Add(Good.MEAT, amount);

        Add(Good.CLAY, amount);
        Add(Good.COAL, amount);
        Add(Good.FLAX, amount);
        Add(Good.HERB, amount);
        Add(Good.GOLD, amount);

        Add(Good.CERAMIC, amount);
        Add(Good.CLOTH, amount);
        Add(Good.PAPER, amount);
        Add(Good.ALE, amount);
        Add(Good.WEAPON, amount);
        Add(Good.ARTISAN, amount);
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

    public static GoodsCollection operator- (GoodsCollection a, GoodsCollection b)
    {
        var ret = new GoodsCollection(a);

        foreach (var key in b.Keys)
        {
            ret[key] -= b[key];
        }

        return ret;
    }

    public override string ToString()
    {
        StringBuilder build = new StringBuilder();
        foreach (KeyValuePair<Good, int> kvp in this)
            build.Append(kvp.Key.ToString() + ":" + kvp.Value + " ");

        return build.ToString();
    }
}
