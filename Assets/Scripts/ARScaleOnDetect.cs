using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ARScaleOnDetect : MonoBehaviour
{
    public ARTrackedImageManager imageManager;
    public Transform modelToScale;

    [Header("Escala del modelo")]
    public float scale = 1.5f; // <- aquí usas decimales

    void OnEnable()
    {
        imageManager.trackedImagesChanged += OnChanged;
    }

    void OnDisable()
    {
        imageManager.trackedImagesChanged -= OnChanged;
    }

    void OnChanged(ARTrackedImagesChangedEventArgs args)
    {
        foreach (var img in args.added)
            ApplyScale(img);

        foreach (var img in args.updated)
            ApplyScale(img);
    }

    void ApplyScale(ARTrackedImage img)
    {
        if (img.trackingState == TrackingState.Tracking)
        {
            // Escala local decimal
            modelToScale.localScale = Vector3.one * scale;
        }
    }
}
