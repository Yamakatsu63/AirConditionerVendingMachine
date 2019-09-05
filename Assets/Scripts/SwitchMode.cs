using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SwitchMode : MonoBehaviour
{
    [SerializeField] GameObject reibouButton;
    [SerializeField] GameObject danbouButton;
    [SerializeField] GameObject text;
    [SerializeField] GameObject DisplayforSales;
    public string Mode = "reibou";
    //[SerializeField] AudioClip clip;

    public void OnClick_reibou()
    {
        reibouButton.GetComponent<Button>().interactable = false;
        danbouButton.GetComponent<Button>().interactable = true;
        text.GetComponent<Text>().text = "冷房";
        Mode = "reibou";
        DisplayforSales.GetComponent<Temperature>().displayTemperature(Mode);
        //GetComponent<AudioSource>().PlayOneShot(clip);
    }
    public void OnClick_danbou()
    {
        reibouButton.GetComponent<Button>().interactable = true;
        danbouButton.GetComponent<Button>().interactable = false;
        text.GetComponent<Text>().text = "暖房";
        Mode = "danbou";
        DisplayforSales.GetComponent<Temperature>().displayTemperature(Mode);
        //GetComponent<AudioSource>().PlayOneShot(clip);
    }
}
