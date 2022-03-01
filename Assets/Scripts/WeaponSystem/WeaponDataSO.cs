using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponData",menuName = "WeaponData/NewWeaponData")]
public class WeaponDataSO : ScriptableObject
{
    public List<WeaponData> weapons;
}
