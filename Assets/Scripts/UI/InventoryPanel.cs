using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryPanel : MonoBehaviour
{
    [SerializeField] private GoodDisplay _wood;
    [SerializeField] private GoodDisplay _stone;
    [SerializeField] private GoodDisplay _iron;
    [SerializeField] private GoodDisplay _tool;

    [SerializeField] private GoodDisplay _grain;
    [SerializeField] private GoodDisplay _meat;

    [SerializeField] private GoodDisplay _clay;
    [SerializeField] private GoodDisplay _coal;
    [SerializeField] private GoodDisplay _flax;
    [SerializeField] private GoodDisplay _gold;
    [SerializeField] private GoodDisplay _herb;

    [SerializeField] private GoodDisplay _cloth;
    [SerializeField] private GoodDisplay _ceramic;
    [SerializeField] private GoodDisplay _ale;
    [SerializeField] private GoodDisplay _artisan;
    [SerializeField] private GoodDisplay _paper;
    [SerializeField] private GoodDisplay _weapon;

    [SerializeField] private GoodDisplay _coin;
    [SerializeField] private GoodDisplay _time;

    private Dictionary<Good, GoodDisplay> _goodDisplays;

    private void Awake()
    {
        _goodDisplays = new Dictionary<Good, GoodDisplay>
        {
            { Good.WOOD, _wood },
            { Good.STONE, _stone },
            { Good.IRON, _iron },
            { Good.TOOL, _tool },
            { Good.MEAT, _meat },
            { Good.GRAIN, _grain },
            { Good.CLAY, _clay },
            { Good.COAL, _coal },
            { Good.FLAX, _flax },
            { Good.GOLD, _gold },
            { Good.HERB, _herb },
            { Good.CLOTH, _cloth },
            { Good.CERAMIC, _ceramic },
            { Good.ALE, _ale },
            { Good.ARTISAN, _artisan },
            { Good.PAPER, _paper },
            { Good.WEAPON, _weapon },
            { Good.COIN, _coin },
            { Good.TIME, _time },
        };
    }

    public void UpdateInventory(GoodsCollection inventory)
    {
        foreach (KeyValuePair<Good, int> kvp in inventory)
        {
            var delta = Globals.BuildingManager.IncomeInventory[kvp.Key];

            if (_goodDisplays.TryGetValue(kvp.Key, out var display))
            {
                display.Set(kvp.Value);
                display.PlayDeltaAnimation(delta);
            }
        }
    }
}
