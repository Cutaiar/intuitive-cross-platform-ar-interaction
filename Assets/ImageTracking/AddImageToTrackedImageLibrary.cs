using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.XR.ARFoundation;
public class AddImageToTrackedImageLibrary : MonoBehaviour
{

    public ARTrackedImageManager m_ARTrackedImageManager = null;

    public Texture2D imageToAdd = null;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        yield return new WaitForSeconds(5f);
        Debug.Log("About to add image");
        AddImage(imageToAdd);
    }

    private void AddImage(Texture2D texture) {

        if (m_ARTrackedImageManager.referenceLibrary is MutableRuntimeReferenceImageLibrary mutableLibrary)
        {
            for (int i = 0; i < mutableLibrary.supportedTextureFormatCount;i++) {
                Debug.Log("Texture Format Supported: " + mutableLibrary.GetSupportedTextureFormatAt(i));
            }
            
            //MutableRuntimeReferenceImageLibraryExtensions.ScheduleAddImageJob(mutableLibrary, texture, texture.name, 0.05f);
            var addImageJob =  mutableLibrary.ScheduleAddImageJob(texture, texture.name, 0.05f);
            Debug.Log("Added: " + texture.name + " to the reference library.");
        } 
        else {
            Debug.Log("Failed to add. Supports mutable library: " + m_ARTrackedImageManager.descriptor.supportsMutableLibrary);
        }
    }
}
