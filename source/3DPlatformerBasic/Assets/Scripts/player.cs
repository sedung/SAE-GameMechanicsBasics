using UnityEngine;
using System.Collections;

public class player : MonoBehaviour {

    public float speed = 20.0f;
    public float jumpStrength = 8.0f;

    [HideInInspector]public int points = 0;
    public int curHp = 100;
    public int maxHp = 100;

    private GameObject obj_hpbar;

    private Rigidbody rig;
    private UnityEngine.UI.Text txtHp, txtPoints;

    private float distanceToGround = 0;
    
	// Use this for initialization
	void Start () {

        rig = GetComponent<Rigidbody>();
        Collider col = GetComponent<Collider>();

        // Get external gameobject "hp-bar-fg", "txtPoints" & "txtHp" and corresponding UI.Text component
        obj_hpbar = GameObject.Find("hp-bar-fg");
        txtHp = GameObject.Find("txtHp").GetComponent<UnityEngine.UI.Text>();
        txtPoints = GameObject.Find("txtPoints").GetComponent<UnityEngine.UI.Text>();


        // Set distanceToGround to bottom (y-axis) collider bound 
        distanceToGround = col.bounds.extents.y;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        playerMovement();
	}

    // Physic-based (force) rigidbody movement 
    void playerMovement()
    {
        // Movement Sideways
        rig.AddForce(Vector3.right * Input.GetAxis("Horizontal") * speed, ForceMode.Force);

        // Jumping
        if ((Input.GetButtonDown("Jump") || Input.GetAxis("Vertical") > 0) && isGrounded())
        {
            rig.AddForce(Vector3.up * jumpStrength, ForceMode.Impulse);
        }
    }

    // Check if player is in contact with ground
    bool isGrounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up, distanceToGround + 0.1f);
    }

    // Calculate new player health points and trigger an update of the hpbar and txthp
    public void calcHp (int iDmg)
    {
        curHp -= iDmg; // Substract damage from current health points
        float hp = (float)curHp / (float)maxHp; // Example 80 / 100 = 0.8
        // Change object scale based on calculated HealthPoints (Hp) and clamp the values between 0.0 and 1.0
        obj_hpbar.transform.localScale = new Vector3(Mathf.Clamp(hp, 0f, 1f), transform.localScale.y, transform.localScale.z);
        txtHp.text = curHp.ToString() + " HP"; // Set text in text component to current health points
    }
    
    // Update of the txtpoints
    public void calcPoints (int iValue)
    {
        points += iValue;
        txtPoints.text = points.ToString() + " Points";
    }
}
