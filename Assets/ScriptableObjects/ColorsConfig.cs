using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "ColorsConfig",menuName = "CreateColorsConfig/NewConfig")]
public class ColorsConfig : ScriptableObject
{
    public List<Color> ColorsToApply = new List<Color>();

    private void Awake()
    {
        for(int i = 0; i< 20; i++)
        {
            ColorsToApply.Add(Random.ColorHSV(0f, 1f, 0.5f, 1f, 0.5f, 1f));
        }
    }
}
