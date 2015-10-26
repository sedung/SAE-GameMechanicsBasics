using UnityEngine;
using System.Collections;

public class player : MonoBehaviour {

    public float speed = 20.0f;
    public float jumpStrength = 8.0f;

    [HideInInspector]public int points = 0;
    public int curHp = 100;
    public int maxHp = 100;

    private Rigidbody rig;
    private float distanceToGround = 0;
    
	// Use this for initialization
	void Start () {
        rig = GetComponent<Rigidbody>();
        Collider col = GetComponent<Collider>();
        distanceToGround = col.bounds.extents.y;

	}
	
	// Update is called once per frame
	void FixedUpdate () {
        // Movement Sideways
        rig.AddForce(Vector3.right * Input.GetAxis("Horizontal") * speed, ForceMode.Force);

        // Jumping
        if ( ( Input.GetButtonDown("Jump") || Input.GetAxis("Vertical") > 0 ) && isGrounded() )
        {
            rig.AddForce(Vector3.up * jumpStrength, ForceMode.Impulse);
        }


	}

    bool isGrounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up, distanceToGround + 0.1f);
    }
}
