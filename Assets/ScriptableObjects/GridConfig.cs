using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GridConfig",menuName = "CreateGridConfig/NewConfig")]
public class GridConfig : ScriptableObject
{
    public int width;
    public int height;
    public int AOI;
    public ColorsConfig colorConfig;
}
