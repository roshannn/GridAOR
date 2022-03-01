using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridController : MonoBehaviour
{
    private static GridController instance = null;
    public static GridController Instance { get { return instance; } }
    public GameObject GridGenerationPanel;
    public Transform targetPosition;
    [SerializeField] private TilePool tilePool;
    [SerializeField] List<TileObject> Tiles;
    private int width;
    private int height;
    private int AOI;
    private Vector2 pos;
    public GridConfig gridConfig;

    GridSystem gridSystem;
    private void Awake()
    {
        Tiles = new List<TileObject>();
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
        GridGenerationPanel.SetActive(true);
    }

    internal void StartGridGeneration()
    {
        SetGridConfig(gridConfig);
        GenerateGrid(width, height, targetPosition);
    }

    private void Start()
    {
        //StartGridGeneration();
    }
    private void SetGridConfig(GridConfig gridConfig)
    {
        width = gridConfig.width;
        height = gridConfig.height;
        AOI = gridConfig.AOI;
        if (width > 12)
        {
            width = 12;
        }
        if (height > 7)
        {
            height = 7;
        }
    }
    private void GenerateGrid(int width, int height, Transform parent)
    {
        if (Tiles.Count > 0)
        {
            tilePool.ReturnTileToPool(Tiles);
            Tiles.Clear();
        }
        int currIndex = 0;
        pos = Vector2.zero;
        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                TileObject Tile = tilePool.GetTileFromPool();
                currIndex = SetTileData(parent, currIndex, Tile);
                pos.x += 2;
            }
            pos.y -= 2;
            pos.x = 0;
        }
    }

    private int SetTileData(Transform parent, int currIndex, TileObject Tile)
    {
        Tile.transform.position = pos;
        Tile.gameObject.SetActive(true);
        Tile.transform.SetParent(parent, false);
        Tile.Index = currIndex++;
        Tile.Value = currIndex;
        Tile.color = GridController.Instance.gridConfig.colorConfig.ColorsToApply[UnityEngine.Random.Range(0, GridController.Instance.gridConfig.colorConfig.ColorsToApply.Count)];
        Tiles.Add(Tile);
        GridSystem.RemoveTiles += delegate { tilePool.ReturnTileToPool(Tile); };
        return currIndex;
    }

    public bool GenerateListForHighlighting(TileObject tile, int AOI, List<TileObject> HilightedTiles)
    {
        int currentTileIndex = tile.Index;
        for (int i = currentTileIndex - (width * AOI); i <= currentTileIndex + (width * AOI); i += width)
        {
            if (i < 0 || i > Tiles.Count - 1 )
            {
                continue;
            }
            for (int j = i - AOI; j <= i + AOI; j++)
            {
                if (j < 0 || j / width != i / width)
                {
                    continue;
                }
                HilightedTiles.Add(Tiles[j]);

            }
        }
        if (HilightedTiles.Count > 0)
        {
            return true;
        }
        return false;
    }
}

