using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    Vector3 v3, q;
    Quaternion camRotation;
    float x, y, z, rotation, yMax = 8, yMin = 3.5f, zoom = 10.0f, moveSpeed = 5.0f, rotate = 0.01f;
    //float zMin = -7.0f, zMax = 1.0f, xMin = -3.5f, xMax = 4.5f;
    Camera myCamera;
    
    // Use this for initialization
    void Start()
    {
        //player = GetComponent<GameObject>();
        camRotation = Camera.main.transform.rotation;
        q = Camera.main.transform.eulerAngles;
        rotation = myCamera.transform.rotation.y;
    }

    // Update is called once per frame
    void Update()
    {
        x = this.transform.position.x;
        y = this.transform.position.y;
        z = this.transform.position.z;  
        if (Input.GetAxis("Mouse ScrollWheel") < 0 && y < yMax) transform.position += Vector3.up * (Time.deltaTime * zoom);
        if (Input.GetAxis("Mouse ScrollWheel") > 0 && y > yMin) transform.position += Vector3.down * (Time.deltaTime * zoom);
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += transform.forward * (Time.deltaTime * moveSpeed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += -transform.forward * (Time.deltaTime * moveSpeed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += -transform.right * (Time.deltaTime * moveSpeed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += transform.right * (Time.deltaTime * moveSpeed);
        }

        if (Input.GetKey(KeyCode.Q))
            transform.Rotate(new Vector3(0, -10, 0) * moveSpeed * Time.deltaTime);
        Camera.main.transform.rotation.Set(camRotation.x, camRotation.y + rotate, camRotation.z, camRotation.w);
        if (Input.GetKey(KeyCode.E))
            transform.Rotate(new Vector3(0, 10, 0) * moveSpeed * Time.deltaTime);
    }
}
