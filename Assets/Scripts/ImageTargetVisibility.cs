using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ImageTargetVisibility : MonoBehaviour
{
    public ARTrackedImageManager imageManager;

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
            Activar(img, true);

        foreach (var img in args.updated)
            Activar(img, img.trackingState == TrackingState.Tracking);

        foreach (var img in args.removed)
            Activar(img, false);
    }

    void Activar(ARTrackedImage img, bool activo)
    {
        img.gameObject.SetActive(activo);

        Animator[] animators = img.GetComponentsInChildren<Animator>();
        foreach (Animator anim in animators)
        {
            anim.enabled = activo;
            if (activo)
            {
                anim.ResetTrigger("StartAnim");
                anim.SetTrigger("StartAnim");
            }
        }
    }
}
