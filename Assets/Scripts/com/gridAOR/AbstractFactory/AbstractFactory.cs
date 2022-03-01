using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.gridAOR.AbstractFactory
{
    public abstract class AbstractFactory<T> : MonoBehaviour where T : MonoBehaviour
    {
        [SerializeField]
        protected T m_Prefab;

        public virtual T GetNewInstance()
        {
            return Instantiate(m_Prefab);
        }
        public virtual T GetNewInstance(Vector3 position, Quaternion rotation)
        {
            return Instantiate(m_Prefab, position, rotation);
        }
    }
}

