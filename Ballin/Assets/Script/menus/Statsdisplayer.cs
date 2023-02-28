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
        string runs = "Runs:\n";
        if (GlobalManager.Runs.Count > 0)
        {
            foreach (RunTemplate r in GlobalManager.Runs)
            {
                runs += "" + r.distance + "\n";
            }

            display.text = runs;
        }
        else
        {
            display.text = "currently no runs available";
        }
    }


}
