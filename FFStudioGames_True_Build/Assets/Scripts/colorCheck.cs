using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colorCheck : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public Sprite whiteSprite;
    public Sprite blackSprite;
    

    public int playerColor;
    // 1 = white
    // 2 = black
    
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        Physics2D.IgnoreLayerCollision(6, 9, true);
        Physics2D.IgnoreLayerCollision(7, 10, true);
    }


    void Update()
    {
        colorChange();
        
    }


    void colorChange()
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            if (playerColor == 1)
            {
                spriteRenderer.sprite = blackSprite;
                playerColor = 2;
                gameObject.layer = 7;

            }

        }

        if (Input.GetKey(KeyCode.Alpha2))
        {
            if (playerColor == 2)
            {
                spriteRenderer.sprite = whiteSprite;
                playerColor = 1;
                gameObject.layer = 6;
            }
        }
    }
}