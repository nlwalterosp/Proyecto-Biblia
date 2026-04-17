using UnityEngine;
using System.Collections;

public class RayosAleatorios : MonoBehaviour
{
    public GameObject[] rayos;
    public Transform[] puntosRayo;

    public float primerRayo = 2f;
    public float tiempoMin = 4f;
    public float tiempoMax = 10f;
    

    public float duracionRayo = 0.15f;
    public bool permitirRayos = true;

    void Start()
    {
        StartCoroutine(Tormenta());
    }

    IEnumerator Tormenta()
    {
        // Primer rayo rápido
        yield return new WaitForSeconds(primerRayo);

        while (true)
        {
            // 👇 SOLO agrega esto
            if (!permitirRayos)
            {
                yield return null;
                continue;
            }

            int rayoRandom = Random.Range(0, rayos.Length);
            Transform punto = puntosRayo[Random.Range(0, puntosRayo.Length)];
            rayos[rayoRandom].transform.position = punto.position;

            rayos[rayoRandom].SetActive(true);
            yield return new WaitForSeconds(duracionRayo);
            rayos[rayoRandom].SetActive(false);

            // Posible segundo rayo
            if (Random.value > 0.6f)
            {
                yield return new WaitForSeconds(0.2f);

                int otroRayo = Random.Range(0, rayos.Length);
                Transform punto2 = puntosRayo[Random.Range(0, puntosRayo.Length)];
                rayos[otroRayo].transform.position = punto2.position;

                rayos[otroRayo].SetActive(true);
                yield return new WaitForSeconds(duracionRayo);
                rayos[otroRayo].SetActive(false);
            }

            float espera = Random.Range(tiempoMin, tiempoMax);
            yield return new WaitForSeconds(espera);
        }
    }
}