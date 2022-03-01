using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class WeaponData
{
    [SerializeField] public Sprite WeaponSprite;
    [SerializeField] public GameObject Weapon;
    [SerializeField] public GameObject Bullet;
    [SerializeField] public WeaponName weaponName;
    [SerializeField] public WeaponType weaponType;
    [SerializeField] public int Cost;
    [SerializeField] public int headDamage;
    [SerializeField] public int bodyDamage;
    [SerializeField] public int legDamage;
    [SerializeField] public float fireRate;
    [SerializeField] public float runSpeed;
    [SerializeField] public float reloadTime;
    [SerializeField] public int MagazineSize;
    [SerializeField] public int TotalBullets;
    [SerializeField] public float BulletSpeed;
}

public enum WeaponName
{
    Pistol, SMG, AR, Sniper, Shotgun
}