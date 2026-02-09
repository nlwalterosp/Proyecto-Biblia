using UnityEngine;
using System;
using System.Collections;
public class Tigger_Suelo : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BolaFuego"))
        {
            Debug.Log("Bola colisiono");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("BolaFuego"))
        {
            Debug.Log("Bola_Fuego_Esta");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("BolaFuego"))
        {
            Debug.Log("Bola Fuego murio");
        }
    }
}
