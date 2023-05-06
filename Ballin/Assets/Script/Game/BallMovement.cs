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
        RenderSettings.skybox = GlobalManager.CurrSkybox;

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
       // Debug.Log((boostslowrate * rb.velocity.z + constboost));
        float speed = (transform.position - lastPosition).magnitude;
        GlobalManager.Speed = (float)((int)(speed * 100)) / 10;
        lastPosition = transform.position;

        float f = Vector3.Distance(this.gameObject.transform.position, Spawnpoint.transform.position)/30;
		f = Mathf.Round(f * 10.0f);
        GlobalManager.Distance = f;
        Vector3 pos = rb.position;

        
	}

	private void OnTriggerEnter(Collider other)
    {
		if (other.gameObject.name.Contains("Speedy"))
		{
			rb.velocity *= boostamount;
		}
        else if(other.gameObject.name.Contains("Coin"))
        {
            GlobalManager.Coins+=100;
            Destroy(other.gameObject);
        }
		else
		{
			Invoke("loadDeathScreen",0 );
			rb.constraints = RigidbodyConstraints.FreezeAll;
			Destroy(this.gameObject.GetComponent<MeshRenderer>());

			//save data of run
			GlobalManager.AllCoins += GlobalManager.Coins;
			GlobalManager.Runs.Add(new RunTemplate() { Distance = GlobalManager.Distance , CoinsCollected= GlobalManager.Coins});
			GlobalManager.Coins = 0;
			SaveSystem.SavePlayer();
            if (!GlobalManager.Death)
			{
				GlobalManager.Death = true;
			}
			Debug.Log("Entered death");
		}
	}

    private void loadDeathScreen()
    {
        Canvas.SetActive(true);
        FadeIn();
        GlobalManager.Pausable = false;
        Debug.Log("Death Screen loaded");
    }

    public IEnumerator FadeIn()
    {
        while (Canvas.GetComponent<Renderer>().material.color.a > 0)
        {
            Color objectcolor = Canvas.GetComponent<Renderer>().material.color;
            float fadeAmount = objectcolor.a + (0.1f * Time.deltaTime);

            objectcolor = new Color(objectcolor.r, objectcolor.g, objectcolor.b, fadeAmount);
            Canvas.GetComponent<Renderer>().material.color = objectcolor;
            yield return null;
        }
    }
    }
