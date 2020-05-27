using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLeft : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;
    private float movement;
    private Vector3 startPos;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startPos = transform.position;
    }

    void Update()
    {
        PlayerLeftMovement();
      
    }
    void PlayerLeftMovement()
    {

        //red player movement for up and down
        if (Input.GetKey(KeyCode.W))
        {
           rb.velocity = Vector3.up * speed;
        }
       else if (Input.GetKey(KeyCode.S))
        {
            rb.velocity = Vector3.down * speed;
        }
        else
        {
            rb.velocity = new Vector2(0f, 0f);
        }
    }
}
