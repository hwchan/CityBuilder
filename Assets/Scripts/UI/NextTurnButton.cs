using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NextTurnButton : MonoBehaviour
{
    private GoodsCollection _collection = new GoodsCollection(0);

	void Start ()
    {
        GetComponent<Button>().onClick.AddListener(OnClick);
    }
	
    void OnClick()
    {
        Globals.BuildingManager.HandleBuildingsOnEndTurn();
        Globals.CityManager.AddTurns(1);

        //TODO: refactor this to somewhere else
        _collection.Add(Globals.BuildingManager.IncomeInventory);
        if (Globals.CityManager.Turns % 4 == 0)
        {
            Globals.NextTurnModal.ShowNextTurnModal(_collection, Globals.GameEventManager.GetText());
            _collection = new GoodsCollection(0);
        }
    }
}