using UnityEngine;
using System.Collections;

public class cursorLock : MonoBehaviour {

	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButton(0))
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

    }
}
