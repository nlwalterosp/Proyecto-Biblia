using UnityEngine;

public class ResetSceneObject : MonoBehaviour
{
    private Vector3 initialPosition;
    private Quaternion initialRotation;
    private Vector3 initialScale;

    void Awake()
    {
        // Guardar estado inicial
        initialPosition = transform.localPosition;
        initialRotation = transform.localRotation;
        initialScale = transform.localScale;
    }

    public void ResetObject()
    {
        transform.localPosition = initialPosition;
        transform.localRotation = initialRotation;
        transform.localScale = initialScale;

        Animator[] animators = GetComponentsInChildren<Animator>(true);

        foreach (Animator anim in animators)
        {
            anim.Rebind();
            anim.Update(0f);
        }

        ParticleSystem[] particles = GetComponentsInChildren<ParticleSystem>(true);

        foreach (ParticleSystem ps in particles)
        {
            ps.Clear();
            ps.Play();
        }

        CambioEstatua[] cambios = GetComponentsInChildren<CambioEstatua>(true);

        foreach (CambioEstatua c in cambios)
        {
            c.Resetear();
        }
    }
}