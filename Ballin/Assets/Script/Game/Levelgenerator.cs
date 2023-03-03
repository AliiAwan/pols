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
    public float shifty; // -10.255f
    public float shiftz; // 28.15fsx

    private float lastenddisz;
    private float lastenddisy;

    // Start is called before the first frame update
    void Start()
    {
        int startamount = 3;
        for (int i = 1; i <=startamount; i++)
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
			if (lastenddisz - Player.transform.position.z < maxdistance)
            {
			    shifty = -37.4f - Mathf.Round(GlobalManager.Speed / 2) * 1;
			    shiftz = 90.15f+  Mathf.Round(GlobalManager.Speed / 2) * 3f;
                var number = ChunkloadedList.Count;
                var f = Random.Range(0, Chunks.Count);
			    if ((ChunkloadedList[number-1].gameObject.name.Contains("WrenchRamp_Segment")))
			    {
				    shifty -= Mathf.Round(GlobalManager.Speed / 2f) * 2 ;
				    shiftz += Mathf.Round(GlobalManager.Speed / 4f) * 10;
			}
			GameObject selected = Chunks[f];
			    
			selected.transform.position = new Vector3(0, lastenddisy + shifty, lastenddisz + shiftz);
                GameObject loaded = Instantiate(selected);
                ChunkloadedList.Add(loaded);
                GameObject first = ChunkloadedList[0];
			    Debug.Log(first.transform.position.z);
			    Destroy(first);
                ChunkloadedList.Remove(first);
                lastenddisy += shifty;
                lastenddisz += shiftz;
            }
       
    }
}
