using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerTemplate
{
    public int AllCoins;
    public List<RunTemplate> Runs;

    public PlayerTemplate()
    {
        AllCoins = GlobalManager.AllCoins;
        Runs = GlobalManager.Runs;
    }
}
