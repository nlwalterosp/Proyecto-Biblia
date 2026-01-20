using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ShowTargetOrigin : MonoBehaviour
{
    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(transform.position, 0.01f);

        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, transform.right * 0.1f);

        Gizmos.color = Color.blue;
        Gizmos.DrawRay(transform.position, transform.forward * 0.1f);

        Gizmos.color = Color.yellow;
        Gizmos.DrawRay(transform.position, transform.up * 0.1f);
    }
}
