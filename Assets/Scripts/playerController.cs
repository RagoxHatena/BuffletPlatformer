using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{

    public float movementSpeed;
    private Vector3 movementDirection;
    public float jumpingForce;
    public float gravScale;
    public CharacterController controller;
    public Animator anim;
    /*public Rigidbody playerBody; */
    public Transform pivotCamera;
    public float rotationSpeed;
    public GameObject playerModel;

    // Start is called before the first frame update
    void Start()
    {
        /*playerBody = GetComponent<Rigidbody>();*/
        controller = GetComponent<CharacterController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        /*playerBody.velocity = new Vector3(Input.GetAxis("Horizontal") * movementSpeed, playerBody.velocity.y, Input.GetAxis("Vertical") * movementSpeed);

        if (Input.GetButtonDown("Jump"))
        {
            playerBody.velocity = new Vector3(playerBody.velocity.x, jumpingForce, playerBody.velocity.z);
        }*/

        // movementDirection = new Vector3(Input.GetAxis("Horizontal") * movementSpeed, movementDirection.y, Input.GetAxis("Vertical") * movementSpeed);
        float yStore = movementDirection.y;
        movementDirection = (transform.forward * Input.GetAxis("Vertical")) + (transform.right * Input.GetAxis("Horizontal"));
        movementDirection = movementDirection.normalized * movementSpeed;
        movementDirection.y = yStore;
        if (controller.isGrounded)
        {
            if (Input.GetButton("Jump") && controller.isGrounded)
            {
                movementDirection.y = jumpingForce;
            }
            else
            {
                movementDirection.y = 0f;
            }            
        }

        movementDirection.y = movementDirection.y + (Physics.gravity.y * gravScale * Time.deltaTime);
        controller.Move(movementDirection * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            movementSpeed = movementSpeed + 3f;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            movementSpeed = movementSpeed - 3f;
        }

        //Move the player in different directions based on Camera Looking Direction.
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            transform.rotation = Quaternion.Euler(0f, pivotCamera.rotation.eulerAngles.y, 0f);
            Quaternion newRotation = Quaternion.LookRotation(new Vector3(movementDirection.x, 0f, movementDirection.z));
            playerModel.transform.rotation = Quaternion.Slerp(playerModel.transform.rotation, newRotation, rotationSpeed * Time.deltaTime);
        }     

        anim.SetBool("isGrounded", controller.isGrounded);
        anim.SetFloat("Speed", (Mathf.Abs(Input.GetAxis("Vertical")) + Mathf.Abs(Input.GetAxis("Horizontal"))));
    }
}
