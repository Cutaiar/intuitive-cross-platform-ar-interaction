using UnityEngine;
using Normal.Realtime;

public class KickoffSyncedMonkey : MonoBehaviour
{
    private Realtime _realtime;

    private GameObject monkey;

    private void Awake()
    {
        // Get the Realtime component on this game object
        _realtime = GetComponent<Realtime>();

        // Notify us when Realtime successfully connects to the room
        _realtime.didConnectToRoom += DidConnectToRoom;
    }

    private void DidConnectToRoom(Realtime realtime)
    {
        if (realtime.clientID != 0) return;                             // Only instantiate if we are the host. 
        monkey = Realtime.Instantiate("SyncedMonkey",               // Prefab name
                            position: new Vector3(0, 0, 0.1f),          // Start at 0
                            rotation: Quaternion.identity,              // No rotation
                       ownedByClient: true,                             // Make sure the RealtimeView on this prefab is owned by this client
            preventOwnershipTakeover: false,                            // Prevent other clients from calling RequestOwnership() on the root RealtimeView.
                         useInstance: realtime);                        // Use the instance of Realtime that fired the didConnectToRoom event.

    }

    public void AddPhysics() {
        var monkeyInScene = FindObjectOfType<ObjectManipulation>();
        monkeyInScene.AddPhsyics();
    }
}
