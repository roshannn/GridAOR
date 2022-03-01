using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Image firstPrimaryWeapon;
    public Image secondPrimaryWeapon;
    public Image secondaryWeapon;
    public Text ammoCount;
    void Start()
    {
        firstPrimaryWeapon.sprite = WeaponSystem.Instance.weaponDictionary[PlayerSystem.Instance.currPlayer.firstPrimaryWeapon.weaponData.weaponName].WeaponSprite;
        secondPrimaryWeapon.sprite = WeaponSystem.Instance.weaponDictionary[PlayerSystem.Instance.currPlayer.secondPrimaryWeapon.weaponData.weaponName].WeaponSprite;
        secondaryWeapon.sprite = WeaponSystem.Instance.weaponDictionary[PlayerSystem.Instance.currPlayer.secondaryWeapon.weaponData.weaponName].WeaponSprite;
    }

    // Update is called once per frame
    public void UpdateAmmoCount()
    {
        ammoCount.text = PlayerSystem.Instance.currPlayer.currEquippedWeapon.currBulletsInMag.ToString() + "/" + PlayerSystem.Instance.currPlayer.currEquippedWeapon.weaponData.MagazineSize;
    }

    public void UpdateHighlight()
    {
        if (PlayerSystem.Instance.currPlayer.currEquippedWeapon == PlayerSystem.Instance.currPlayer.firstPrimaryWeapon)
        {
            firstPrimaryWeapon.material.color = Color.white;
            secondPrimaryWeapon.material.color = Color.clear;
            secondaryWeapon.material.color = Color.clear;
        }
        if (PlayerSystem.Instance.currPlayer.currEquippedWeapon == PlayerSystem.Instance.currPlayer.secondPrimaryWeapon)
        {
            firstPrimaryWeapon.material.color = Color.clear;
            secondPrimaryWeapon.material.color = Color.white;
            secondaryWeapon.material.color = Color.clear;
        }
        if (PlayerSystem.Instance.currPlayer.currEquippedWeapon == PlayerSystem.Instance.currPlayer.secondaryWeapon)
        {
            firstPrimaryWeapon.material.color = Color.clear;
            secondPrimaryWeapon.material.color = Color.clear;
            secondaryWeapon.material.color = Color.white;
        }

    }
}
