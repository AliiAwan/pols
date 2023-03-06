using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempCameraScript : MonoBehaviour
{
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        this.transform.position = new Vector3(player.transform.position.x,player.transform.position.y+6, player.transform.position.z-7);
    }
}
