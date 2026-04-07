using UnityEngine;
using System.Collections;

public class FuegoInicio : MonoBehaviour
{
    Animator anim;

    void Awake() // 🔥 más temprano que Start
    {
        anim = GetComponent<Animator>();

        if (anim != null)
        {
            anim.speed = 0f; // 🔥 congelar ANTES de que arranque
        }
    }

    void Start()
    {
        StartCoroutine(IniciarFuego());
    }

    IEnumerator IniciarFuego()
    {
        yield return new WaitForSeconds(4f); // ⏱ todos esperan 4s

        if (anim != null)
        {
            anim.speed = 1f;

            // 🔥 cada uno en punto distinto
            anim.Play("Escala_entrada_animClip", 0, Random.Range(0f, 1f));
        }

        enabled = false;
    }
}