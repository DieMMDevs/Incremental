using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Buying : MonoBehaviour, IPointerDownHandler
{
    GameObject building;
    string buildingName;
    Button myButton;
    Vector3 startV, startScale;
    int buildingCounter = 0;
    string buldingName = "Building ";

	// Use this for initialization
	void Start ()
    {
        myButton = GetComponent<Button>();
        startV = new Vector3(0, 1, 1);
    }

    // Update is called once per frame
    void Update() {
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        switch (myButton.transform.name)
        {
            case "Buy1":
                startScale = new Vector3(1, 1, 1);
                break;
            case "Buy2":
                startScale = new Vector3(1, 2, 1);
                break;
            case "Buy3":
                startScale = new Vector3(2, 2, 1);
                break;
            case "Buy4":
                startScale = new Vector3(2, 3, 1);
                break;
            case "Buy5":
                startScale = new Vector3(2, 3.5f, 2);
                break;
        }

        if(startScale.x % 2 == 0)
        {
            if(startScale.z % 2 == 0)
                startV = new Vector3(startScale.x + 0.5f, startScale.y / 2, startScale.z + 0.5f);
            else
                startV = new Vector3(startScale.x + 0.5f, startScale.y / 2, startScale.z);
        }
        else
        {
            if (startScale.z % 2 == 0)
                startV = new Vector3(startScale.x, startScale.y / 2, startScale.z + 0.5f);
            else
                startV = new Vector3(startScale.x, startScale.y / 2, startScale.z);
        }

        Debug.print("ADD CUBE");
        building = GameObject.CreatePrimitive(PrimitiveType.Cube);
        building.transform.position = startV;
        building.transform.localScale = startScale;
        building.transform.name = buldingName + ++buildingCounter;
        building.AddComponent<TestControle>();
    }
}
