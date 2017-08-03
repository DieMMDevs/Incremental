using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestControle : MonoBehaviour {
    Vector3 screenPoint, offset, cubePosition, cubeScale;

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GetComponent<Renderer>().material.color = Color.blue;
            Cursor.visible = false;

            cubePosition = GetComponent<Renderer>().transform.position;
            screenPoint = Camera.main.WorldToScreenPoint(cubePosition);
            offset = cubePosition - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
            cubeScale = GetComponent<Renderer>().transform.localScale;
            
        }
    }
    private void OnMouseUp()
    {
        GetComponent<Renderer>().material.color = Color.red;
        Cursor.visible = true;
    }
    private void OnMouseDrag()
    {
        GetComponent<Renderer>().material.color = Color.green;

        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        curPosition.y = cubeScale.y / 2;
        curPosition.z *= 1.5f;
        curPosition.x -= curPosition.x % 1;
        curPosition.z -= curPosition.z % 1;

        if (cubeScale.x % 2 == 0)
            curPosition.x += 0.5f;
        if (cubeScale.z % 2 == 0)
            curPosition.z += 0.5f;
        
        transform.position = curPosition;

        if (Input.GetKeyDown(KeyCode.R))
        {
            Destroy(gameObject);
            Cursor.visible = true;
        }

    }

    private void OnDestroy()
    {
        Debug.print("Deleted!!");
    }
}