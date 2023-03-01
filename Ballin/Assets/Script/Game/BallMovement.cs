using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallMovement : MonoBehaviour
{

    float horizontal;

    public GameObject Canvas;

    public float runSpeed;

    public float constboost;

    public float boostamount;

    public float boostslowrate;

    public GameObject Spawnpoint;


    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        GlobalManager.Death = false;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
    }

    Vector3 lastPosition = Vector3.zero;

    private void FixedUpdate()
    {
        rb.velocity += new Vector3(horizontal * runSpeed, 0f, (boostslowrate*rb.velocity.z+constboost));
        Debug.Log((boostslowrate * rb.velocity.z + constboost));
        float speed = (transform.position - lastPosition).magnitude;
        GlobalManager.Speed = (float)((int)(speed * 100)) / 10;
        lastPosition = transform.position;

        float f = Vector3.Distance(this.gameObject.transform.position, Spawnpoint.transform.position)/30;
		f = Mathf.Round(f * 10.0f);
        GlobalManager.Distance = f;
	}

	private void OnTriggerEnter(Collider other)
    {
        if (!GlobalManager.Death)
        {
			GlobalManager.Runs.Add(new RunTemplate() { Score = GlobalManager.Distance });
			GlobalManager.Death = true;
        }
		Debug.Log("Entered death");
        if (other.gameObject.name.Contains("Speedy"))
        {
            rb.velocity *= boostamount;
        }
        else
        {
			Invoke("loadDeathScreen",0.2f);
			rb.constraints = RigidbodyConstraints.FreezeAll;
            Destroy(this.gameObject.GetComponent<MeshRenderer>());

            //save data of run
            SaveSystem.SavePlayer();


        }
    }

    private void loadDeathScreen()
    {
        Canvas.SetActive(true);
        GlobalManager.Pausable = false;
        Debug.Log("Death Screen loaded");
    }
}
