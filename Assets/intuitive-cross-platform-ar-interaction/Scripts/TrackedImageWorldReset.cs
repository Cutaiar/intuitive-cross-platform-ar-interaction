using UnityEngine;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.XR.ARFoundation;

[RequireComponent(typeof(ARTrackedImageManager))]
[RequireComponent(typeof(ARSessionOrigin))]

public class TrackedImageWorldReset : MonoBehaviour {

    private ARTrackedImageManager m_TrackedImageManager;
    private ARSessionOrigin m_ARSessionOrigin;

    public GameObject m_worldOrigin;
    public float inset = 0.1f;
    public bool resetToImage = true;
    public void setResetToImage(bool b) => resetToImage = b;
    void Awake()
    {
        m_TrackedImageManager = GetComponent<ARTrackedImageManager>();
        m_ARSessionOrigin = GetComponent<ARSessionOrigin>();
    }

    void OnEnable()
    {
        m_TrackedImageManager.trackedImagesChanged += OnTrackedImagesChanged;
    }

    void OnDisable()
    {
        m_TrackedImageManager.trackedImagesChanged -= OnTrackedImagesChanged;
    }

    void OnTrackedImagesChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        if(eventArgs.updated.Count > 0)
        {
            if (!resetToImage) return;
            ARTrackedImage trackedImage = eventArgs.updated[0];
            Transform centerPlaceholder = trackedImage.gameObject.transform.Find("centerPlaceholder");
            Debug.Log("Tracked Image Update: making content appear at " + centerPlaceholder.position);
            Vector3 newPosition = new Vector3(centerPlaceholder.position.x, centerPlaceholder.position.y, centerPlaceholder.position.z + inset);
            Quaternion newRotation = trackedImage.transform.localRotation*Quaternion.Euler(90,0,0);
            m_ARSessionOrigin.MakeContentAppearAt(m_worldOrigin.transform, newPosition, newRotation);
        }
    }
}