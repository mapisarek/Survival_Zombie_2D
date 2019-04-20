using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Statistics : MonoBehaviour
{
    private Image content;
    private float currentFill;
    public float InitMaxValue { get; set; }
    private float currentValue;


    public float CurrentValue
    {
        get
        {
            return currentValue;
        }

        set
        {
            if (value > InitMaxValue)
            {
                currentValue = InitMaxValue;
            }
            else if(value < 0)
            {
                currentValue = 0;
            }
            else
            {
                currentValue = value;
            }
        }
    }

    
    private void Start()
    {
        content = GetComponent<Image>();
    }
    
    public void Initialize(float currentValue, float maxValue)
    {
        InitMaxValue = maxValue;
        CurrentValue = currentValue;
    }
}
