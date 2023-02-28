using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerTemplate
{
    public int Coins;
    public List<RunTemplate> Runs;

    public PlayerTemplate()
    {
        Coins = GlobalManager.Coins;
        Runs = GlobalManager.Runs;
    }
}
