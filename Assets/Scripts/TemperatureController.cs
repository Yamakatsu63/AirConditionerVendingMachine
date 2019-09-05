using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TemperatureController : MonoBehaviour
{
    [SerializeField] GameObject currentTemperatureText;
    [SerializeField] GameObject airVolumeText;
    private float timeLeft;
    public float currenTemperature;
    public bool stop = false;
    public string airVolume; 

    private void Start()
    {
        timeLeft = 1.0f;

        //現在温度の初期値
        currenTemperature = 30;

        //風量の初期値
        airVolume = "loose";
    }

    public void OnClickRapidButton()
    {
        airVolume = "rapid";
        airVolumeText.GetComponent<Text>().text = "急";
    }

    public void OnClickLooseButton()
    {
        airVolume = "loose";
        airVolumeText.GetComponent<Text>().text = "緩";
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
            else if (timeLeft <= 0.0f)
            {
                timeLeft = 1.0f;
            
                if (currenTemperature < presetTempreture)
                {
                    if(airVolume == "rapid")
                    {
                        currenTemperature += 0.3f;
                    }
                    else if(airVolume == "loose")
                    {
                        currenTemperature += 0.1f;
                    }
                }
                else if (currenTemperature > presetTempreture)
                {
                    if(airVolume == "rapid")
                    {
                        currenTemperature -= 0.3f;
                    }
                    else if(airVolume == "loose")
                    {
                        currenTemperature -= 0.1f;
                    }
                }

                currentTemperatureText.GetComponent<Text>().text = currenTemperature.ToString("F1") + "℃";
            }
        }
    }
}
