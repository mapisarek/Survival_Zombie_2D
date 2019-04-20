using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Statistics : MonoBehaviour
{
    private Image content;
    private float currentFill;
    public float InitMaxValue { get; set; }

    public float CurrentValue
    {
        get
        {
            return currentValue;
        }

        set
        {
            currentValue = value;
        }
    }

    private float currentValue;

    private void Start()
    {
        content = GetComponent<Image>();
    }
}
