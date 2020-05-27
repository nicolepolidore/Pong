using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRight : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;
    private Vector3 startPos;
   

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startPos = transform.position;
    }

    void Update()
    {
        PlayerRightMovement();

    }
    void PlayerRightMovement()
    {
        //blue player movement for up and down
         if (Input.GetKey(KeyCode.UpArrow))
        {
            rb.velocity = Vector3.up * speed;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            rb.velocity = Vector3.down * speed;
        }
        else
        {
            rb.velocity = new Vector2(0f, 0f);
        }

    }
}
