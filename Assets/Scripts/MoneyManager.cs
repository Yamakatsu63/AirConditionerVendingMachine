using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyManager : MonoBehaviour
{
    public int sales;

    private void Start()
    {
        sales = 0;
    }

    public void RenewalSales()
    {
        sales += 500;
    }
}
