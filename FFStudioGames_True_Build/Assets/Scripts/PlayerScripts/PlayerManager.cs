using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    //*******Main Atributes***********************
    [SerializeField] private int extraJumpsValue;
    [SerializeField] private float jumpTimer;
    [SerializeField] private float jumpTimerReset;
    [SerializeField] private AudioSource jumpSFX;
    [SerializeField] private float speed;
    [SerializeField] private AudioSource deathSFX;

    private GameObject item;
    private Rigidbody2D body;
    private bool justJumped;
    private bool grounded;
    private int extraJumps;
    private Animator animator;

    void Start()
    {
        item = GameObject.FindGameObjectWithTag("Item");
        extraJumps = extraJumpsValue;
        body = GetComponent<Rigidbody2D>();
        jumpSFX = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        body.linearVelocity = new Vector2(horizontalInput * speed, body.linearVelocity.y);
        
        //if player is moving at least x+0.01f sprite is turned to Vector3.one which is right
        if (horizontalInput > 0.01f)
        {
            transform.localScale = Vector3.one;
        }
        //if player is moving at least x-0.01f sprite is turned to oposte of Vector3.one
        else if (horizontalInput < -0.01f)
        {
            transform.localScale = new Vector3(-1,1,1);
        }
            

        if (Input.GetKey(KeyCode.Space) && extraJumps > 0 && justJumped == false) 
        { 
            Jump();
            justJumped = true;
            jumpSFX.Play();
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

        /*if (extraJumps == 0)
        {
            grounded = false;
        }*/
    }

    //Jump
    private void Jump()
    {
        body.linearVelocity = new Vector2(body.linearVelocity.x, speed);
        grounded = false;
    }
    
    //Death
    private void Die()
    {
        body.bodyType = RigidbodyType2D.Static;
        animator.enabled = true;
        animator.SetTrigger("Death");
        Debug.Log("GameOver");
    }

    //Triggers/Collisions
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            grounded = true;
        }
        
        if (collision.gameObject.CompareTag("Item"))
        {
            extraJumpsValue++;
            item.SetActive(false);
        }
        
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Die();
            deathSFX.Play();
        }
    }
}