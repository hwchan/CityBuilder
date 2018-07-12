using UnityEngine;
using System.Collections;

public enum Good
{
    Wood,
    Stone,
    Iron,
    Tool,

    Grain,
    Meat,

    Clay,
    Coal,
    Flax,
    Gold,
    Herb,

    Cloth,
    Ceramic,
    Ale,
    Artisan,
    Paper,
    Weapon
}

public abstract class GoodBase {

    public string GoodName { get; set; }
    public Good Enum { get; set; }
    public string GoodType { get; set; }
    public int TradeValue { get; set; }
    public int Amount { get; set; }

    public override string ToString()
    {
        return GoodName;
    }

    public override int GetHashCode()
    {
        return GoodName.GetHashCode();
    }

    public override bool Equals(object obj)
    {
        return ((GoodBase)obj).GoodName == GoodName;
    }
}

public class Wood : GoodBase
{

    public Wood(int amount = 0)
    {
        GoodName = "WOOD";
        Enum = Good.Wood;
        GoodType = "MATERIAL";
        TradeValue = 2;
        Amount = amount;
    }
}

public class Stone : GoodBase
{

    public Stone(int amount = 0)
    {
        GoodName = "STONE";
        Enum = Good.Stone;
        GoodType = "MATERIAL";
        TradeValue = 2;
        Amount = amount;
    }
}

public class Iron : GoodBase
{

    public Iron(int amount = 0)
    {
        GoodName = "IRON";
        Enum = Good.Iron;
        GoodType = "MATERIAL";
        TradeValue = 5;
        Amount = amount;
    }
}

public class Tool : GoodBase
{

    public Tool(int amount = 0)
    {
        GoodName = "TOOL";
        Enum = Good.Tool;
        GoodType = "MATERIAL";
        TradeValue = 5;
        Amount = amount;
    }
}

public class Grain : GoodBase
{

    public Grain(int amount = 0)
    {
        GoodName = "GRAIN";
        Enum = Good.Grain;
        GoodType = "FOOD";
        TradeValue = 5;
        Amount = amount;
    }
}

public class Meat : GoodBase
{

    public Meat(int amount = 0)
    {
        GoodName = "MEAT";
        Enum = Good.Meat;
        GoodType = "FOOD";
        TradeValue = 5;
        Amount = amount;
    }
}

public class Clay : GoodBase
{

    public Clay(int amount = 0)
    {
        GoodName = "CLAY";
        Enum = Good.Clay;
        GoodType = "RAW";
        TradeValue = 5;
        Amount = amount;
    }
}

public class Coal : GoodBase
{

    public Coal(int amount = 0)
    {
        GoodName = "COAL";
        Enum = Good.Coal;
        GoodType = "RAW";
        TradeValue = 5;
        Amount = amount;
    }
}

public class Flax : GoodBase
{

    public Flax(int amount = 0)
    {
        GoodName = "FLAX";
        Enum = Good.Flax;
        GoodType = "RAW";
        TradeValue = 5;
        Amount = amount;
    }
}

public class Gold : GoodBase
{

    public Gold(int amount = 0)
    {
        GoodName = "GOLD";
        Enum = Good.Gold;
        GoodType = "RAW";
        TradeValue = 5;
        Amount = amount;
    }
}

public class Herb : GoodBase
{

    public Herb(int amount = 0)
    {
        GoodName = "HERB";
        Enum = Good.Herb;
        GoodType = "RAW";
        TradeValue = 5;
        Amount = amount;
    }
}

public class Cloth : GoodBase
{

    public Cloth(int amount = 0)
    {
        GoodName = "CLOTH";
        Enum = Good.Cloth;
        GoodType = "TRADE";
        TradeValue = 5;
        Amount = amount;
    }
}

public class Ceramic : GoodBase
{

    public Ceramic(int amount = 0)
    {
        GoodName = "CERAMIC";
        Enum = Good.Ceramic;
        GoodType = "TRADE";
        TradeValue = 5;
        Amount = amount;
    }
}

public class Ale : GoodBase
{

    public Ale(int amount = 0)
    {
        GoodName = "ALE";
        Enum = Good.Ale;
        GoodType = "TRADE";
        TradeValue = 5;
        Amount = amount;
    }
}

public class Artisan : GoodBase
{

    public Artisan(int amount = 0)
    {
        GoodName = "ARTISAN";
        Enum = Good.Artisan;
        GoodType = "TRADE";
        TradeValue = 5;
        Amount = amount;
    }
}

public class Paper : GoodBase
{

    public Paper(int amount = 0)
    {
        GoodName = "PAPER";
        Enum = Good.Paper;
        GoodType = "TRADE";
        TradeValue = 5;
        Amount = amount;
    }
}

public class Weapon : GoodBase
{

    public Weapon(int amount = 0)
    {
        GoodName = "WEAPON";
        Enum = Good.Weapon;
        GoodType = "TRADE";
        TradeValue = 5;
        Amount = amount;
    }
}