using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrimaryWeapon : BaseWeapon
{
    public List<FiringMode> firingModes;
    public FiringMode currFiringMode;
    protected override void Awake()
    {
        base.Awake();
        currFiringMode = firingModes[0];
    }
}
