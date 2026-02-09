using UnityEngine;
using System;
using System.Collections;

public class Bola_Fuego : MonoBehaviour
{
    [SerializeField] float velocidad;
    [SerializeField] float translacion;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * velocidad * Time.deltaTime);
        transform.Translate(Vector3.right * translacion * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Suelo"))
        {
           
            Destroy(gameObject);
        }
    }
}
