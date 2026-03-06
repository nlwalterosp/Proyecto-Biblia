using UnityEngine;
using System.Collections;

public class RayosAleatorios : MonoBehaviour
{
    public GameObject[] rayos;
    public float tiempoMin = 4f;
    public float tiempoMax = 10f;
    public float duracionRayo = 0.3f;

    void Start()
    {
        StartCoroutine(Rayos());
    }

    IEnumerator Rayos()
    {
        while (true)
        {
            float espera = Random.Range(tiempoMin, tiempoMax);
            yield return new WaitForSeconds(espera);

            int rayoRandom = Random.Range(0, rayos.Length);

            rayos[rayoRandom].SetActive(true);

            yield return new WaitForSeconds(duracionRayo);

            rayos[rayoRandom].SetActive(false);
        }
    }
}