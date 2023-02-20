using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Levelgenerator : MonoBehaviour
{
    public GameObject Player;

    public List<GameObject> Chunks = new List<GameObject>();
    private List<GameObject> ChunkloadedList = new List<GameObject>();

    public float maxdistance;
    public float shifty= -10.255f; // -10.255f
    public float shiftz= 28.15f; // 28.15f

    private float lastenddisz;
    private float lastenddisy;

    // Start is called before the first frame update
    void Start()
    {
        int startamount = 15;
        for (int i = 1; i <(startamount+1); i++)
        {
            GameObject selected = Chunks[Random.Range(0, Chunks.Count)];
            GameObject loaded = Instantiate(selected);
            loaded.transform.position = new Vector3(0, i * shifty, i * shiftz);
            ChunkloadedList.Add(loaded);
        }

        lastenddisy = startamount * shifty;
        lastenddisz = startamount*shiftz;
    }

    // Update is called once per frame
    void Update()
    {
        if(lastenddisz-Player.transform.position.z < maxdistance)
        {
            GameObject selected = Chunks[Random.Range(0, Chunks.Count)];
            selected.transform.position = new Vector3(0, lastenddisy + shifty, lastenddisz+shiftz);
            GameObject loaded = Instantiate(selected);
            ChunkloadedList.Add(loaded);
            GameObject first = ChunkloadedList[0];
            Destroy(first);
            ChunkloadedList.Remove(first);
            lastenddisy += shifty;
            lastenddisz += shiftz;
        }

       
    }
}
