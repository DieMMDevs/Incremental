using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyManagement : MonoBehaviour {
    public static double playerMoney, moneyPerSec = 0;
    float time = 1;  
    
	// Use this for initialization
	void Start () {
        playerMoney = 0;
	}
	
	// Update is called once per frame
	void Update () {
        time -= Time.deltaTime;
        if (time <= 0)
        {
            time = 1;
            playerMoney += moneyPerSec;
            //PlayerMoneyAnzeige.curMoney.text = playerMoney.ToString();

        }
	}

    public void Set(double money)
    {
        playerMoney += money;
    }
    public double Get()
    {
        return playerMoney;
    }
}
