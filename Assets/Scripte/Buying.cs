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
        }

        Debug.print("ADD CUBE");
        building = GameObject.CreatePrimitive(PrimitiveType.Cube);
        building.transform.position = startV;
        building.transform.localScale = startScale;
        building.transform.name = buldingName + ++buildingCounter;
        building.AddComponent<TestControle>();
    }
}
