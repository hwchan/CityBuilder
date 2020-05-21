using System.Collections.Generic;
using System.Text;

public class BuildingsCollection : Dictionary<BuildingEnum, Building>
{
    public BuildingsCollection()
    {
        Add(BuildingEnum.BAKERY,             new Bakery());
        Add(BuildingEnum.BANK,               new Bank());
        Add(BuildingEnum.BARRACKS,           new Barracks());
        Add(BuildingEnum.BREWERY,            new Brewery());
        Add(BuildingEnum.CASTLE,             new Castle());
        Add(BuildingEnum.CHAPEL,             new Chapel());
        Add(BuildingEnum.CLAY_PIT,           new ClayPit());
        Add(BuildingEnum.COAL_MINE,          new CoalMine());
        Add(BuildingEnum.CONSTRUCTION_GUILD, new ConstructionGuild());
        Add(BuildingEnum.COURTHOUSE,         new Courthouse());
        Add(BuildingEnum.FISHING_WHARF,      new FishingWharf());
        Add(BuildingEnum.FLAX_FARM,          new FlaxFarm());
        Add(BuildingEnum.GOLD_MINE,          new GoldMine());
        Add(BuildingEnum.GRANARY,            new Granary());
        Add(BuildingEnum.HUNTING_LODGE,      new HuntingLodge());
        Add(BuildingEnum.IRON_MINE,          new IronMine());
        Add(BuildingEnum.LEATHERWORK,        new Leatherwork());
        Add(BuildingEnum.LIBRARY,            new Library());
        Add(BuildingEnum.LIGHTHOUSE,         new Lighthouse());
        Add(BuildingEnum.LUMBERMILL,         new Lumbermill());
        Add(BuildingEnum.MARKET,             new Market());
        Add(BuildingEnum.PHYSICIAN,          new Physician());
        Add(BuildingEnum.PIG_FARM,           new PigFarm());
        Add(BuildingEnum.POTTER,             new Potter());
        Add(BuildingEnum.PRISON,             new Prison());
        Add(BuildingEnum.QUARRY,             new Quarry());
        Add(BuildingEnum.SHIPYARD,           new Shipyard());
        Add(BuildingEnum.SMITHY,             new Smithy());
        Add(BuildingEnum.STABLES,            new Stables());
        Add(BuildingEnum.STEEL_FORGE,        new SteelForge());
        Add(BuildingEnum.STOREHOUSE,         new Storehouse());
        Add(BuildingEnum.TAVERN,             new Tavern());
        Add(BuildingEnum.THEATRE,            new Theatre());
        Add(BuildingEnum.TRADE_DEPOT,        new TradeDepot());
        Add(BuildingEnum.UNIVERSITY,         new University());
        Add(BuildingEnum.WATERMILL,          new Watermill());
        Add(BuildingEnum.WEAVER,             new Weaver());
        Add(BuildingEnum.WHEAT_FARM,         new WheatFarm());
        Add(BuildingEnum.WOODCUTTER,         new Woodcutter());
        Add(BuildingEnum.WORKSHOP,           new Workshop());
    }

    public BuildingsCollection(BuildingsCollection buildings)
    {
        foreach (KeyValuePair<BuildingEnum, Building> kvp in buildings)
        {
            if (ContainsKey(kvp.Key))
                this[kvp.Key].AddLevel(kvp.Value.Level);
            else
                Add(kvp.Key, kvp.Value);
        }
    }

    public new Building this[BuildingEnum b]
    {
        get
        {
            if (ContainsKey(b))
                return base[b];
            return null;
        }
        //set
        //{
        //    if (ContainsKey(b))
        //        base[b] = value;
        //    else
        //        Add(b, value);
        //}
    }

    public static BuildingsCollection operator -(BuildingsCollection a, BuildingsCollection b)
    {
        if (b == null)
            return a;

        var ret = new BuildingsCollection(a);

        foreach (var key in b.Keys)
        {
            ret[key].AddLevel(-b[key].Level);
        }

        return ret;
    }

    public static BuildingsCollection operator +(BuildingsCollection a, BuildingsCollection b)
    {
        if (b == null)
            return a;

        var ret = new BuildingsCollection(a);

        foreach (var key in b.Keys)
        {
            ret[key].AddLevel(b[key].Level);
        }

        return ret;
    }

    public override string ToString()
    {
        StringBuilder build = new StringBuilder();
        foreach (KeyValuePair<BuildingEnum, Building> kvp in this)
            build.AppendLine(kvp.Key.ToString() + ":" + kvp.Value.Level);

        return build.ToString();
    }
}
