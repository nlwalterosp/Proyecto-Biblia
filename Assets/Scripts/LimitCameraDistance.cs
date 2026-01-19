using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class LimitCameraDistance : MonoBehaviour
{
    ARTrackedImageManager manager;
    Transform target;

    public float minDistance = 0.25f;
    public float maxDistance = 0.85f;

    void Awake()
    {
        manager = FindObjectOfType<ARTrackedImageManager>();
    }

    void OnEnable()
    {
        manager.trackedImagesChanged += OnChanged;
    }

    void OnDisable()
    {
        manager.trackedImagesChanged -= OnChanged;
    }

    void OnChanged(ARTrackedImagesChangedEventArgs args)
    {
        foreach (var added in args.added)
            target = added.transform; // <-- AUTO ASIGNA EL TARGET

        foreach (var updated in args.updated)
            target = updated.transform;
    }

    void LateUpdate()
    {
        if (target == null) return;

        float dist = Vector3.Distance(transform.position, target.position);

        if (dist < minDistance)
        {
            Vector3 dir = (transform.position - target.position).normalized;
            transform.position = target.position + dir * minDistance;
        }
        else if (dist > maxDistance)
        {
            Vector3 dir = (transform.position - target.position).normalized;
            transform.position = target.position + dir * maxDistance;
        }
    }
}
