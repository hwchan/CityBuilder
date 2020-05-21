using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GameEventData
{
    public string Title { get; set; }
    public string Description { get; set; }
    public GoodsCollection GoodsGained { get; set; }
    public GoodsCollection GoodsLost { get; set; }
    public MissionData[] Missions { get; set; }

    public GameEventData(string title, params MissionData[] missions)
    {
        Title = title;
        Missions = missions;
    }
}

public class MissionData
{
    public string Title { get; set; }
    public string Description { get; set; }
    public GoodsCollection GoodsGained { get; set; }
    public GoodsCollection GoodsLost { get; set; }
    public int Tier { get; set; }
    public int TurnLimit { get; set; }
    public bool CheckCompletionOnTurnEnd { get; set; } = true;
    public int CompletedOnTurn { get; set; } = -1;

    public Building[] BuildingsRequired { get; set; }
    public GoodsCollection GoodsRequired { get; set; }

    public MissionData(string title)
    {
        Title = title;
    }

    public bool IsMissionComplete()
    {
        return IsBuildingReqMet() && IsGoodsReqMet();
    }

    //only checks for 1 quantity
    public bool IsBuildingReqMet()
    {
        if (BuildingsRequired != null)
        {
            foreach (var building in BuildingsRequired)
            {
                var foundBuilding = Globals.BuildingManager.Buildings[building.BuildingType];
                if (foundBuilding.Level < 1)
                    return false;
            }
        }
        return true;
    }

    public bool IsGoodsReqMet()
    {
        if (GoodsRequired != null)
        {
            foreach (var g in GoodsRequired.Keys)
            {
                if (Globals.BuildingManager.Inventory[g] < GoodsRequired[g])
                    return false;
            }
        }
        return true;
    }

    public override string ToString()
    {
        return $"{Title}: {Description} (T{CompletedOnTurn})";
    }
}

public class GameEventManager : MonoBehaviour
{
    private GameEventData[] _events = new[]
    {
        new GameEventData("Humble Beginnings", 
            new MissionData($"Build a WOODCUTTER & stockpile 20 WOOD")
            {
                GoodsRequired = new GoodsCollection { { Good.WOOD, 1 } },
                BuildingsRequired = new[] { new Woodcutter() },
                GoodsGained = new GoodsCollection { { Good.COIN, 1000 }, { Good.STONE, 100 } },
            }), 
        new GameEventData("Imperial Favour"),
        new GameEventData("Artisan Refugees"),
        new GameEventData("Barbarians at the Gates"),
        new GameEventData("East Wind"),
    };

    public List<MissionData> CurrentMissions { get; set; } = new List<MissionData>();

    //TODO this is more like HandleEndTurnEvent()
    public string GetText()
    {
        int turn = Globals.CityManager.Turns;
        GameEventData eventData = _events[(turn / 4 - 1) % _events.Length];
        string eventText = eventData.Title;
        string missionText = string.Join("\r\n", eventData.Missions.Select(m => m.Title));

        CurrentMissions.AddRange(eventData.Missions);
        GetMissionsCompleted();

        return $"Month {turn / 4}, Week {turn % 4 + 1}\r\n{eventText}\r\n\r\n{missionText}";
    }

    public void GetMissionsCompleted()
    {
        foreach (var mission in CurrentMissions)
        {
            if (mission.IsMissionComplete())
            {
                Globals.BuildingManager.Inventory.Add(mission.GoodsGained);
                Globals.BuildingManager.Inventory.Subtract(mission.GoodsLost);
                mission.CompletedOnTurn = Globals.CityManager.Turns;
                Debug.Log(mission);
            }
        }
    }
}
