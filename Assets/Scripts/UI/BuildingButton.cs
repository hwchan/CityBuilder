using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BuildingButton : MonoBehaviour {

    //private string _spriteName;
    //private Sprite _sprite;
    //private string _text;
    //private GameObject _gameObject;

    private Image _imageComponent;
    private Text _textComponent;

    private BuildingManager _buildingManager;
    private Building _building;

	//void Start () {
        //_gameObject = GameObject.Find(_text);
        //_gameObject.SetActive(false);
    //}

    public void InitializeBuildingButton(BuildingManager manager, Building building)
    {
        _buildingManager = manager;
        _building = building;
        //_sprite = Resources.Load<Sprite>(spriteName);
        //_text = text;

        _imageComponent = transform.Find("Image").GetComponent<Image>();
        _textComponent = transform.Find("Text").GetComponent<Text>();

        _imageComponent.sprite = _building.Sprite;
        _textComponent.text = _building.Level + " " + _building.BuildingName.ToUpper();
        GetComponent<Button>().onClick.AddListener(OnClick);
    }

    public void OnClick()
    {
        //Debug.Log(_text);
        //_gameObject.SetActive(true);
        GuiManager.UpdateBuildingDetailGui(_building);
        UpdateBuildingButton();

        _buildingManager.SetCurrentBuilding(_building.BuildingName);
    }

    public void UpdateBuildingButton()
    {
        _textComponent.text = _building.Level + " " + _building.BuildingName.ToUpper();
        
    }
}
