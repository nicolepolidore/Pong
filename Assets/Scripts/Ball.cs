using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{
    public float speed = 10f;
    private Rigidbody2D rb;
    private Vector3 startPos;
    public AudioSource hitSound;
    public AudioSource wallSound;
    public Text countText;


    private float xForce, yForce; //x and y force for the ball movement

    private ScoreManager scoreManager;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
       
        MoveBall(); 

        StartCoroutine(BallSpawn());
        StartCoroutine(CountDown());

        scoreManager = GameObject.FindObjectOfType<ScoreManager>();

        xForce = 5f;
        yForce = Random.Range(-2,2f);
        //setting the x and y value of the ball. yForce is set randomly to add variance to its bounce


    }

    IEnumerator CountDown()
    {
        countText.text = "3";
        yield return new WaitForSeconds(1f);
        countText.text = "2";
        yield return new WaitForSeconds(1f);
        countText.text = "1";
        yield return new WaitForSeconds(1f);
        countText.text = " ";


    }
    void MoveBall()
    {
        rb.velocity = new Vector2(xForce, yForce); //movement of the ball

    }
    IEnumerator BallSpawn()
    {
       //wait for 3 seconds then the ball will move
        yield return new WaitForSeconds(3f);
        rb.velocity = new Vector2(xForce, yForce);


    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        //collision behavior with player 
        if (collision.gameObject.CompareTag("Player"))
        {

            hitSound.pitch = Random.Range(0.5f, 1.5f);
            hitSound.Play();
           
        }

       //collision behavior with walls
        if (collision.gameObject.CompareTag("TopWall"))
        {

            rb.velocity += new Vector2(0, 5f).normalized; //helping the ball counce off the walls 
            wallSound.Play();

        }

        else if (collision.gameObject.CompareTag("BottomWall"))
        {
            rb.velocity += new Vector2(0, -5f).normalized;
            wallSound.Play();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("LeftScore"))
        {
            //calling scoreManager to add a score to the left and then reset the ball position
            scoreManager.AddScoreLeft();
            Reset();
        }

        if (other.gameObject.CompareTag("RightScore"))
        {
            //calling scoreManager to add a score to the right and then reset the ball position

            scoreManager.AddScoreRight();
            Reset();
        }
       

    }

    private void Reset()
    {
        //resetting the ball's velocity and position
        rb.velocity = Vector2.zero;
        transform.position = startPos;
        StartCoroutine(BallSpawn());


    }
}


