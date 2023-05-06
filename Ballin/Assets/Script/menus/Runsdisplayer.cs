using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Runsdisplayer : MonoBehaviour
{
    public GameObject ContentParent;

    public int fontsize;

    // Start is called before the first frame update
    void Start()
    {
        RenderSettings.skybox = GlobalManager.CurrSkybox;
        foreach (RunTemplate r in GlobalManager.Runs)
        {
            GameObject runobject = new GameObject();
            runobject.AddComponent<CanvasRenderer>();
            runobject.AddComponent<RectTransform>();
            runobject.AddComponent<TextMeshProUGUI>().text = "Distance: "+r.Distance+"m Coins: "+r.CoinsCollected;
            runobject.GetComponent<TextMeshProUGUI>().fontSize = fontsize;
            runobject.GetComponent<RectTransform>().sizeDelta = new Vector2(400, 50);
            GameObject instacedRunObject = Instantiate(runobject);
            instacedRunObject.transform.parent = ContentParent.transform;
        }
    }
}
