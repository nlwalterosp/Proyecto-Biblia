using UnityEngine;

public class MovimientoPorEstado : MonoBehaviour
{
    public float velocidad = 3f;
    public string nombreEstadoMovimiento = "Bake_Lot_Corriendo 1";

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("Corriendo", true);
    }


    void Update()
    {
        bool estaCorriendo = animator.GetBool("Corriendo");

        if (estaCorriendo)
        {
            transform.Translate(transform.right * velocidad * Time.deltaTime, Space.World);
        }
    }
}