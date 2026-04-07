using UnityEngine;

public class FuegoRandomOffset : MonoBehaviour
{
    void Start()
    {
        Animator anim = GetComponent<Animator>();

        if (anim != null)
        {
            anim.Play("Escala_entrada_animClip", 0, Random.Range(0f, 1f));
        }
    }
}