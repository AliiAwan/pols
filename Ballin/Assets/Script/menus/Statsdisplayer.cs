using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Statsdisplayer : MonoBehaviour
{
    public TMP_Text display;

    // Start is called before the first frame update
    void Start()
    {
        string text = "Coins: " + GlobalManager.AllCoins+"\nRuns: ";
        display.text = text;
    }


}
