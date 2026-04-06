using UnityEngine;
using System.Collections;

public class FuegoDelay : MonoBehaviour
{
    Renderer rend;
    Animator anim;

    void Start()
    {
        rend = GetComponentInChildren<Renderer>();
        anim = GetComponent<Animator>();

        if (rend != null)
            rend.enabled = false; // 🔥 ocultamos visual

        if (anim != null)
            anim.enabled = false; // 🔥 detenemos animación

        StartCoroutine(ActivarFuego());
    }

    IEnumerator ActivarFuego()
    {
        float delay = Random.Range(0f, 3f);
        yield return new WaitForSeconds(delay);

        if (rend != null)
            rend.enabled = true;

        if (anim != null)
            anim.enabled = true;

        enabled = false;
    }
}
