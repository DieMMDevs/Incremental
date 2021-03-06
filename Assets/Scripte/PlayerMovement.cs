﻿using System.Collections;
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
        Debug.print(q);
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
            transform.position += Vector3.forward * (Time.deltaTime * moveSpeed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += Vector3.back * (Time.deltaTime * moveSpeed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left * (Time.deltaTime * moveSpeed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * (Time.deltaTime * moveSpeed);
        }

        /*if (Input.GetKey(KeyCode.W) && z < zMax)
            z += move;
        if (Input.GetKey(KeyCode.S) && z > zMin)
            z -= move;
        if (Input.GetKey(KeyCode.D) && x < xMax)
            x += move;
        if (Input.GetKey(KeyCode.A) && x > xMin)
            x -= move;
        v3.Set(x, y, z);*/


        if (Input.GetKey(KeyCode.Q))
            Debug.print(q);
        Camera.main.transform.rotation.Set(camRotation.x, camRotation.y + rotate, camRotation.z, camRotation.w);
        if (Input.GetKey(KeyCode.E))
            rotation += rotate;
        
        

        //this.transform.rotation.Set(q.x, q.y, q.z, q.w);
        //this.transform.SetPositionAndRotation(v3, q);
    }
}
