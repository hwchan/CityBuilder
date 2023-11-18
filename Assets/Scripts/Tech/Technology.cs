using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResearchManager
{
    public HashSet<Research> UnlockedResearch { get; } = new HashSet<Research>();
    public HashSet<BuildingEnum> UnlockedBuildings { get; } = new HashSet<BuildingEnum>();
    public HashSet<Upgrade> UnlockedUpgrades { get; } = new HashSet<Upgrade>();
    public HashSet<Research> AvailableResearch { get; } = new HashSet<Research>();

    public Dictionary<string, Research> ResearchDict = new Dictionary<string, Research>
    {
        {
            "base", new Research
            {
                Id = "base",
                Name = "BASE",
                Unlocks = new HashSet<string>
                {
                    "iron_working",
                    "currency",
                    "horseback_riding"
                }
            }
        },
        {
            "iron_working", new Research
            {
                Id = "iron_working",
                Name = "Iron Working",
                Cost = 3,
                UnlockBuildings = new HashSet<BuildingEnum>
                {
                    BuildingEnum.IRON_MINE
                },
                UnlockUpgrades = new HashSet<string>
                {
                    "construction_guild_upkeep_0"
                },
                Unlocks = new HashSet<string>
                {
                    "castles",
                    "machinery"
                }
            }
        },
        {
            "currency", new Research
            {
                Id = "currency",
                Name = "Currency",
                Cost = 3,
                UnlockBuildings = new HashSet<BuildingEnum>
                {
                    BuildingEnum.GOLD_MINE,
                    BuildingEnum.TRADE_DEPOT,
                    BuildingEnum.MARKET
                },
                Unlocks = new HashSet<string>
                {
                    "mathematics",
                    "apprenticeship"
                }
            }
        },
        {
            "horseback_riding", new Research
            {
                Id = "horseback_riding",
                Name = "Horseback Riding",
                Cost = 3,
                UnlockBuildings = new HashSet<BuildingEnum>
                {
                    BuildingEnum.STABLES
                },
                Unlocks = new HashSet<string>
                {
                    "apprenticeship",
                    "stirrups"
                }
            }
        },
        {
            "apprenticeship", new Research
            {
                Id = "apprenticeship",
                Name = "Apprenticeship",
                Cost = 3,
                UnlockBuildings = new HashSet<BuildingEnum>
                {
                    BuildingEnum.WORKSHOP
                },
                UnlockUpgrades = new HashSet<string>
                {
                    "construction_guild_carpenters"
                },
                Unlocks = new HashSet<string>
                {
                    "banking"
                }
            }
        },
    };

    public Dictionary<string, Upgrade> UpgradeDict = new Dictionary<string, Upgrade>
    {
        {
            "construction_guild_upkeep_0", new BuildingUpgrade
            {
                Id = "construction_guild_upkeep_0",
                Title = "Construction Guild upkeep reduction",
                Description = "Reduces upkeep to 0",
                BuildingType = BuildingEnum.CONSTRUCTION_GUILD,
                OnUpgradeCheck = building =>
                {
                    building.CoinUpkeep = 0;
                }
            }
        },
        {
            "construction_guild_carpenters", new BuildingUpgrade
            {
                Id = "construction_guild_carpenters",
                Title = "Construction Guild Carpenters upgrade",
                Description = "Increases Carpenters building mode production to 3",
                BuildingType = BuildingEnum.CONSTRUCTION_GUILD,
                OnUpgradeCheck = building => 
                {
                    building.BuildingEffects.Add(Carpenters);

                    void Carpenters(GoodsCollection goods)
                    {
                        building.MaterialsRequired = new GoodsCollection { { Good.WOOD, 3 }, { Good.TOOL, 1 } };
                        building.CoinUpkeep = 10;
                        // _materialsProducedString = "production+";
                        Globals.CityManager.SetProduction(3);
                    }
                }
            }
        }
    };

    public void GetResearchTree()
    {
        var visited = new HashSet<string>();
        var queue = new Queue<string>();

        queue.Enqueue("base");
        visited.Add("base");
        
        while (queue.Count > 0)
        {
            var id = queue.Dequeue();
            if (ResearchDict.TryGetValue(id, out var research))
            {
                Debug.Log(research.Id);
                visited.Add(id);
                
                foreach (var unlock in research.Unlocks)
                {
                    if (!visited.Contains(unlock))
                    {
                        queue.Enqueue(unlock);
                    }
                }
            }
        }
    }
}

public class Research
{
    public string Id { get; set; }
    public string Name { get; set; }
    public int Cost { get; set; }
    public HashSet<BuildingEnum> UnlockBuildings { get; set; }
    public HashSet<string> UnlockUpgrades { get; set; }

    // public HashSet<string> Prerequisites { get; set; }
    public HashSet<string> Unlocks { get; set; }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }
}

public abstract class Upgrade
{
    public string Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }
}

public class BuildingUpgrade : Upgrade
{
    public BuildingEnum BuildingType { get; set; }
    public Action<Building> OnUpgradeCheck { get; set; }
}

public class ConstructionGuildUpkeepUpgrade : BuildingUpgrade
{
    public ConstructionGuildUpkeepUpgrade()
    {
        Title = "Construction Guild upkeep reduction";
        Description = "Reduces upkeep to 0";
        BuildingType = BuildingEnum.CONSTRUCTION_GUILD;
        OnUpgradeCheck = building => 
        {
            building.CoinUpkeep = 0;
        };
    }
}

public class ConstructionGuildCarpentersUpgrade : BuildingUpgrade
{
    public ConstructionGuildCarpentersUpgrade()
    {
        Title = "Construction Guild Carpenters upgrade";
        Description = "Increases Carpenters building mode production to 3";
        BuildingType = BuildingEnum.CONSTRUCTION_GUILD;
        OnUpgradeCheck = building => 
        {
            building.BuildingEffects.Add(Carpenters);

            void Carpenters(GoodsCollection goods)
            {
                building.MaterialsRequired = new GoodsCollection { { Good.WOOD, 3 }, { Good.TOOL, 1 } };
                building.CoinUpkeep = 10;
                // _materialsProducedString = "production+";
                Globals.CityManager.SetProduction(3);
            }
        };
    }
}

public abstract class CityUpgrade : Upgrade
{

}

public class IncomeCityUpgrade : CityUpgrade
{
    public IncomeCityUpgrade()
    {
        Title = "Income increase";
        Description = "Increases income by 100";
        Globals.CityManager.SetIncome(Globals.CityManager.Income + 100);
    }
}

public class BuildingUpkeepCityUpgrade : CityUpgrade
{
    public BuildingUpkeepCityUpgrade()
    {
        Title = "Building upkeep reduction";
        Description = "Reduces all building upkeep by 1";
        //?
    }
}

public class BuildingCostCityUpgrade : CityUpgrade
{
    public BuildingCostCityUpgrade()
    {
        Title = "Building cost reduction";
        Description = "Reduces all building wood cost by 1";
        //?
    }
}
