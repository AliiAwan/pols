using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadShopSelection : MonoBehaviour
{
    public GameObject Player;




    // Start is called before the first frame update
    void Start()
    {
        Player.GetComponent<Renderer>().material = GlobalManager.CurrPlayer;
    }

}
