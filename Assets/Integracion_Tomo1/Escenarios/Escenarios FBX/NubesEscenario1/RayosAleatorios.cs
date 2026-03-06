using UnityEngine;
using System.Collections;

public class RayosAleatorios : MonoBehaviour
{
    public GameObject[] rayos;
    public float tiempoMin = 0.5f;
    public float tiempoMax = 1.2f;
    public float duracionRayo = 0.6f;
    void Start()
    {
        // apagar todos al inicio
        foreach (GameObject r in rayos)
        {
            r.SetActive(false);
        }

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