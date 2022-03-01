using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TileObject : MonoBehaviour
{
    public SpriteRenderer sprite;
    public int Index = -1;
    public int Value = 0;
    public Color color; 
    public TMP_Text ValueText;
    private void Start()
    {

    }

    public void ShowTileData()
    {
        ValueText.text = Value.ToString();
        sprite.color = color;
        GridSystem.ResetHilight += () =>
        {
            ValueText.text = "";
            sprite.color = Color.white;
        };
    }
}

