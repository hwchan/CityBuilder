using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NextTurnModal : MonoBehaviour
{
    [SerializeField] private Text _eventText = default;
    public Button OkButton;

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
    void Start()
    {
        _woodChange = _inventoryModalPanel.transform.Find("WOOD").Find("WoodChange").GetComponent<Text>();
        _stoneChange = _inventoryModalPanel.transform.Find("STONE").Find("StoneChange").GetComponent<Text>();
        _ironChange = _inventoryModalPanel.transform.Find("IRON").Find("IronChange").GetComponent<Text>();
        _toolChange = _inventoryModalPanel.transform.Find("TOOL").Find("ToolChange").GetComponent<Text>();
        _grainChange = _inventoryModalPanel.transform.Find("GRAIN").Find("GrainChange").GetComponent<Text>();
        _meatChange = _inventoryModalPanel.transform.Find("MEAT").Find("MeatChange").GetComponent<Text>();
        _clayChange = _inventoryModalPanel.transform.Find("CLAY").Find("ClayChange").GetComponent<Text>();
        _coalChange = _inventoryModalPanel.transform.Find("COAL").Find("CoalChange").GetComponent<Text>();
        _flaxChange = _inventoryModalPanel.transform.Find("FLAX").Find("FlaxChange").GetComponent<Text>();
        _herbChange = _inventoryModalPanel.transform.Find("HERB").Find("HerbChange").GetComponent<Text>();
        _goldChange = _inventoryModalPanel.transform.Find("GOLD").Find("GoldChange").GetComponent<Text>();
        _ceramicChange = _inventoryModalPanel.transform.Find("CERAMIC").Find("CeramicChange").GetComponent<Text>();
        _clothChange = _inventoryModalPanel.transform.Find("CLOTH").Find("ClothChange").GetComponent<Text>();
        _aleChange = _inventoryModalPanel.transform.Find("ALE").Find("AleChange").GetComponent<Text>();
        _paperChange = _inventoryModalPanel.transform.Find("PAPER").Find("PaperChange").GetComponent<Text>();
        _weaponChange = _inventoryModalPanel.transform.Find("WEAPON").Find("WeaponChange").GetComponent<Text>();
        _artisanChange = _inventoryModalPanel.transform.Find("ARTISAN").Find("ArtisanChange").GetComponent<Text>();

        OkButton.onClick.AddListener(() => { gameObject.SetActive(false); });
    }

    public void ShowNextTurnModal(GoodsCollection goods, string text = null)    //TODO prob don't pass in text like this
    {
        gameObject.SetActive(true);
        foreach (var i in goods.Keys)
        {
            UpdateGoodIncomeText(i, goods[i]);
        }
        _eventText.text = text;
    }

    public void UpdateGoodIncomeText(Good good, int value)
    {
        Transform goodTransform = _inventoryModalPanel.transform.Find(good.ToString().ToUpper());
        if (value == 0)
        {
            goodTransform.gameObject.SetActive(false);
            return;
        }
        goodTransform.gameObject.SetActive(true);
        string txt = value > 0 ? "+" + value : value.ToString();
        string hack = char.ToUpper(good.ToString()[0]) + good.ToString().ToLower().Substring(1);  //hack for PascalCase
        goodTransform.Find(hack + "Change").GetComponent<Text>().text = txt;
    }
}