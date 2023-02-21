using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallMovement : MonoBehaviour
{

    float horizontal;

    public float runSpeed;

    public float constboost;

    public float boostamount;

    public float boostslowrate;


    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
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
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("Speedy"))
        {
            rb.velocity *= boostamount;
        }
        else
        {
            rb.constraints = RigidbodyConstraints.FreezeAll;
            Destroy(this.gameObject.GetComponent<MeshRenderer>());

            Invoke("loadDeathScreen", 4);
        }
    }

    private void loadDeathScreen()
    {
        SceneManager.LoadScene("DeathScreen");
        Debug.Log("Death Screen loaded");
    }
}
