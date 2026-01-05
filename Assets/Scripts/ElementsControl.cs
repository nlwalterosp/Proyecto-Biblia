using System.Collections;
using UnityEngine;

public class ElementsControl : MonoBehaviour
{
    public GameObject[] elementos;
    public float duracionActivacion;

    private void Awake()
    {
        // Activa los elementos de la escena si no estan activo ya para no perder la referencia.
        for (int i = 0; i < elementos.Length; i++)
        {
            elementos[i].SetActive(true);
        }
    }
    void Start()
    {
        // Desactiva los elementos de la escena para su posterior entrada.
        for (int i = 0; i < elementos.Length; i++)
        {
            elementos[i].SetActive(false);
        }
    }
    void Update()
    {
        StartCoroutine(ActivarElementos()); // Coorrutina para llamar la activacion de los elementos en secuencia.
    }

    IEnumerator ActivarElementos() //Coorrutina para la activacion de los elementos en secuencia a x intervalos de tiempo.
    {
        foreach (GameObject elemento in elementos)
        {
            yield return new WaitForSeconds(duracionActivacion);
            elemento.SetActive(true);
        }
    }
}
