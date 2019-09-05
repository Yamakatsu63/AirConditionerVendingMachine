using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TemperatureController : MonoBehaviour
{
    [SerializeField] GameObject currentTemperatureText;
    //[SerializeField] GameObject putInButton;
    private float timeLeft;
    public float currenTemperature;
    public bool stop = false;
    public string airVolume = "normal"; 

    private void Start()
    {
        timeLeft = 1.0f;

        //現在温度の初期値
        currenTemperature = 30;
    }

    public void OnClickRapidButton()
    {
        airVolume = "rapid";
    }

    public void OnClickLooseButton()
    {
        airVolume = "loose";
    }
    
    // Update is called once per frame
    void Update()
    {
        float presetTempreture = GetComponent<Temperature>().temperature;
        
        timeLeft -= Time.deltaTime;
        if (GetComponent<CalcurateChange>().isStart)
        {
            if (stop)
            {
                
            }
            else if (timeLeft <= 0.0)
            {
                timeLeft = 1.0f;
            
                if (currenTemperature < presetTempreture)
                        {
                    if(airVolume == "rapid")
                    {

                    }
                            currenTemperature += 0.1f;
                        }
                        else if (currenTemperature > presetTempreture)
                        {
                            currenTemperature -= 0.1f;
                        }
            
                        currentTemperatureText.GetComponent<Text>().text = currenTemperature.ToString("F1") + "℃";
                    }
        }
    }
}
