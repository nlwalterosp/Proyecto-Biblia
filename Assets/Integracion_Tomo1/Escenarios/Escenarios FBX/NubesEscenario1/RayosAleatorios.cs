using UnityEngine;
using System.Collections;

public class RayosAleatorios : MonoBehaviour
{
    public GameObject[] rayos;
    public float tiempoMin = 0.5f;
    public float tiempoMax = 2f;

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

            GameObject rayo = Instantiate(
                rayos[rayoRandom],
                transform.position,
                Quaternion.identity
            );

            Destroy(rayo, 0.5f);
        }
    }
}