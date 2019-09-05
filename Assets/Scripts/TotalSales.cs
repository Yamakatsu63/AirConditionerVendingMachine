using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TotalSales : MonoBehaviour
{
    [SerializeField] GameObject MoneyManager;

    public void OnClick()
    {
        GetComponent<Text>().text = MoneyManager.GetComponent<MoneyManager>().sales.ToString() + "円";
    }
}
