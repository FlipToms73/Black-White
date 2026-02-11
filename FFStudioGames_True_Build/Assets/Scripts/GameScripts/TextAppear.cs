using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TextAppear : MonoBehaviour
{
    [SerializeField] private GameObject UIObject;

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
}
