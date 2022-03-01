using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using com.gridAOR.AbstractFactory;
using System;

public class TileFactory : AbstractFactory<TileObject>
{


    public override TileObject GetNewInstance(Vector3 position, Quaternion rotation)
    {
        return base.GetNewInstance(position, rotation);
    }



}

