using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerTemplate
{
    public int AllCoins;
    public List<RunTemplate> Runs;

    public List<string> UnlockedMaterials;
    public List<string> UnlockedPlayers;
    public List<string> UnlockedSkyboxes;


    public PlayerTemplate()
    {
        this.AllCoins = GlobalManager.AllCoins;
        this.Runs = GlobalManager.Runs;

        this.UnlockedMaterials = GlobalManager.UnlockedMaterials;
        this.UnlockedPlayers = GlobalManager.UnlockedPlayers;
        this.UnlockedSkyboxes = GlobalManager.UnlockedSkyboxes;
    }
}
