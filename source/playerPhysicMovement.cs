using UnityEngine;
using System.Collections;

public class player : MonoBehaviour {

    public float speed = 20.0f;
    public float jumpStrength = 8.0f;

    private Rigidbody rig;

	// Use this for initialization
	void Start () {
        rig = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        // Movement Sideways
        rig.AddForce(Vector3.right * Input.GetAxis("Horizontal") * speed);

        // Jumping
        if (Input.GetButtonDown("Jump"))
        {
            rig.AddForce(Vector3.up * jumpStrength, ForceMode.Impulse);
        }
	}
}
