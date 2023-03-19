using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class RunTemplate 
{
    //public float time;
    public float Distance;
    public float CoinsCollected;

    public RunTemplate()
    {
        CoinsCollected = GlobalManager.Coins;
        Distance = GlobalManager.Distance;
    }
}
