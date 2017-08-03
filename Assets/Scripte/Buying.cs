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
    double buildingCosts, buildingMoneyPerSec;

    

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
                buildingCosts = 50;
                buildingMoneyPerSec = 1;
                break;
            case "Buy2":
                startScale = new Vector3(1, 2, 1);
                buildingCosts = 90;
                buildingMoneyPerSec = 1.5f;
                break;
            case "Buy3":
                startScale = new Vector3(2, 2, 1);
                buildingCosts = 290;
                buildingMoneyPerSec = 5;
                break;
            case "Buy4":
                startScale = new Vector3(2, 3, 1);
                buildingCosts = 1450;
                buildingMoneyPerSec = 20;
                break;
            case "Buy5":
                startScale = new Vector3(2, 3.5f, 2);
                buildingCosts = 12450;
                buildingMoneyPerSec = 150;
                break;
        }

        MoneyManagement.playerMoney -= buildingCosts;
        MoneyManagement.moneyPerSec += buildingMoneyPerSec;

        Debug.Log(MoneyManagement.playerMoney);
        Debug.Log(MoneyManagement.moneyPerSec);

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

        Debug.Log("ADD CUBE");
        building = GameObject.CreatePrimitive(PrimitiveType.Cube);
        building.transform.position = startV;
        building.transform.localScale = startScale;
        building.transform.name = buldingName + ++buildingCounter;
        building.AddComponent<TestControle>();
    }
}
