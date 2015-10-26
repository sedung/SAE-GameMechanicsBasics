using UnityEngine;
using System.Collections;

public class enemy : MonoBehaviour {

    public int dmg = 20;

    private player ply; 

	// Use this for initialization
	void Start () {
        // Get hpBar component of the player object
        ply = GameObject.Find("Player").GetComponent<player>();
	}
	
    // On Collision with another collisder
	void OnCollisionEnter()
    {
        ply.calcHp(dmg);
    }
}
