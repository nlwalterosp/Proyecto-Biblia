using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instanciador_Bola_Fuego : MonoBehaviour
{
    [SerializeField] GameObject bolaFuego;
    [SerializeField] float tiempoEntreRafagas = 1f;

    // 👇 ESTO ES NUEVO - PON AQUÍ TUS COORDENADAS MANUALMENTE
    [SerializeField] float posX = 1.5f;
    [SerializeField] float posY = 0.5f;
    [SerializeField] float posZ = -2.4f;

    [SerializeField] int meteorosPorRafaga = 5;
    [SerializeField] float radioDeDispersion = 1f;
    [SerializeField] float alturaMinima = 0.5f;
    [SerializeField] float alturaMaxima = 2f;

    void Start()
    {
        InvokeRepeating("InstanciarRafagaMeteoros", 0, tiempoEntreRafagas);
    }

    void InstanciarRafagaMeteoros()
    {
        for (int i = 0; i < meteorosPorRafaga; i++)
        {
            InstanciarUnMeteoro();
        }
    }

    void InstanciarUnMeteoro()
    {
        // 👇 POSICIÓN FIJA - CAMBIA ESTOS NÚMEROS A TU GUSTO
        Vector3 posicionBase = new Vector3(posX, posY, posZ);

        Vector2 circuloAleatorio = Random.insideUnitCircle * radioDeDispersion;

        Vector3 posicionFinal = new Vector3(
            posicionBase.x + circuloAleatorio.x,
            posicionBase.y + Random.Range(alturaMinima, alturaMaxima),
            posicionBase.z + circuloAleatorio.y
        );

        Instantiate(bolaFuego, posicionFinal, Quaternion.identity);
    }
}