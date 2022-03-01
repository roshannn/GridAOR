using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseWeapon : MonoBehaviour
{
    public WeaponData weaponData;
    [SerializeField] private WeaponName weaponName;
    [SerializeField] public WeaponType weaponType;
    [SerializeField] private int Cost;
    [SerializeField] private int headDamage;
    [SerializeField] private int bodyDamage;
    [SerializeField] private int legDamage;
    [SerializeField] private float fireRate;
    [SerializeField] private float runSpeed;
    [SerializeField] private float reloadTime;
    [SerializeField] private int MagazineSize;
    [SerializeField] public int TotalBullets;
    [SerializeField] public float BulletSpeed;
    [SerializeField] Transform firePoint;

    public int currBulletsInMag;

    protected virtual void Awake()
    {
        weaponData = WeaponSystem.Instance.weaponDictionary[weaponName];
        InitializeWeapon(weaponData);
    }

    public void InitializeWeapon(WeaponData weaponData)
    {
        weaponType = weaponData.weaponType;
        Cost = weaponData.Cost;
        headDamage = weaponData.headDamage;
        bodyDamage = weaponData.bodyDamage;
        legDamage = weaponData.legDamage;
        fireRate = weaponData.fireRate;
        runSpeed = weaponData.runSpeed;
        reloadTime = weaponData.reloadTime;
        MagazineSize = weaponData.MagazineSize;
        TotalBullets = weaponData.TotalBullets;
        BulletSpeed = weaponData.BulletSpeed;
    }

    public void FireWeapon()
    {
        //Should Implement Pooling 
        GameObject bullet = Instantiate(WeaponSystem.Instance.weaponDictionary[weaponName].Bullet, firePoint.position, this.transform.rotation);
        LeanTween.move(bullet,Vector3.forward * BulletSpeed,2f).setOnComplete(()=>Destroy(bullet));
        currBulletsInMag--;
        if (currBulletsInMag == 0)
        {
            StartCoroutine(ReloadWeapon());
        }
    }
    public IEnumerator ReloadWeapon()
    {
        if (currBulletsInMag < weaponData.MagazineSize && weaponData.TotalBullets > 0)
        {
            yield return new WaitForSeconds(weaponData.reloadTime);
            int bulletsToAdd  = weaponData.MagazineSize - currBulletsInMag;
            if (bulletsToAdd < weaponData.TotalBullets)
            {
                currBulletsInMag += bulletsToAdd;
                weaponData.TotalBullets -= bulletsToAdd;
            }
            else
            {
                currBulletsInMag += weaponData.TotalBullets;
                weaponData.TotalBullets = 0;
            }
        }
        PlayerSystem.Instance.uiController.UpdateAmmoCount();
    }
}
public enum WeaponType
{
    Primary, Secondary
}
public enum FiringMode
{
    Single, Auto, Burst
}
