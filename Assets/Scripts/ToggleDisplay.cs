using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleDisplay : MonoBehaviour
{
    [SerializeField] GameObject DisplayForSales;
    [SerializeField] GameObject DisplayForAdmin;
    bool adminOn = false;

    public void OnClick()
    {
        if(adminOn == false)
        {
            DisplayForAdmin.SetActive(true);
            DisplayForSales.SetActive(false);
            adminOn = true;
        }
        else
        {
            DisplayForSales.SetActive(true);
            DisplayForAdmin.SetActive(false);
            adminOn = false;
        }
    }
}
