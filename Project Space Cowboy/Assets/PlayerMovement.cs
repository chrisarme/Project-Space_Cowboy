using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    bool touchingTheGround = false;
    bool jumping = false;
    bool flying = false;

    Vector3 jump;
    //Vector3 jet;
    float jumpSpeed = 3.0f;
    Rigidbody rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        //jet = new Vector3(0f, 0.5f, 0f);
        jump = new Vector3(0.0f, 2.0f, 0.0f);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space) && touchingTheGround == true)
        { 
            jumping = true;
            touchingTheGround = false;
            rb.AddForce(jump * jumpSpeed, ForceMode.Impulse);
        }

        jetPack();
        movement();
    }

    void OnCollisionStay()
    {
        if (jumping == false)
        {
            touchingTheGround = true;
            rb.useGravity = true;
            //jet.y = .5f;
        }
        jumping = false;

    }

    void jetPack()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl) && touchingTheGround == false && flying == false)
        {
            flying = true;

            rb.useGravity = false;
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;

            //for (int i = 0; i < 5; i++)
            //{
                //jet.y = (float)(jet.y - (.01 * i /* * multiplier*/));
                //rb.AddForce(jet * jetpackStrength * 5, ForceMode.Impulse);
            //}
        }
        else if (Input.GetKeyDown(KeyCode.LeftControl) && touchingTheGround == false && flying == true)
        {
            flying = false;

            rb.useGravity = true;
        }
    }

    void movement()
    {
        if (flying == true)
        {
            if (Input.GetKey("w"))
            {
                rb.AddRelativeForce(Vector3.forward / 20, ForceMode.Impulse);
            }

            if (Input.GetKey("a"))
            {
                rb.AddRelativeForce(Vector3.left / 20, ForceMode.Impulse);
            }

            if (Input.GetKey("s"))
            {
                rb.AddRelativeForce(Vector3.back / 20, ForceMode.Impulse);
            }

            if (Input.GetKey("d"))
            {
                rb.AddRelativeForce(Vector3.right / 20, ForceMode.Impulse);
            }
        }
        else
        {
            if (Input.GetKey("w"))
            {
                gameObject.transform.Translate(Vector3.forward / 100);
            }

            if (Input.GetKey("a"))
            {
                gameObject.transform.Translate(Vector3.left / 100);
            }

            if (Input.GetKey("s"))
            {
                gameObject.transform.Translate(Vector3.back / 100);
            }

            if (Input.GetKey("d"))
            {
                gameObject.transform.Translate(Vector3.right / 100);
            }
        }
    }

}
