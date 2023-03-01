using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextScript : MonoBehaviour
{
    public TMP_Text text;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        text.text = "Speed:" + GlobalManager.Speed+"\nDistance:"+GlobalManager.Distance+"m";
    }
}
