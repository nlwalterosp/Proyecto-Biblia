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

        // 🔥 ocultar TODOS los sprites
        foreach (SpriteRenderer s in sprites)
        {
            s.enabled = false;
        }

        StartCoroutine(ActivarFuego());
    }

    IEnumerator ActivarFuego()
    {
        float delay = Random.Range(0f, 3f);
        yield return new WaitForSeconds(delay);

        // 🔥 mostrar sprites
        foreach (SpriteRenderer s in sprites)
        {
            s.enabled = true;
        }

        // 🔥 reiniciar animación desde 0
        if (anim != null)
        {
            anim.Play("Escala_entrada_animClip", 0, 0f);
        }

        enabled = false;
    }
}
