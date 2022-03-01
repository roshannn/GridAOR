using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GridSystem : MonoBehaviour
{
    [SerializeField] List<TileObject> HilightedTiles;

    
    public static Action ResetHilight = null;
    public static Action RemoveTiles = null;
    private void Awake()
    {
        HilightedTiles = new List<TileObject>();
    }
    private void Update()
    {
        if (GameService.Instance.currState == GameState.Grid)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (!EventSystem.current.IsPointerOverGameObject() && Camera.main != null)
                {
                    RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
                    if (hit.collider.GetComponent<TileObject>() != null)
                    {
                        TileObject tile = hit.collider.GetComponent<TileObject>();
                        if (GridController.Instance.GenerateListForHighlighting(tile, GridController.Instance.gridConfig.AOI, HilightedTiles))
                        {
                            ShowAOI(HilightedTiles);
                        }
                        else
                        {
                            Debug.LogError("Cant generate list");
                        }
                        HilightedTiles.Clear();
                    }
                    else
                    {
                        Debug.Log("Raycast hits nothing");
                    }
                }
                    
            }
            if (Input.GetMouseButtonDown(1))
            {
                ResetHilight?.Invoke();
                ResetHilight = null;
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ResetHilight?.Invoke();
            ResetHilight = null;
            RemoveTiles?.Invoke();
            RemoveTiles = null;
            GridController.Instance.GridGenerationPanel.SetActive(true);
            GameService.Instance.currState = GameState.Panel;
        }


    }

    private void ShowAOI(List<TileObject> hilightedTiles)
    {
        ResetHilight?.Invoke();
        ResetHilight = null;
        foreach (TileObject tile in hilightedTiles)
        {
            tile.ShowTileData();
        }
    }
}
