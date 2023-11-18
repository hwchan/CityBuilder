using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridCell : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _buildingRenderer;
    [SerializeField] private BoxCollider2D _buildingCollider;
    [SerializeField] private Text _timerText;

    private bool _selected;

    //public Terrain Terrain { get; set; }
    //public Doodad Doodad { get; set; }
    //public bool HasWater { get; set; }
    public Building Building { get; private set; }
    public bool IsSpriteOrigin { get; set; }  //top left origin of sprite
    public Vector2 SpriteCentre => Building == null ? Vector2.zero : new Vector2(Building.SpriteSize.x / 2f - .5f, Building.SpriteSize.y / 2f - .5f);

    public void AssignBuilding(Building b)
    {
        Building = b;
        b.GridCell = this;

        _buildingRenderer.sprite = b.Sprite;
        _buildingRenderer.transform.localPosition = (b.SpriteSize - Vector2.one) * .5f;
        IsSpriteOrigin = true;
        _buildingCollider.enabled = true;
        gameObject.name = $"{gameObject.name} {b.BuildingName}";

        _buildingCollider.size = b.SpriteSize;
        _buildingCollider.offset = SpriteCentre;

        _timerText.gameObject.SetActive(true);
        _timerText.transform.localPosition = SpriteCentre;
    }

    public void BlockNonOrigin(Building b)
    {
        Building = b;
        _buildingRenderer.sprite = null;
        _buildingRenderer.transform.localPosition = Vector2.zero;
        IsSpriteOrigin = false;
        _buildingCollider.enabled = false;
        gameObject.name = $"{gameObject.name} {b.BuildingName.Substring(0, 2)}";
    }

    public void SetTimerText(int time)
    {
        if (time < 1)
        {
            _timerText.gameObject.SetActive(false);
            _buildingRenderer.color = Color.white;
        }
        else
        {
            _timerText.gameObject.SetActive(true);
            _timerText.text = time.ToString();
        }
    }

    public bool Selected
    {
        get => _selected;
        set
        {
            _selected = value;

            if (Building != null)
            {
                if (_selected)
                {
                    StartCoroutine(BlinkCoroutine());
                }
                else
                {
                    StopCoroutine(BlinkCoroutine());
                }
            }
        }
    }

    public IEnumerator BlinkCoroutine()
    {
        while (_selected)
        {
            yield return new WaitForSeconds(.5f);
            _buildingRenderer.color = Color.gray;
            yield return new WaitForSeconds(.5f);
            _buildingRenderer.color = Color.white;
        }

        _buildingRenderer.color = Color.white;
    }
}