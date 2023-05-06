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

    public float master;
    public float music;
    public float sfx;

    public Material currMaterial;
    public Material currPlayer;
    public Material currSkybox;
    public PlayerTemplate()
    {
        this.AllCoins = GlobalManager.AllCoins;
        this.Runs = GlobalManager.Runs;

        this.master = GlobalManager.Master;
        this.music = GlobalManager.Music;
        this.sfx = GlobalManager.SFX;

        this.currMaterial = GlobalManager.CurrMaterial;
        this.currPlayer = GlobalManager.CurrPlayer;
        this.currSkybox = GlobalManager.CurrSkybox;

        this.UnlockedMaterials = GlobalManager.UnlockedMaterials;
        this.UnlockedPlayers = GlobalManager.UnlockedPlayers;
        this.UnlockedSkyboxes = GlobalManager.UnlockedSkyboxes;
    }
}
