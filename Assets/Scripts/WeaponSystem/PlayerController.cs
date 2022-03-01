using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int credits;

    public PrimaryWeapon firstPrimaryWeapon;
    public PrimaryWeapon secondPrimaryWeapon;
    public SecondaryWeapon secondaryWeapon;

    public BaseWeapon currEquippedWeapon;

    private void Awake()
    {
        SetCurrWeaponInit();
    }

    private void SetCurrWeaponInit()
    {
        if (firstPrimaryWeapon)
        {
            currEquippedWeapon = firstPrimaryWeapon;
            return;
        }
        if (secondPrimaryWeapon)
        {
            currEquippedWeapon = secondPrimaryWeapon;
            return;
        }
        if (secondaryWeapon)
        {
            currEquippedWeapon = secondaryWeapon;
            return;
        }
        PlayerSystem.Instance.uiController.UpdateHighlight();

    }

    private void Update()
    {
        //Set 1st Weapon as equipped weapon
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            currEquippedWeapon = firstPrimaryWeapon != null ? firstPrimaryWeapon : currEquippedWeapon;
            PlayerSystem.Instance.uiController.UpdateHighlight();

        }
        //Set 2nd Weapon as equipped weapon

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            currEquippedWeapon = secondPrimaryWeapon != null ? secondPrimaryWeapon : currEquippedWeapon;
            PlayerSystem.Instance.uiController.UpdateHighlight();

        }
        //Set secondary Weapon as equipped weapon

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            currEquippedWeapon = secondaryWeapon != null ? secondPrimaryWeapon : currEquippedWeapon;
            PlayerSystem.Instance.uiController.UpdateHighlight();

        }
        //Change Firing mode
        if (Input.GetMouseButtonDown(2))
        {
            if (currEquippedWeapon.weaponType == WeaponType.Primary)
            {
                PrimaryWeapon wp = ((PrimaryWeapon)currEquippedWeapon);
                wp.currFiringMode = wp.firingModes[(wp.firingModes.IndexOf(wp.currFiringMode) + 1) <= wp.firingModes.Count - 1 ? wp.firingModes.IndexOf(wp.currFiringMode) + 1 : 0];
            }
        }
        //reloadWeapon

        if (Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(currEquippedWeapon.ReloadWeapon());
        }

        StartCoroutine(FireWeapon());
    }

    private IEnumerator FireWeapon()
    {
        if (Input.GetMouseButtonDown(0))
        {
            currEquippedWeapon.FireWeapon();
            yield return new WaitForSeconds(currEquippedWeapon.weaponData.fireRate);
            PlayerSystem.Instance.uiController.UpdateAmmoCount();
        }
    }

    

}
