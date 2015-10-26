using UnityEngine;
using System.Collections;

public class cubeMovement : MonoBehaviour {

    public float speed = 1.2f;
	
	// Update is called once per frame
	void Update () {

		// Create a temporary Vector3 which will hold our change in position (Ranging from 0.0f to 1.0f).
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        
        // Add the temporary Vector3 to our current object position.
        // Multiply the Vector3 with our speed variable and deltaTime (for Framerate independence).
        this.transform.position += move * speed * Time.deltaTime ;

    }
}
