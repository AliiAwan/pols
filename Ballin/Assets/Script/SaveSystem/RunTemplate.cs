using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class RunTemplate 
{
    //public float time;
    public float distance;
    public float Score;

    public RunTemplate()
    {
        distance = GlobalManager.Distance;
        Score = GlobalManager.Score;
    }
}
