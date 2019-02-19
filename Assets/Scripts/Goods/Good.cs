using UnityEngine;
using System.Collections;

public enum Good
{
    WOOD,
    STONE,
    IRON,
    TOOL,

    GRAIN,
    MEAT,

    CLAY,
    COAL,
    FLAX,
    GOLD,
    HERB,

    CLOTH,
    CERAMIC,
    ALE,
    ARTISAN,
    PAPER,
    WEAPON,

    COIN,
    TIME,
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
        Enum = Good.WOOD;
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
        Enum = Good.STONE;
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
        Enum = Good.IRON;
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
        Enum = Good.TOOL;
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
        Enum = Good.GRAIN;
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
        Enum = Good.MEAT;
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
        Enum = Good.CLAY;
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
        Enum = Good.COAL;
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
        Enum = Good.FLAX;
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
        Enum = Good.GOLD;
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
        Enum = Good.HERB;
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
        Enum = Good.CLOTH;
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
        Enum = Good.CERAMIC;
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
        Enum = Good.ALE;
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
        Enum = Good.ARTISAN;
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
        Enum = Good.PAPER;
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
        Enum = Good.WEAPON;
        GoodType = "TRADE";
        TradeValue = 5;
        Amount = amount;
    }
}