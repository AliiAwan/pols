using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class RunTemplate 
{
    //public float time;
    public float Distance;

    public RunTemplate()
    {
        Distance = GlobalManager.Distance;
    }
}
