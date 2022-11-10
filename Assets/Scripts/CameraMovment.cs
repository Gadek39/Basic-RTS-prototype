using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovment : MonoBehaviour
{
    [SerializeField] float movmentSpeed;
    [SerializeField] float rotationSpeed;
    [SerializeField] float bounds;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MovmentBounds();
        CameraMovement();
        CameraRotation();
        if (Input.GetKeyDown(KeyCode.M))
        {
            CamReset();
        }
    }
    void MovmentBounds()
    {
        if (transform.position.x > bounds)
        {
            transform.position = new Vector3(bounds,transform.position.y, transform.position.z);
        }
        else if (transform.position.x < -bounds)
        {
            transform.position = new Vector3(-bounds, transform.position.y, transform.position.z);
        }
        
        if (transform.position.z > bounds)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, bounds);
        }
        else if (transform.position.z < -bounds)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -bounds);
        }
    }
    void CameraMovement()
    {
        float xAxis = Input.GetAxis("Horizontal");
        float yAxis = Input.GetAxis("Vertical");

        transform.Translate(new Vector3(xAxis, yAxis) * movmentSpeed * Time.deltaTime);
    }
    void CameraRotation()
    {
        transform.Rotate(Vector3.forward * RotationFactor() * rotationSpeed * Time.deltaTime);
    }
    float RotationFactor()
    {
        float rightTurn;
        float leftTurn;
        if (Input.GetKey(KeyCode.Period))
        {
            rightTurn = 1;
        }
        else
        {
            rightTurn = 0;
        }
        if (Input.GetKey(KeyCode.Comma))
        {
            leftTurn = -1;
        }
        else
        {
            leftTurn = 0;
        }
        float rotationFactor = leftTurn + rightTurn;
        return rotationFactor;
    }
    void CamReset()
    {
        transform.position = new Vector3(0, 15, 0);
        transform.rotation = Quaternion.Euler(90, 0, 0);
    }
}
