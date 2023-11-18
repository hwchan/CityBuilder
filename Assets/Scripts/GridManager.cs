using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System;

public enum Terrain
{
    UNSET,
    GRASS,
    ROCK,
    FOREST,
    WATER,
    HIGHLAND,

    //TODO
    BEACH,
    SAND,
    SWAMP,
    DIRT,
    JUNGLE
}

public enum Doodad
{
    UNSET,
    EMPTY,
    TREE,
    BRIDGE_V,
    BRIDGE_H,
    WALL_TOWER,
    WALL_GATE,
    WALL,
}

public class GridManager : MonoBehaviour
{
    [SerializeField] private Transform _gridParent;
    [SerializeField] private GameObject _gridCellPrefab;
    [SerializeField] private GameObject _placement;
    [SerializeField] private SpriteRenderer _sprite;
    [SerializeField] private Vector2 _topLCoord = new Vector2(-9.5f, 10.5f);
    [SerializeField] private Vector2 _botRCoord = new Vector2(9.5f, -8.5f);

    private Building _selectedBuilding;
    private Vector2 _localOffset;

    public event Action<Building, Action<Building>> OnBuildingPlaced;
    public Dictionary<Vector2, GridCell> GridMapDict = new Dictionary<Vector2, GridCell>();

    private void Awake()
    {
        for (float y = _topLCoord.y; y >= _botRCoord.y; y--)
        {
            for (float x = _topLCoord.x; x <= _botRCoord.x; x++)
            {
                var go = Instantiate(_gridCellPrefab, Vector3.zero, Quaternion.identity);
                GridMapDict[new Vector2(x, y)] = go.GetComponent<GridCell>();
                go.transform.SetParent(_gridParent);
                go.transform.localPosition = new Vector2(x, y);
                go.name = $"[{x}:{y}]";
            }
        }

        _localOffset = (Vector2)_gridParent.transform.position;
    }

    private void Update()
    {
        Vector3 v1 = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        float x = Mathf.Floor(v1.x) + .5f;
        float y = Mathf.Floor(v1.y) + .5f;
        var offset = new Vector2(_localOffset.x % 1, _localOffset.y % 1);
        var topLCoord = _topLCoord + _localOffset;
        var botRCoord = _botRCoord + _localOffset;

        Vector2 v3 = new Vector2(x, y) + offset;

        if (v3.x >= topLCoord.x && v3.x <= botRCoord.x
            && v3.y <= topLCoord.y && v3.y >= botRCoord.y)
        {
            _placement.transform.position = v3;
        }

        if (Input.GetMouseButtonDown(0))
        {
            HandleBuildingClick();
            HandlePlaceBuilding(v3);
        }

        if (Input.GetMouseButtonDown(1))
        {
            DebugPrint();
            DisableBuildingGhost();
        }
    }

    public void EnableBuildingGhost(Building b)
    {
        _selectedBuilding = b;
        _placement.SetActive(true);

        _sprite.sprite = _selectedBuilding.Sprite;
        _sprite.transform.localPosition = (_selectedBuilding.SpriteSize - Vector2.one) * .5f;
    }

    public void DisableBuildingGhost()
    {
        _placement.SetActive(false);
        _selectedBuilding = null;
        _sprite.sprite = null;

        GuiManager.UpdateBuildingDetailGui(null);
        Globals.BuildingManager.SetCurrentBuilding(null);
    }

    //TODO move this elsewhere
    private void HandleBuildingClick()
    {
        if (_selectedBuilding != null)
        {
            return;
        }
        
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 10;
        Vector3 screenPos = Camera.main.ScreenToWorldPoint(mousePos);
        RaycastHit2D hit = Physics2D.Raycast(screenPos, Vector2.zero);

        if (hit)
        {
            var cell = hit.transform.GetComponent<GridCell>();
            if (cell && cell.Building != null)
            {
                print(cell.Building.BuildingName);

                GuiManager.UpdateBuildingDetailGui(cell.Building);
                Globals.BuildingManager.SetCurrentBuilding(cell.Building);
            }
            else
            {
                print(hit.collider.name);
            }
        }
    }

    private void HandlePlaceBuilding(Vector2 v3)
    {
        v3 = v3 - _localOffset;
        
        if (GridMapDict.ContainsKey(v3) && _selectedBuilding != null)
        {
            //check the size of the building to see if its blocked
            for (int x = 0; x < _selectedBuilding.SpriteSize.x; x++)
            {
                for (int y = 0; y < _selectedBuilding.SpriteSize.y; y++)
                {
                    //Debug.Log(new Vector2(v3.x + x, v3.y + y));
                    if (GridMapDict[new Vector2(v3.x + x, v3.y + y)].Building != null)
                    {
                        Debug.LogError($"{v3.x + x}:{v3.y + y} BLOCKED");
                        Globals.PopupText.PopUp("BLOCKED");
                        return;
                    }
                }
            }

            //block non origin cells
            for (int i = 0; i < _selectedBuilding.SpriteSize.x; i ++)
            {
                for (int j = 0; j < _selectedBuilding.SpriteSize.y; j++)
                {
                    var nonOrigin = v3 + new Vector2(i, j);
                    var cell = GridMapDict[nonOrigin];
                    if (cell.Building == null)
                        cell.BlockNonOrigin(_selectedBuilding);
                }
            }

            OnBuildingPlaced?.Invoke(_selectedBuilding, b => GridMapDict[v3].AssignBuilding(b));
            DisableBuildingGhost();
        }
    }

    private void DebugPrint()
    {
        var sb = new StringBuilder();
        foreach (var kvp in GridMapDict)
        {
            if (kvp.Value.Building != null)
            {
                sb.AppendLine($"{kvp.Key.x},{kvp.Key.y}:  {kvp.Value.Building.BuildingName}");
            }
        }
        Debug.LogError(sb.ToString());
    }
}
