using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
        CameraMovement();
        CameraRotation();
        if (Input.GetKeyDown(KeyCode.M))
        {
            CamReset();
        }
    }
    private void LateUpdate()
    {
        MovmentBounds();

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
        
            transform.Translate(new Vector3(xAxis, 0, yAxis) *   movmentSpeed * Time.deltaTime);
    }
    void CameraRotation()
    {
            transform.Rotate(Vector3.up * RotationFactor() * rotationSpeed);
    }
    float RotationFactor()
    {
        float rightTurn;
        float leftTurn;
        if (Input.GetKeyDown(KeyCode.Period))
        {
            rightTurn = 1;
        }
        else
        {
            rightTurn = 0;
        }
        if (Input.GetKeyDown(KeyCode.Comma))
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
        transform.position = new Vector3(0, 0, 0);
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }
}
