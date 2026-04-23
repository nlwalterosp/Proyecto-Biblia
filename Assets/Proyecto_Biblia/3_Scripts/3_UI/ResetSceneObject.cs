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
        // 🔄 Reset del objeto principal
        transform.localPosition = initialPosition;
        transform.localRotation = initialRotation;
        transform.localScale = initialScale;

        // 🔥 Reset de TODAS las animaciones (incluye hijos)
        Animator[] animators = GetComponentsInChildren<Animator>();

        foreach (Animator anim in animators)
        {
            anim.Rebind();
            anim.Update(0f);
        }

        // 🔥 Reset de partículas (fuego, efectos)
        ParticleSystem[] particles = GetComponentsInChildren<ParticleSystem>();

        foreach (ParticleSystem ps in particles)
        {
            ps.Clear();
            ps.Play();
        }
    }
}