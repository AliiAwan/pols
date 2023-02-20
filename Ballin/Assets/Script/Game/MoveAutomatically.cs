using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class MoveAutomatically : MonoBehaviour
{

    //how much to move horizontally (eg. 3 = -3...3)
    public float moveleft;
    public float moveright;

    //how much to move vertically (eg. 3 = -3...3)
    public float movedown;
    public float moveup;

    public float moveby;//how much should the object move each frame?

    //maximum postions relative to original postition of the object
    private float maxleft;
    private float maxright;
    private float maxup;
    private float maxdown;

    private bool goesleft;
    private bool goesdown;

    // Start is called before the first frame update
    void Start()
    {
        maxright = this.transform.position.x + moveright;
        maxleft = this.transform.position.x - moveleft;
        maxup = this.transform.position.y + moveup;
        maxdown = this.transform.position.y - movedown;

        float hordis = maxright - maxleft;
        float vertdis = maxup - maxdown;
        
        this.transform.position= new Vector3(Random.Range(maxleft, maxright), Random.Range(maxdown, maxup), this.transform.position.z);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //horizontal movement
        if(goesleft)
            this.transform.position = new Vector3(this.transform.position.x-moveby, this.transform.position.y, this.transform.position.z); 
        else
            this.transform.position = new Vector3(this.transform.position.x + moveby, this.transform.position.y, this.transform.position.z);
        
        if(this.transform.position.x <maxleft)
            goesleft = false;
        else if(this.transform.position.x > maxright)
            goesleft = true;

        //vertical movement
        if (goesdown)
            this.transform.position = new Vector3(this.transform.position.x , this.transform.position.y - moveby, this.transform.position.z);
        else
            this.transform.position = new Vector3(this.transform.position.x , this.transform.position.y + moveby, this.transform.position.z);

        if (this.transform.position.y < maxdown)
            goesdown = false;
        else if (this.transform.position.y > maxup)
            goesdown = true;
    }
}
