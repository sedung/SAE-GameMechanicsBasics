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
	void OnCollisionEnter(Collision col)
    {
        if(col.transform.name == "Player")
            ply.calcHp(dmg);
    }
}
