using UnityEngine;
using System.Collections;

public class playerMovement : MonoBehaviour {

    public float speed = 5.0f;
    public float jumpSpeed = 10.0f;
    public float gravity = 20.0f;

    private Vector3 movement = Vector3.zero;
    private CharacterController controller;

    void Start ()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update ()
    {

        if (controller.isGrounded)
        {
            movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            movement = transform.TransformDirection(movement);
            movement *= speed;
            if (Input.GetButton("Jump"))
            {
                movement.y = jumpSpeed;
            }
             
        }
        movement.y -= gravity * Time.deltaTime; 
        controller.Move(movement * Time.deltaTime);   

	}
}
