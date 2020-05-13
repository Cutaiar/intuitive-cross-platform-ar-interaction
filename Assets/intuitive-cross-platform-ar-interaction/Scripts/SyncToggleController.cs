using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SyncToggleController : MonoBehaviour
{

    private ObjectManipulation _objm;
    public ObjectManipulation ObjM {
        get {
            if (_objm == null) {
                _objm = FindObjectOfType<ObjectManipulation>();
            }
            return _objm;
        }
    }
    public Toggle toggle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ObjM?.shouldMove ?? false) {
            toggle.isOn = false;
        }
    }
}
