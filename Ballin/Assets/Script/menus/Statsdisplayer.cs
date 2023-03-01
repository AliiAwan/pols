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
        string coins = "Coins:" + GlobalManager.AllCoins+"\n";
        string runs = "Runs:\n";
		//Debug.Log("Loaded Runs:"+GlobalManager.Runs.Count);
		if (GlobalManager.Runs.Count > 0)
        {
            foreach (RunTemplate r in GlobalManager.Runs)
            {
                runs += "" + r.Distance + "m\n";
            }

            display.text =coins+ runs;
        }
        else
        {
            display.text = "currently no runs available";
        }
    }


}
