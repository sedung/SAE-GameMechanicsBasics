using UnityEngine;
using System.Collections;

// The GameObjects collider needs to be a trigger
public class simpleTrigger : MonoBehaviour {

	// Triggered if a rigidbody enters a collider
    void OnTriggerEnter()
    {
        Debug.Log("TriggerEnter");
    }

    // Triggered if a rigidoby exits a collider
    void OnTriggerExit()
    {
    	Debug.Log("TriggerExit")
    }
}
