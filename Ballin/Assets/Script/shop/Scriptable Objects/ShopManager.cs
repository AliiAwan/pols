using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public TMP_Text CoinsDisplay;

    public ShopItemSO[] materialitemsSO;
    public ShopTemplate[] materialpanels;
    public GameObject[] materialpanelsGO;
    public Button[] myPurchaseMaterialBtns;

    public ShopItemSO[] playeritemsSO;
    public ShopTemplate[] playerpanels;
    public GameObject[] playerpanelsGO;
    public Button[] myPurchasePlayerBtns;


    // Start is called before the first frame update
    void Start()
    {
        GlobalManager.AllCoins = 10000;


        for (int i = 0; i < materialitemsSO.Length; i++)
            materialpanelsGO[i].SetActive(true);

        for (int i = 0; i < playeritemsSO.Length; i++)
            playerpanelsGO[i].SetActive(true);

        CoinsDisplay.text = "Coins:" + GlobalManager.AllCoins.ToString();
        LoadItems();
        CheckPurchaseable();
    }

    public void LoadItems()
    {
        for (int i = 0; i < materialitemsSO.Length; i++)
        {
            materialpanels[i].nameText.text = materialitemsSO[i].name;
            materialpanels[i].descriptionText.text = materialitemsSO[i].description;
            materialpanels[i].coincostText.text = "Coins:" + materialitemsSO[i].coincost.ToString();
        }

        for (int i = 0; i < playeritemsSO.Length; i++)
        {
            playerpanels[i].nameText.text = playeritemsSO[i].name;
            playerpanels[i].descriptionText.text = playeritemsSO[i].description;
            playerpanels[i].coincostText.text = "Coins:" + playeritemsSO[i].coincost.ToString();
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
    }

    public void PurchaseMaterialItem(int btnNo)
    {
        if (GlobalManager.AllCoins >= materialitemsSO[btnNo].coincost)
        {
            GlobalManager.AllCoins -= materialitemsSO[btnNo].coincost;
            CoinsDisplay.text = "Coins:" + GlobalManager.AllCoins.ToString();
            CheckPurchaseable();
            //unlock logic here
        }
    }

    public void PurchasePlayerItem(int btnNo)
    {
        if (GlobalManager.AllCoins >= playeritemsSO[btnNo].coincost)
        {
            GlobalManager.AllCoins -= playeritemsSO[btnNo].coincost;
            CoinsDisplay.text = "Coins:" + GlobalManager.AllCoins.ToString();
            CheckPurchaseable();
            //unlock logic here
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
