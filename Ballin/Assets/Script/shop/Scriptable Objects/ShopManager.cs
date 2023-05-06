using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public TMP_Text CoinsDisplay;

    public GameObject PreviewMaterial;
    public GameObject PreviewPlayer;

    public ShopItemSO[] materialitemsSO;
    public ShopTemplate[] materialpanels;
    public GameObject[] materialpanelsGO;
    public Button[] myPurchaseMaterialBtns;
    public Button[] SelectableMaterialBtns;

    public ShopItemSO[] playeritemsSO;
    public ShopTemplate[] playerpanels;
    public GameObject[] playerpanelsGO;
    public Button[] myPurchasePlayerBtns;
    public Button[] SelectablePlayerBtns;

    public ShopItemSO[] skyboxitemsSO;
    public ShopTemplate[] skyboxpanels;
    public GameObject[] skyboxpanelsGO;
    public Button[] myPurchaseSkyboxBtns;
    public Button[] SelectableSkyboxBtns;

    AudioSource audioData;


    // Start is called before the first frame update
    void Start()
    {
        audioData = GetComponent<AudioSource>();

        SaveSystem.LoadPlayer();

        //GlobalManager.AllCoins = 10000;

        for (int i = 0; i < materialitemsSO.Length; i++)
            materialpanelsGO[i].SetActive(true);

        for (int i = 0; i < playeritemsSO.Length; i++)
            playerpanelsGO[i].SetActive(true);

        for (int i = 0; i < skyboxitemsSO.Length; i++)
            skyboxpanelsGO[i].SetActive(true);

        CoinsDisplay.text = "Coins:" + GlobalManager.AllCoins.ToString();
        LoadItems();
        CheckPurchaseable();
        CheckSelectable();
        PreviewMaterial.GetComponent<MeshRenderer>().material = GlobalManager.CurrMaterial;
        PreviewPlayer.GetComponent<MeshRenderer>().material = GlobalManager.CurrPlayer;
    }

    public void LoadItems()
    {
        for (int i = 0; i < materialitemsSO.Length; i++)
        {
            materialpanels[i].nameText.text = materialitemsSO[i].name;
            materialpanels[i].descriptionText.text = materialitemsSO[i].description;
            materialpanels[i].coincostText.text = materialitemsSO[i].coincost.ToString() + " Coins";
        }

        for (int i = 0; i < playeritemsSO.Length; i++)
        {
            playerpanels[i].nameText.text = playeritemsSO[i].name;
            playerpanels[i].descriptionText.text = playeritemsSO[i].description;
            playerpanels[i].coincostText.text = playeritemsSO[i].coincost.ToString() + " Coins";
        }

        for (int i = 0; i < skyboxitemsSO.Length; i++)
        {
            skyboxpanels[i].nameText.text = skyboxitemsSO[i].name;
            skyboxpanels[i].descriptionText.text = skyboxitemsSO[i].description;
            skyboxpanels[i].coincostText.text = skyboxitemsSO[i].coincost.ToString() + " Coins";
        }
    }

    public void CheckPurchaseable()
    {
        for (int i = 0; i < materialitemsSO.Length; i++)
        {
            if (GlobalManager.AllCoins >= materialitemsSO[i].coincost)
                myPurchaseMaterialBtns[i].interactable = true;
            else
                myPurchaseMaterialBtns[i].interactable = false;

        }

        for (int i = 0; i < playeritemsSO.Length; i++)
        {
            if (GlobalManager.AllCoins >= playeritemsSO[i].coincost)
                myPurchasePlayerBtns[i].interactable = true;
            else
                myPurchasePlayerBtns[i].interactable = false;

        }

        for (int i = 0; i < skyboxitemsSO.Length; i++)
        {
            if (GlobalManager.AllCoins >= skyboxitemsSO[i].coincost)
                myPurchaseSkyboxBtns[i].interactable = true;
            else
                myPurchaseSkyboxBtns[i].interactable = false;

        }
    }

    public void CheckSelectable()
    {
        for (int i = 0; i < materialitemsSO.Length; i++)
        {
            if (GlobalManager.UnlockedMaterials.Any(x => x == materialitemsSO[i].name))
            {
                SelectableMaterialBtns[i].gameObject.SetActive(true);
                myPurchaseMaterialBtns[i].interactable = false;
            }
            else
                SelectableMaterialBtns[i].gameObject.SetActive(false);
        }
        for (int i = 0; i < playeritemsSO.Length; i++)
        {
            if (GlobalManager.UnlockedPlayers.Any(x => x == playeritemsSO[i].name))
            {
                SelectablePlayerBtns[i].gameObject.SetActive(true);
                myPurchasePlayerBtns[i].interactable = false;
            }
            else
                SelectablePlayerBtns[i].gameObject.SetActive(false);
        }
        for (int i = 0; i < skyboxitemsSO.Length; i++)
        {
            if (GlobalManager.UnlockedSkyboxes.Any(x => x == skyboxitemsSO[i].name))
            {
                SelectableSkyboxBtns[i].gameObject.SetActive(true);
                myPurchaseSkyboxBtns[i].interactable = false;
            }
            else
                SelectableSkyboxBtns[i].gameObject.SetActive(false);
        }
    }

    public void PurchaseMaterialItem(int btnNo)
    {
        if (GlobalManager.AllCoins >= materialitemsSO[btnNo].coincost)
        {
            audioData.Play();
            GlobalManager.AllCoins -= materialitemsSO[btnNo].coincost;
            CoinsDisplay.text = "Coins:" + GlobalManager.AllCoins.ToString();
            CheckPurchaseable();
            //unlock logic here
            GlobalManager.UnlockedMaterials.Add(materialitemsSO[btnNo].name);
            GlobalManager.CurrMaterial = materialitemsSO[btnNo].material;
            CheckSelectable();
            SaveSystem.SavePlayer();
            SaveSystem.LoadPlayer();
        }
    }

    public void PurchasePlayerItem(int btnNo)
    {
        if (GlobalManager.AllCoins >= playeritemsSO[btnNo].coincost)
        {
            audioData.Play();
            GlobalManager.AllCoins -= playeritemsSO[btnNo].coincost;
            CoinsDisplay.text = "Coins:" + GlobalManager.AllCoins.ToString();
            CheckPurchaseable();
            //unlock logic here
            GlobalManager.UnlockedPlayers.Add(playeritemsSO[btnNo].name);
            GlobalManager.CurrPlayer = playeritemsSO[btnNo].material;
            CheckSelectable();
            SaveSystem.SavePlayer();
            SaveSystem.LoadPlayer();
        }
    }

    public void PurchaseSkyboxItem(int btnNo)
    {
        if (GlobalManager.AllCoins >= skyboxitemsSO[btnNo].coincost)
        {
            audioData.Play();
            GlobalManager.AllCoins -= skyboxitemsSO[btnNo].coincost;
            CoinsDisplay.text = "Coins:" + GlobalManager.AllCoins.ToString();
            CheckPurchaseable();
            //unlock logic here
            GlobalManager.UnlockedSkyboxes.Add(skyboxitemsSO[btnNo].name);
            GlobalManager.CurrSkybox = skyboxitemsSO[btnNo].material;
            CheckSelectable();
            SaveSystem.SavePlayer();
            SaveSystem.LoadPlayer();
        }
    }

    public void SelectMaterialItem(int btnNo)
    {
        audioData.Play();
        GlobalManager.CurrMaterial = materialitemsSO[btnNo].material;
        PreviewMaterial.GetComponent<MeshRenderer>().material = GlobalManager.CurrMaterial;
        //Select button grün machen um selected darzustellen
    }
    public void SelectPlayerItem(int btnNo)
    {
        audioData.Play();
        GlobalManager.CurrPlayer = playeritemsSO[btnNo].material;
        PreviewPlayer.GetComponent<MeshRenderer>().material = GlobalManager.CurrPlayer;
        //Select button grün machen um selected darzustellen
    }
    public void SelectSkyBoxItem(int btnNo)
    {
        audioData.Play();
        GlobalManager.CurrSkybox = skyboxitemsSO[btnNo].material;
        RenderSettings.skybox = GlobalManager.CurrSkybox;
        //Select button grün machen um selected darzustellen
    }

}
