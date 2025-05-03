using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CityManager : MonoBehaviour
{
    [SerializeField] private Text _coinText;
    [SerializeField] private Text _populationText;
    [SerializeField] private Text _cultureText;
    [SerializeField] private Text _scienceText;
    [SerializeField] private Text _safetyText;
    [SerializeField] private Text _turnsText;

    public int Income { get; private set; }

    public int Coin { get; private set; }
    public int Population { get; private set; }
    public int Culture { get; private set; }
    public int Science { get; private set; }
    public int Safety { get; private set; }
    public int Production { get; private set; } = 1;
    public int Turns { get; private set; }

    public int Unemployed { get; private set; }


    void Start ()
    {
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

    public int SetProduction(int val)
    {
        Production = val;
        //_productionText.text = Production.ToString();
        return Production;
    }

    public int SetCulture(int val)
    {
        Culture = val;
        _cultureText.text = Culture.ToString();
        return Culture;
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
