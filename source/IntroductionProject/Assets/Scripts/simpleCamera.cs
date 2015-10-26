using UnityEngine;
using System.Collections;

public class simpleCamera : MonoBehaviour {

    public float camSpeed = 1.0f;
	
	// Update is called once per frame
	void Update () {

       transform.Rotate(new Vector3(Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0));

	}
}
