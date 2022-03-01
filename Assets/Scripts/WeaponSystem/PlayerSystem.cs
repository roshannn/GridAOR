using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSystem : MonoBehaviour
{
    private static PlayerSystem instance;
    public static PlayerSystem Instance { get { return instance; } }

    public List<PlayerController> Players;

    public UIController uiController;

    public PlayerController currPlayer;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        currPlayer = Players[0];
    }

    // Update is called once per frame
    void Update()
    {

    }
}
