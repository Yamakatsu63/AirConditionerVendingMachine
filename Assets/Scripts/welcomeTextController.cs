using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class welcomeTextController : MonoBehaviour
{
    [SerializeField] GameObject welcomeText;
    public bool isStart = false;

    public void OnClick()
    {
        isStart = true;
    }
}
