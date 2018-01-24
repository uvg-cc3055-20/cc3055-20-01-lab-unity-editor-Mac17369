using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour {
    public float jumpForce = 100f;
    public Rigidbody2D rb;
    public float forwardSpeed = 5f;
    public GameObject cam;
    public Boolean dead = false;
    public GameObject coin;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if (dead == false)
        {
            if (Input.GetButtonDown("Jump"))
            {

                rb.velocity = Vector2.zero;
                rb.AddForce(Vector2.up * jumpForce);

            }
            rb.transform.Translate(new Vector3(1, 0, 0) * forwardSpeed * Time.deltaTime);
            cam.transform.Translate(new Vector3(1, 0, 0) * forwardSpeed * Time.deltaTime);
        }
        if (rb.position.x >= 42)
        {
            Destroy(rb);
        }
    }
    //Collision
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Column")
        {
            dead = true;
            Debug.Log("CHOQUE");
        }
        Destroy (GameObject.FindWithTag("Coin"));

    }
}
