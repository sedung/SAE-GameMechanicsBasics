using UnityEngine;
using System.Collections;

public class cubeMovement : MonoBehaviour {

    public float speedForward = 10.0f;
    public float speedSideway = 7.5f;

    private Rigidbody rig;

    void Start()
    {
        // Get rigidbody on script initialisation.
        rig = GetComponent<Rigidbody>();
    }

    void Update ()
    {
        // Roate object based on mouse input axis.
        transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X") * 5 * Time.deltaTime, 0));
    }

	// Update is called once per frame.
	void FixedUpdate () {

        // Move object based on added force
        rig.AddForce(Vector3.forward * Input.GetAxis("Vertical") * speedForward, ForceMode.Acceleration);
        rig.AddForce(Vector3.right * Input.GetAxis("Horizontal") * speedSideway);

    }
}
