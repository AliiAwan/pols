using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadPlayerData : MonoBehaviour
{
    public ShopItemSO DefaultMaterial;
    public ShopItemSO DefaultPlayer;
    public ShopItemSO DefaultSkyBox;

    public GameObject startSegment;

    // Start is called before the first frame update
    void Start()
    {
        //Die zwei Zeilen sind nur wenn man was neues dazu gibts
        SaveSystem.ClearStats();
        SaveSystem.SavePlayer();

        SaveSystem.LoadPlayer();
        

        if(GlobalManager.UnlockedMaterials.Count == 0)
        {
            //noch nichts freigeschalten => default automatisch freischalten und selecten
            GlobalManager.UnlockedMaterials.Add(DefaultMaterial.name);
            GlobalManager.CurrMaterial = DefaultMaterial.material;
        }
        else if (GlobalManager.CurrMaterial == null)
        {
            GlobalManager.CurrMaterial = DefaultMaterial.material;
        }

        if (GlobalManager.UnlockedPlayers.Count == 0)
        {
            //noch nichts freigeschalten => default automatisch freischalten und selecten
            GlobalManager.UnlockedPlayers.Add(DefaultPlayer.name);
            GlobalManager.CurrPlayer = DefaultPlayer.material;
        }
        else if (GlobalManager.CurrPlayer == null)
        {
            GlobalManager.CurrPlayer = DefaultPlayer.material;
        }

        if (GlobalManager.UnlockedSkyboxes.Count == 0)
        {
            //noch nichts freigeschalten => default automatisch freischalten und selecten
            GlobalManager.UnlockedSkyboxes.Add(DefaultSkyBox.name);
            GlobalManager.CurrSkybox = DefaultSkyBox.material;
        }
        else if (GlobalManager.CurrSkybox == null)
        {
            GlobalManager.CurrSkybox = DefaultSkyBox.material;
        }
        startSegment.GetComponent<MeshRenderer>().material = GlobalManager.CurrMaterial;
        RenderSettings.skybox = GlobalManager.CurrSkybox;
    }
}
