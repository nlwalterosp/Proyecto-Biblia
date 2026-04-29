using UnityEngine;

public class ResetManager : MonoBehaviour
{
    public ResetSceneObject[] objetosAResetear;

    public void ResetearTodo()
    {
        Debug.Log("FUNCIONA EL BOTON");

        foreach (var obj in objetosAResetear)
        {
            obj.ResetObject();
        }
    }
}