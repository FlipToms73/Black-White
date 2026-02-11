using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextFadeOut : MonoBehaviour
{
    [SerializeField] private GameObject text;

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Bruh");
        text.SetActive(true);

    }
}
