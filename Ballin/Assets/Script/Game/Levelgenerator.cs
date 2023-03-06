using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Levelgenerator : MonoBehaviour
{
    public GameObject Player;
    public GameObject Tod;

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
			GameObject loadedbarrier = Instantiate(Tod);
			loaded.transform.position = new Vector3(0, i * shifty + 1, i * shiftz);
			loadedbarrier.transform.position = new Vector3(0, i * shifty - 3, i * shiftz + 3);
			ChunkloadedList.Add(loaded);
			ChunkloadedList.Add(loadedbarrier);
		}

		lastenddisy = startamount * shifty +2;
        lastenddisz = startamount*shiftz;
    }

    // Update is called once per frame
    void Update()
    {
		var number = ChunkloadedList.Count;
		if (lastenddisz - Player.transform.position.z < maxdistance)
        {
		    shifty = -37.4f - Mathf.Round(GlobalManager.Speed / 2.4f) * 1;
		    shiftz = 90.15f+  Mathf.Round(GlobalManager.Speed / 2) * 3f;
            var f = Random.Range(0, Chunks.Count);
			Debug.Log((ChunkloadedList[number - 2].gameObject.name));

            if ((ChunkloadedList[number-2].gameObject.name.Contains("WrenchRamp_Segment")))
			{
			    shifty -= Mathf.Round(GlobalManager.Speed / 2.2f) * 1;
			    shiftz += Mathf.Round(GlobalManager.Speed / 4f) * 8;
			}
			GameObject selected = Chunks[f];
			selected.transform.position = new Vector3(0, lastenddisy + shifty, lastenddisz + shiftz);
            GameObject loaded = Instantiate(selected);
            ChunkloadedList.Add(loaded);

			GameObject loadedbarrier = Instantiate(Tod);
			loadedbarrier.transform.position = new Vector3(0, lastenddisy + shifty - 3, lastenddisz + shiftz + 3);
			ChunkloadedList.Add(loadedbarrier);

			Debug.Log(ChunkloadedList[number - 1].transform.position.z);
			GameObject first = ChunkloadedList[0];
			Destroy(first);
            ChunkloadedList.Remove(first);
			first = ChunkloadedList[0];
			Destroy(first);
			ChunkloadedList.Remove(first);
			lastenddisy += shifty;
            lastenddisz += shiftz;
        }
		if (Player.transform.position.z > ChunkloadedList[number - 1].transform.position.z - 150)
			Debug.Log("death");
	}
}
