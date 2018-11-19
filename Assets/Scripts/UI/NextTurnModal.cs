using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NextTurnModal : MonoBehaviour {

    public Button OkButton;
    private BuildingManager _manager;
    private CityManager _cityManager;

    public GameObject _inventoryModalPanel;

    private Text _woodChange;
    private Text _stoneChange;
    private Text _ironChange;
    private Text _toolChange;
    private Text _grainChange;
    private Text _meatChange;
    private Text _clayChange;
    private Text _coalChange;
    private Text _flaxChange;
    private Text _herbChange;
    private Text _goldChange;
    private Text _ceramicChange;
    private Text _clothChange;
    private Text _aleChange;
    private Text _paperChange;
    private Text _weaponChange;
    private Text _artisanChange;

    // Use this for initialization
    void Start () {
        _manager = GameObject.Find("BuildingManager").GetComponent<BuildingManager>();
        _cityManager = GameObject.Find("CityManager").GetComponent<CityManager>();
        //_inventoryModalPanel.transform.FindChild("WOOD").FindChild("WoodChange").GetComponent<Text>().text = "100";

        _woodChange = _inventoryModalPanel.transform.FindChild("WOOD").FindChild("WoodChange").GetComponent<Text>();
        _stoneChange = _inventoryModalPanel.transform.FindChild("STONE").FindChild("StoneChange").GetComponent<Text>();
        _ironChange = _inventoryModalPanel.transform.FindChild("IRON").FindChild("IronChange").GetComponent<Text>();
        _toolChange = _inventoryModalPanel.transform.FindChild("TOOL").FindChild("ToolChange").GetComponent<Text>();
        _grainChange = _inventoryModalPanel.transform.FindChild("GRAIN").FindChild("GrainChange").GetComponent<Text>();
        _meatChange = _inventoryModalPanel.transform.FindChild("MEAT").FindChild("MeatChange").GetComponent<Text>();
        _clayChange = _inventoryModalPanel.transform.FindChild("CLAY").FindChild("ClayChange").GetComponent<Text>();
        _coalChange = _inventoryModalPanel.transform.FindChild("COAL").FindChild("CoalChange").GetComponent<Text>();
        _flaxChange = _inventoryModalPanel.transform.FindChild("FLAX").FindChild("FlaxChange").GetComponent<Text>();
        _herbChange = _inventoryModalPanel.transform.FindChild("HERB").FindChild("HerbChange").GetComponent<Text>();
        _goldChange = _inventoryModalPanel.transform.FindChild("GOLD").FindChild("GoldChange").GetComponent<Text>();
        _ceramicChange = _inventoryModalPanel.transform.FindChild("CERAMIC").FindChild("CeramicChange").GetComponent<Text>();
        _clothChange = _inventoryModalPanel.transform.FindChild("CLOTH").FindChild("ClothChange").GetComponent<Text>();
        _aleChange = _inventoryModalPanel.transform.FindChild("ALE").FindChild("AleChange").GetComponent<Text>();
        _paperChange = _inventoryModalPanel.transform.FindChild("PAPER").FindChild("PaperChange").GetComponent<Text>();
        _weaponChange = _inventoryModalPanel.transform.FindChild("WEAPON").FindChild("WeaponChange").GetComponent<Text>();
        _artisanChange = _inventoryModalPanel.transform.FindChild("ARTISAN").FindChild("ArtisanChange").GetComponent<Text>();

        OkButton.onClick.AddListener(() => { gameObject.SetActive(false); });
    }
	
	// Update is called once per frame
	void Update () {
        //var foo = _manager.IncomeInventory;
	}

    public void ShowNextTurnModal()
    {
        gameObject.SetActive(true);
        foreach (var i in _manager.IncomeInventory.Keys)
        {
            UpdateGoodIncomeText(i, _manager.IncomeInventory[i]);
        }
    }

    public void UpdateGoodIncomeText(Good good, int value)
    {
        var foo = _inventoryModalPanel.transform.FindChild(good.ToString().ToUpper());
        if (value == 0)
        {
            foo.gameObject.SetActive(false);
            return;
        }
        foo.gameObject.SetActive(true);
        string txt = value > 0 ? "+" + value : value.ToString();
        foo.FindChild(good + "Change").GetComponent<Text>().text = txt;
    }
}
