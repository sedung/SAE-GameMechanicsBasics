using UnityEngine;
using System.Collections;

public class cursorLock : MonoBehaviour {

	// Update is called once per frame
	void Update () {

        // If left mouse button is clicked
        if (Input.GetMouseButton(0))
        {
            Cursor.lockState = CursorLockMode.Locked; // Lock coursor in game window
            Cursor.visible = false; // Set coursor invisible
        }
        // If ESC key is down
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None; // Unlock coursor in game window
            Cursor.visible = true; // Set coursor visible
        }

    }
}
