using UnityEngine;
using System.Collections;

public class cubeMovement : MonoBehaviour {

    public float speedForward = 10.0f;
    public float speedSideway = 7.5f;
    public float jumpStrength = 2.0f;

    void Update ()
    {
        // Roate object
        transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X") * 5 * Time.deltaTime, 0));
    }

	// Update is called once per frame
	void FixedUpdate () {

        Rigidbody rig = GetComponent<Rigidbody>();
        // Move object based on added force
        rig.AddForce(Vector3.forward * Input.GetAxis("Vertical") * speedForward, ForceMode.Acceleration);
        rig.AddForce(Vector3.right * Input.GetAxis("Horizontal") * speedSideway);
        
        if(Input.GetButtonDown("Jump"))
        {
            Debug.Log("JUMP");
            rig.AddForce(Vector3.up * jumpStrength, ForceMode.Impulse);    
        }

    }
}
