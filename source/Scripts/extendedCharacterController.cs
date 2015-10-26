using UnityEngine;
using System.Collections;

public class extendedCharacterController : MonoBehaviour
{
    public float speed; //Character's maximum horizontal speed.
    public float jumpSpeed; //Character's initial jump speed.
    public float gravity; //Gravity.

    private bool grounded, aerial = false;
    private bool isJumping = false;
    private Vector3 moveDirection = Vector3.zero; //The XYZ vectors of the movement direction
    private float doubleJumpTime; //Time when double jumping is allowed
    private bool doubleJumpOK, doubleJumpComplete, isDoubleJumping = false; //Checks if double jump is allowed and if player has double jumped
    private bool wallJumpOK, wallJumpComplete, isWallJumping = false; //Checks if wall jump is allowed and if player has wall jumped
    private RaycastHit rayHit;
    private Transform playerGraphic;

    void Update() //This function runs every second.
    {
        movementCode();
    }

    //Physics update
    void FixedUpdate()
    {
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        if (Physics.Raycast(transform.position, fwd, out rayHit, 1.5f))
        {
            if (rayHit.transform.CompareTag("Wall"))
            {
                print("There is a wall here.");

                //Enables wall jump
                {
                    //If the current time is greater than the double jump minimum time, and the player is not on the ground:
                    if (aerial && Time.time > doubleJumpTime && !isDoubleJumping && moveDirection.z != 0 && !wallJumpComplete)
                    {
                        doubleJumpOK = false;
                        wallJumpOK = true; //wall jumps are allowed.
                    }
                }
            }
        }
    }

    void movementCode()
    {
        //Set the character controller to a var called controller.
        CharacterController controller = GetComponent<CharacterController>();

        //Checks grounded behavior
        if (controller.isGrounded)
        {
            //Resets conditions of the player's movement status.
            grounded = true;
            aerial = false;
            doubleJumpOK = false;
            isDoubleJumping = false;
            doubleJumpComplete = false;
            wallJumpOK = false;
            isWallJumping = false;
            wallJumpComplete = false;

            //Gets X and Z axis input to determine which way to move, then move.
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, 0);
            moveDirection *= speed;
        }

        //Checks aerial behavior
        if (!controller.isGrounded)
        {
            aerial = true;
            moveDirection.x = Input.GetAxis("Horizontal") * speed; //Sets the value of the horizontal direction vector to the same as the speed based on direction. 
            moveDirection.y -= gravity * Time.deltaTime; //Adds gravity while in the air, using the formula "newmovedirection.y = movedirection.y - (gravity*Time.deltaTime)"
            moveDirection.z = 0; /*Input.GetAxis("Vertical") * speed; */

            //Checks if you may double jump
            {
                //If the current time is greater than the double jump minimum time and the player is not on the ground:
                if (moveDirection.y > 0 && Time.time > doubleJumpTime && !doubleJumpComplete && !wallJumpOK)
                    //double jumps are allowed.
                    doubleJumpOK = true;
            }

            //Checks if you're falling
            if (moveDirection.y < 0)
            {
                //resets all jumping types to false.
                isJumping = false;
                isDoubleJumping = false;
                isWallJumping = false;
            }
        }

        //Enables single jump behavior
        if (Input.GetButton("Jump") && controller.isGrounded) //When you jump on the ground:
        {
            isJumping = true;
            singleJump(controller); //Run the "Single Jump" function
        }

        //Enables double jump behavior
        if (Input.GetButton("Jump") && !wallJumpOK && !isWallJumping && doubleJumpOK && !doubleJumpComplete)  //When you jump in the air:
        {
            isJumping = false;
            isDoubleJumping = true;
            doubleJump(controller); //Run the "Double Jump" function
        }

        //Enables wall jump behavior
        if (Input.GetButton("Jump") && wallJumpOK && !wallJumpComplete && aerial)  //When you jump in the air:
        {
            isJumping = false;
            isWallJumping = true;
            wallJump(controller); //Run the "Wall Jump" function
        }

        controller.Move(moveDirection * Time.deltaTime); //Moves the controller while you are in the air.
    }

    void singleJump(CharacterController controller)
    {
        //Before you jump, set up the following
        if (controller.isGrounded)
        {
            grounded = false;
            aerial = true;
            doubleJumpTime = Time.time + 0.25f; //Allows a double jump after a quarter of a second.
            moveDirection.y = jumpSpeed; //Sets initial jump speed
        }
    }

    void doubleJump(CharacterController controller)
    {
        moveDirection.y = jumpSpeed; //Adds the extra double jump velocity.
        doubleJumpOK = false; //You may not double jump any more.
        doubleJumpComplete = true; //You have already double jumped.
    }

    void wallJump(CharacterController controller)
    {
        moveDirection.y = jumpSpeed; //Adds the wall jump velocity.
        moveDirection.z = -20.0f;
        wallJumpOK = false; //You may not wall jump any more.
        wallJumpComplete = true; //You have already wall jumped.
    }

}