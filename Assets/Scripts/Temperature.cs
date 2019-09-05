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
            temperature++;
        }
        else
        {
            temperature--;
        }
        temperatureText.GetComponent<Text>().text = temperature.ToString() + ".0℃";
    }
}
