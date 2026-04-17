using UnityEngine;
using System.Collections;

public class FuegoDelay : MonoBehaviour
{
    Animator anim;
    SpriteRenderer[] sprites;

    void Start()
    {
        anim = GetComponent<Animator>();
        sprites = GetComponentsInChildren<SpriteRenderer>();

        // ocultar fuego al inicio
        foreach (var s in sprites)
        {
            s.enabled = false;
        }

        StartCoroutine(ActivarFuego());
    }

    IEnumerator ActivarFuego()
    {
        float delay = 5f + Random.Range(0f, 1f);
        yield return new WaitForSeconds(delay);

        // mostrar fuego
        foreach (var s in sprites)
        {
            s.enabled = true;
        }

        if (anim != null)
        {
            anim.SetTrigger("Iniciar"); // 🔥 aquí arranca bien
            anim.speed = Random.Range(0.95f, 1.05f);
        }
    }
}