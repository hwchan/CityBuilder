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

    public int Unemployed { get; private set; }

    public GameObject Panel;
    private Text _coinText;
    private Text _populationText;
    private Text _cultureText;
    private Text _scienceText;
    private Text _safetyText;
    private Text _turnsText;

    void Start () {
        _coinText = Panel.transform.Find("CoinText").GetComponent<Text>();
        _populationText = Panel.transform.Find("PopulationText").GetComponent<Text>();
        _cultureText = Panel.transform.Find("CultureText").GetComponent<Text>();
        _scienceText = Panel.transform.Find("ScienceText").GetComponent<Text>();
        _safetyText = Panel.transform.Find("SafetyText").GetComponent<Text>();
        _turnsText = Panel.transform.Find("TurnsText").GetComponent<Text>();

        AddCoin(10000);
        TryAddPopulation(50);

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

    public bool TryAddPopulation(int val)
    {
        Population += val;
        if (!TryAddUnemployed(val))
        {
            Population -= val;
            return false;
        }
        _populationText.text = $"{Unemployed} / {Population}";
        return true;
    }

    public bool TryAddUnemployed(int val)
    {
        if ((val + Unemployed) < 0 || (val + Unemployed) > Population)
            return false;

        Unemployed += val;
        _populationText.text = $"{Unemployed} / {Population}";
        return true;
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
