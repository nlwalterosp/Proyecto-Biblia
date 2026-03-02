using UnityEngine;

public class EventosHijo : MonoBehaviour
{
    public MovimientoSimple movimientoPadre;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void DispararMovimiento()
    {
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);

        float tiempoRestante = (1f - stateInfo.normalizedTime) * stateInfo.length;

        movimientoPadre.EmpezarMover(tiempoRestante);
    }
    public void FinMovimiento()
    {
        movimientoPadre.DetenerMovimiento();
    }
}