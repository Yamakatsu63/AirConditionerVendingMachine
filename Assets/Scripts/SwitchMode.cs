﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SwitchMode : MonoBehaviour
{
    [SerializeField] GameObject reibouButton;
    [SerializeField] GameObject danbouButton;
    [SerializeField] GameObject text;
    //[SerializeField] AudioClip clip;

    public void OnClick_reibou()
    {
        reibouButton.GetComponent<Button>().interactable = false;
        danbouButton.GetComponent<Button>().interactable = true;
        text.GetComponent<Text>().text = "冷房";
        //GetComponent<AudioSource>().PlayOneShot(clip);
    }
    public void OnClick_danbou()
    {
        reibouButton.GetComponent<Button>().interactable = true;
        danbouButton.GetComponent<Button>().interactable = false;
        text.GetComponent<Text>().text = "暖房";
        //GetComponent<AudioSource>().PlayOneShot(clip);
    }
}
