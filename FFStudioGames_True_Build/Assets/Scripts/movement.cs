using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class movement : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D body;
    public static bool grounded = false;
    private int extraJumps;
    public int extraJumpsValue;
    public float jumpTimer;
    public float jumpTimerReset;
    private bool justJumped;
    AudioSource jumpSound;

    void Start()
    {
        extraJumps = extraJumpsValue;
        body = GetComponent<Rigidbody2D>();
        jumpSound = GetComponent<AudioSource>();
    }

 

    private void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        body.linearVelocity = new Vector2(horizontalInput * speed, body.linearVelocity.y);
        //if player is moving at least x+0.01f sprite is turned to Vector3.one which is right
        if (horizontalInput > 0.01f)
            transform.localScale = Vector3.one;
        //if player is moving at least x-0.01f sprite is turned to oposte of Vector3.one
        else if (horizontalInput < -0.01f)
            transform.localScale = new Vector3(-1,1,1);

        if (Input.GetKey(KeyCode.Space) && extraJumps > 0 && justJumped == false) 
        { 
            Jump();
            justJumped = true;
            jumpSound.Play();
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
            Debug.Log("Quitting");
        }

        if (Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        
        if(grounded == false && justJumped == true)
        {
            jumpTimer--;

            if (jumpTimer <= 0)
            {
                extraJumps--;
                jumpTimer = jumpTimerReset;
                justJumped = false;
            }
        }

        
        
        if (grounded == true)
        {
            extraJumps = extraJumpsValue;
        }

        if (extraJumps == 0)
        {
            grounded = false;
        }
    }

    //jump function
    private void Jump()
    {
        body.linearVelocity = new Vector2(body.linearVelocity.x, speed);
        grounded = false;
        //unable the status grounded
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        grounded = true;
        
        if (collision.gameObject.tag == "Item")
        {
            extraJumpsValue++;
        }

        
    }
}