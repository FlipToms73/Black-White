using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorCheck : MonoBehaviour
{
    //*************COLLISION_CHECK_BY_LAYERS*********
    //------------------Pensar se juntamos ao PlayerManager----------------------------
    [SerializeField] private Sprite whiteSprite;
    [SerializeField] private Sprite blackSprite;
 
    private SpriteRenderer spriteRenderer;
    
    // 1 = white
    // 2 = black
    private int playerColor;
    
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