using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Temperature : MonoBehaviour
{
    [SerializeField] GameObject upButton;
    [SerializeField] GameObject downButton;
    [SerializeField] GameObject temperatureText;
    public float temperature;
    private float upperLimit = 30.0f;
    private float lowerLimit = 18.0f;
    private float initialTempHeat = 24.0f;
    private float initialTempCool = 26.0f;
    private void Start()
    {
        temperature = 26.0f;
    }
    public void OnClick_up()
    {
        ChangeTemperature("up");
    }
    public void OnClick_down()
    {
        ChangeTemperature("down");
    }
    private void ChangeTemperature(string change)
    {
        if (change == "up")
        {
            if (temperature < upperLimit)
                temperature++;
        }
        else
        {
            if (temperature > lowerLimit)
            temperature--;
        }
        temperatureText.GetComponent<Text>().text = temperature.ToString() + ".0℃";
    }

    public void displayTemperature(string Mode)
    {
        if (Mode == "reibou")
        {
            temperature = initialTempCool;
            temperatureText.GetComponent<Text>().text = temperature.ToString() + ".0℃";
        }
        else
        {
            temperature = initialTempHeat;
            temperatureText.GetComponent<Text>().text = temperature.ToString() + ".0℃";
        }
    }
}
