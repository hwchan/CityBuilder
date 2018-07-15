using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CityManager : MonoBehaviour {

    public int Income { get; private set; }

    public int Coin { get; private set; }
    public int Population { get; private set; }
    public int Culture { get; private set; }
    public int Science { get; private set; }
    public int Safety { get; private set; }
    public int Turns { get; private set; }

    public GameObject Panel;
    private Text _coinText;
    private Text _populationText;
    private Text _cultureText;
    private Text _scienceText;
    private Text _safetyText;
    private Text _turnsText;

    void Start () {
        _coinText = Panel.transform.FindChild("CoinText").GetComponent<Text>();
        _populationText = Panel.transform.FindChild("PopulationText").GetComponent<Text>();
        _cultureText = Panel.transform.FindChild("CultureText").GetComponent<Text>();
        _scienceText = Panel.transform.FindChild("ScienceText").GetComponent<Text>();
        _safetyText = Panel.transform.FindChild("SafetyText").GetComponent<Text>();
        _turnsText = Panel.transform.FindChild("TurnsText").GetComponent<Text>();

        AddCoin(10000);
        AddPopulation(50);

        AddCulture(0);
        AddScience(10);
        AddSafety(100);
    }
	
    public void SetIncome(int val)
    {
        Income = val;
        _coinText.text = Coin.ToString() + " (" + Income + ")";
    }

	public int AddCoin(int val)
    {
        Coin += val;
        _coinText.text = Coin.ToString() + " (" + Income + ")";
        return Coin;
    }

    public int AddPopulation(int val)
    {
        Population += val;
        _populationText.text = Population.ToString();
        return Population;
    }

    public int AddCulture(int val)
    {
        Culture += val;
        _cultureText.text = Culture.ToString();
        return Culture;
    }

    public int AddScience(int val)
    {
        Science += val;
        _scienceText.text = Science.ToString();
        return Science;
    }

    public int AddSafety(int val)
    {
        Safety += val;
        _safetyText.text = Safety.ToString();
        return Safety;
    }

    public int AddTurns(int val)
    {
        Turns += val;
        _turnsText.text = Turns.ToString();
        return Turns;
    }
}
