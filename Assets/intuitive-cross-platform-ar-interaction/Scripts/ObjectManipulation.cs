using UnityEngine;
using System.Collections;
using Normal.Realtime;
using UnityEngine.XR.ARFoundation;
using UnityEngine.EventSystems;
public class ObjectManipulation : MonoBehaviour {
    float rotSpeed = 1000;
    float moveSpeed = 1;

    private Vector3 mousePressCameraLocation;
    private Vector3 mousePressedModelLocation;

    private GameObject arCamera;

    public bool isPhone = false;
    public bool shouldMove = false;
    private RealtimeView      _realtimeView;
    private RealtimeTransform _realtimeTransform;

    private void Awake() 
    {
        _realtimeView      = GetComponent<RealtimeView>();
        _realtimeTransform = GetComponent<RealtimeTransform>();
        arCamera = GameObject.FindObjectOfType<ARCameraManager>()?.gameObject;
        isPhone = arCamera != null;
    }

    private void Update() {
        if (isPhone) 
        {
            for (int i = 0; i < Input.touchCount; ++i)
            {
                if (EventSystem.current.currentSelectedGameObject != null) return;
                if (Input.GetTouch(i).phase == TouchPhase.Began)
                {
                    Debug.Log("Started control");
                    mousePressCameraLocation = arCamera.transform.position;
                    mousePressedModelLocation = transform.position;
                    shouldMove = true;
                } 
                else if (Input.GetTouch(i).phase == TouchPhase.Ended) 
                {
                    Debug.Log("Ended Control");
                    shouldMove = false;
                }
            }

            if (shouldMove) 
            {
                _realtimeView.RequestOwnership();
                _realtimeTransform.RequestOwnership();
                var cameraDiff = arCamera.transform.position - mousePressCameraLocation;
                transform.position = mousePressedModelLocation + cameraDiff;
            }
        } 
        else // Computer
        {
            if (Input.GetMouseButton(0)) 
            {
                _realtimeView.RequestOwnership();
                _realtimeTransform.RequestOwnership();
                float rotX = Input.GetAxis("Mouse X")*rotSpeed*Mathf.Deg2Rad;
                float rotY = Input.GetAxis("Mouse Y")*rotSpeed*Mathf.Deg2Rad;
                transform.Rotate(Vector3.up, -rotX);
                transform.Rotate(Vector3.right, rotY);
            }
        }
    }

    [ContextMenu("Add Physics")]
    public void AddPhsyics() {
        _realtimeView.RequestOwnership();
        _realtimeTransform.RequestOwnership();
        gameObject.AddComponent<Rigidbody>();
        Debug.Log("Added RigidBody");
    }

}