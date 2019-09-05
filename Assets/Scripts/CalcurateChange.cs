using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CalcurateChange : MonoBehaviour
{
    [SerializeField] GameObject welcomeText;
    [SerializeField] GameObject moneyManager;
    public bool isStart = false;
    public bool returned = false;

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
            welcomeText.GetComponent<Text>().text = "残金は" + change.ToString() + "円です";
        }
    }

    private void Update()
    {
        leftTime += Time.deltaTime;
        if(leftTime >= 10)
        {
            leftTime = 0;
            if (returned)
            {
                GetComponent<TemperatureController>().stop = true;
            }
            if (change < 0)
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
                welcomeText.GetComponent<Text>().text = "残金は" + change.ToString() + "円です";
            }
        }
        if(change >= 0)
        {
            GetComponent<TemperatureController>().stop = false;
        }
    }

    public void OnClickReturnButton()
    {
        if (GetComponent<TemperatureController>().stop)
        {
            if(change > -500 && change < 0)
            {
                change = 500 + change;
                //welcomeText.GetComponent<Text>().text = "おつりは" + change.ToString() + "円です";
                OptimizeChange(change);
            }
        }
        else if(change <= 0)
        {
            return;
        }
        OptimizeChange(change);
        //welcomeText.GetComponent<Text>().text = "おつりは" + change.ToString() + "円です";
        returned = true;
        change = -500;
    }

    private void OptimizeChange(int money)
    {
        int count10000 = 0;
        int count5000 = 0;
        int count1000 = 0;
        int count500 = 0;
        int count100 = 0;

        welcomeText.GetComponent<Text>().text = "おつりは";

        while (money >= 10000)
        {
            count10000++;
            money -= 10000;
        }

        if(count10000 != 0)
        {
            welcomeText.GetComponent<Text>().text += ",10000円札" + count10000 + "枚";
        }

        while (money >= 5000)
        {
            count5000++;
            money -= 5000;
        }

        if (count5000 != 0)
        {
            welcomeText.GetComponent<Text>().text += ",5000円札" + count5000 + "枚";
        }

        while (money >= 1000)
        {
            count1000++;
            money -= 1000;
        }

        if (count1000 != 0)
        {
            welcomeText.GetComponent<Text>().text += ",1000円札" + count1000 + "枚";
        }

        while (money >= 500)
        {
            count500++;
            money -= 500;
        }

        if (count500 != 0)
        {
            welcomeText.GetComponent<Text>().text += ",500円硬貨" + count500 + "枚";
        }

        while (money >= 100)
        {
            count100++;
            money -= 100;
        }

        if (count100 != 0)
        {
            welcomeText.GetComponent<Text>().text += ",100円硬貨" + count100 + "枚";
        }

        welcomeText.GetComponent<Text>().text += "です.";
        if (money != 0)
        {
            Debug.Log("miss");
        }

        //welcomeText.GetComponent<Text>().text = "おつりは10000円札"+ count10000 +"枚，5000円札"+ count5000 + "枚，1000円札"+ count1000 + "枚，500円硬貨" + count500 + "枚，100円硬貨" + count100+ "枚です";

    }

}
