using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class Death : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    public AudioSource deathSfx;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            
            Die();
            deathSfx.Play();
           
        }
    }

    private void Die()
    {
        rb.bodyType = RigidbodyType2D.Static;
        anim.enabled = true;
        anim.SetTrigger("Death");
        Debug.Log("GameOver");
    }
}
