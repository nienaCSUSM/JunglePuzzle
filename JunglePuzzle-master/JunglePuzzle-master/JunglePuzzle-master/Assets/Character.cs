﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public float speed;
    public float jumpHeight;
    private Vector3 direction;
    private Rigidbody rb;
    public LayerMask ground;
    public Transform feet;
    private int db = 0;
    public GameObject obj;
    public int buttoncount;
    public int buttoncount1;


     // Start is called before the first frame update
    void Start()
    {
        speed = 3.0f;
        jumpHeight = 6.5f;
        rb = GetComponent<Rigidbody>();
        buttoncount=0;
        buttoncount1=0;
    }

    // Update is called once per frame
    void Update()
    {
      
        direction = Vector3.zero;
        direction.x = Input.GetAxis("Horizontal");
        direction = direction.normalized;
        if (direction != Vector3.zero)
        {
            transform.forward = direction;
            rb.MovePosition(transform.position + (direction * speed * Time.deltaTime));
        }
        bool grounded()
        {
            if (Physics.CheckSphere(feet.position, .1f, ground))
            {
                db = 0;
                return true;
            }
            else { return false; }
        }
        if(Input.GetButtonDown("Jump")&& (grounded() || db < 1))
        {
            db += 1;
            rb.AddForce(Vector3.up * jumpHeight, ForceMode.VelocityChange);
        }


    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Enemy" || collision.gameObject.name == "platform-detail-15")
        {
            transform.position = new Vector3(-14f, -3.5f, 0f);
        }
        else if (collision.gameObject.name == "Button" && buttoncount < 1)
        {
            Instantiate(obj, new Vector3(59, 1, 0), Quaternion.identity); buttoncount++;
        }
        else if (collision.gameObject.name == "Button" && buttoncount < 3)
        {
            Instantiate(obj, new Vector3(59, 1, 0), Quaternion.identity); buttoncount++;
        }
        else if (collision.gameObject.name=="Button1" && buttoncount1<1)
        {
            Instantiate(obj, new Vector3(67, 1, 0), Quaternion.identity);
            buttoncount1++;

        }
        else if(collision.gameObject.name=="Exit")
        {

        }

    }

}
