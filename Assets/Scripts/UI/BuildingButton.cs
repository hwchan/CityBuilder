using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BuildingButton : MonoBehaviour {

    //private string _spriteName;
    private Sprite _sprite;
    private string _text;
    private GameObject _gameObject;

    private Image _imageComponent;
    private Text _textComponent;

    private BuildingManager _buildingManager;

	void Start () {
        _gameObject = GameObject.Find(_text);
        _gameObject.SetActive(false);
        
    }

    public void InitializeBuildingButton(BuildingManager manager, string spriteName, string text)
    {
        _buildingManager = manager;
        _sprite = Resources.Load<Sprite>(spriteName);
        _text = text;

        _imageComponent = transform.FindChild("Image").GetComponent<Image>();
        _textComponent = transform.FindChild("Text").GetComponent<Text>();

        _imageComponent.sprite = _sprite;
        _textComponent.text = _buildingManager[_text].Level + " " + _text.ToUpper();
        GetComponent<Button>().onClick.AddListener(OnClick);
    }

    void OnClick()
    {
        //Debug.Log(_text);
        _gameObject.SetActive(true);
        _textComponent.text = ++_buildingManager[_text].Level + " " + _text.ToUpper();
        GuiManager.DoFoo(_sprite, _text);
    }
}
