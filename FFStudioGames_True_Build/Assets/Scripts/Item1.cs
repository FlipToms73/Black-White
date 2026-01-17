using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item1 : MonoBehaviour
{
    public GameObject text;

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Bruh");
        gameObject.SetActive(false);
        text.SetActive(false);

    }
}
