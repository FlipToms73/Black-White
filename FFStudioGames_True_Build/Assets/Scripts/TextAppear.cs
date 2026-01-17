using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TextAppear : MonoBehaviour
{
    public GameObject UIObject;
    public GameObject cube;

    private void Start()
    {
        UIObject.SetActive(false);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if  (collision.tag == "Player")
        {
            UIObject.SetActive(true);
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        
        
    }

}
