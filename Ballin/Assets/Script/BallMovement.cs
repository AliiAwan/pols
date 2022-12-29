using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;

public class BallMovement : MonoBehaviour
{

    float horizontal;

    public float runSpeed;

    public float constboost;


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
        rb.velocity += new Vector3(horizontal * runSpeed,0f, constboost);
        float speed = (transform.position - lastPosition).magnitude;
        GlobalManager.Speed = (float) ((int)(speed * 100)) / 10;
        lastPosition = transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(this.gameObject);
    }
}
