using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CalcurateChange : MonoBehaviour
{
    [SerializeField] GameObject welcomeText;
    [SerializeField] GameObject moneyManager;
    public bool isStart = false;

    public int charge = 500;
    public int change = -500;

    private float leftTime;

    private void Start()
    {
        leftTime = 0;
    }

    public void OnClick100()
    {
        change += 100;
        DisplayText();
    }

    public void OnClick500()
    {
        change += 500;
        DisplayText();
    }

    public void OnClick1000()
    {
        change += 1000;
        DisplayText();
    }

    public void OnClick5000()
    {
        change += 5000;
        DisplayText();
    }

    public void OnClick10000()
    {
        change += 10000;
        DisplayText();
    }

    private void DisplayText()
    {
        if(change < 0)
        {
            int lack = -1 * change;
            welcomeText.GetComponent<Text>().text = lack.ToString() + "円足りません";
        }
        else
        {
            if (!isStart)
            {
                isStart = true;
                moneyManager.GetComponent<MoneyManager>().RenewalSales();
            }
            welcomeText.GetComponent<Text>().text = "おつりは" + change.ToString() + "円です";
        }
    }

    private void Update()
    {
        leftTime += Time.deltaTime;
        if(leftTime >= 10)
        {
            leftTime = 0;
            if(change < 0)
            {
                return;
            }
            change -= 500;
            moneyManager.GetComponent<MoneyManager>().RenewalSales();
            if(change < 0)
            {
                int lack = -1 * change;
                welcomeText.GetComponent<Text>().text = lack.ToString() + "円足りません";
                GetComponent<TemperatureController>().stop = true;
            }
            else
            {
                welcomeText.GetComponent<Text>().text = "おつりは" + change.ToString() + "円です";
            }
        }
        if(change >= 0)
        {
            GetComponent<TemperatureController>().stop = false;
        }
    }

}
