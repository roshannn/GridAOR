using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSystem : MonoBehaviour
{
    private static WeaponSystem instance;
    public static WeaponSystem Instance { get { return instance; } }

    public WeaponDataSO WeaponDataSO;
    public Dictionary<WeaponName, WeaponData> weaponDictionary = new Dictionary<WeaponName, WeaponData>();
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        InitializeWeaponDictionary();
    }

    private void InitializeWeaponDictionary()
    {
        for (int i = 0; i < Enum.GetValues(typeof(WeaponName)).Length; i++)
        {
            weaponDictionary.Add((WeaponName)i, WeaponDataSO.weapons[i]);
        }
    }

}

