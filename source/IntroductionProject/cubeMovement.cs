using UnityEngine;
using System.Collections;

public class cubeMovement : MonoBehaviour {

    public float speed = 1.2f;
	
	// Update is called once per frame
	void Update () {

        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        this.transform.position += move * speed * Time.deltaTime ;

        // goo.gl/yKvF3k
    }
}
