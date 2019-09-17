using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{
    public Transform target;
    public Transform targetHead;
    public Vector3 offset;
    public bool useOffset;
    public float rotationSpeed;
    public Transform pivotCamera;
    public bool cameraRotation;

    // Start is called before the first frame update
    void Start()
    {
        if (useOffset)
        {
            offset = target.position - transform.position;
        }
        pivotCamera.transform.position = target.transform.position;
        //pivotCamera.transform.parent = target.transform;
        pivotCamera.transform.parent = null;

        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        // To look around in a fancy way, still experimental.
        /*if (!Input.GetKey(KeyCode.Z))
        {
            //Y axis rotation for Player
            float horizontal = Input.GetAxis("Mouse X") * rotationSpeed;
            target.Rotate(0, horizontal, 0);
            //Y axis rotation for Camera
            float vertical = -Input.GetAxis("Mouse Y") * rotationSpeed;
            //target.Rotate(vertical, 0, 0);
            pivotCamera.Rotate(vertical, 0, 0);
            float desiredY = target.eulerAngles.y;
            float desiredX = pivotCamera.eulerAngles.x;
            Quaternion rotation = Quaternion.Euler(desiredX, desiredY, 0);
            transform.position = target.position - (rotation * offset);

        }
        else
        {
            //Y axis rotation for Player
            float horizontal = Input.GetAxis("Mouse X") * rotationSpeed;
            pivotCamera.Rotate(0, horizontal, 0);
            //Y axis rotation for Camera
            float vertical = -Input.GetAxis("Mouse Y") * rotationSpeed;
            //target.Rotate(vertical, 0, 0);
            pivotCamera.Rotate(vertical, 0, 0);
            float desiredY = pivotCamera.eulerAngles.y;
            float desiredX = pivotCamera.eulerAngles.x;
            Quaternion rotation = Quaternion.Euler(desiredX, desiredY, 0);
            transform.position = target.position - (rotation * offset);
        }*/

        pivotCamera.transform.position = target.transform.position;

        //Y axis rotation for Player
        float horizontal = Input.GetAxis("Mouse X") * rotationSpeed;
        pivotCamera.Rotate(0, horizontal, 0);

        //Y axis rotation for Camera
        float vertical = -Input.GetAxis("Mouse Y") * rotationSpeed;
        //target.Rotate(vertical, 0, 0);
        pivotCamera.Rotate(vertical, 0, 0);

        if(pivotCamera.rotation.eulerAngles.x > 45f && pivotCamera.rotation.eulerAngles.x < 180f)
        {
            pivotCamera.rotation = Quaternion.Euler(45f, pivotCamera.rotation.eulerAngles.y, 0);
        }

        //if (pivotCamera.rotation.eulerAngles.x > 180f && pivotCamera.rotation.eulerAngles.x < 315f)
        //{
        //    pivotCamera.rotation = Quaternion.Euler(315f, 0, 0);
        //}

        if (pivotCamera.rotation.eulerAngles.x > 180f && pivotCamera.rotation.eulerAngles.x < 345f)
        {
            pivotCamera.rotation = Quaternion.Euler(345f, pivotCamera.rotation.eulerAngles.y, 0);
        }

        // Rotate Camera
        float desiredY = pivotCamera.eulerAngles.y;
        float desiredX = pivotCamera.eulerAngles.x;
        Quaternion rotation = Quaternion.Euler(desiredX, desiredY, 0);
        transform.position = target.position - (rotation * offset);

        if(transform.position.y < target.position.y + 0.5f)
        {
            transform.position = new Vector3(transform.position.x, target.position.y + 0.5f, transform.position.z);
        }

        // transform.position = target.position - offset;
        transform.LookAt(target);
    }
}
