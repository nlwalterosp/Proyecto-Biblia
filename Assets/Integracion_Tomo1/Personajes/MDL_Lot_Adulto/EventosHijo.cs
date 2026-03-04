using UnityEngine;

public class EventosHijo : MonoBehaviour
{
    public MovimientoSimple movimientoPadre;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        movimientoPadre = GetComponentInParent<MovimientoSimple>();
    }
    public void DispararMovimiento()
    {
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);

        float tiempoRestante = (1f - stateInfo.normalizedTime) * stateInfo.length;
        Debug.Log("EVENTO NUEVO PERSONAJE: " + gameObject.name);

        movimientoPadre.EmpezarMover(tiempoRestante);
    }
    public void FinMovimiento()
    {
        movimientoPadre.DetenerMovimiento();
    }

   
}