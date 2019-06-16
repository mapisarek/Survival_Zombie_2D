using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Statistics : MonoBehaviour, IStatistics
{
    [SerializeField]
    private float lerpSpeed;
    private Image content;
    private float currentFill;
    public float InitMaxValue { get; set; }
    private float currentValue;
    StatisticsInitalizer statisticsInitalizer;


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
            else if (value < 0)
            {
                currentValue = 0;
            }
            else
            {
                currentValue = value;
            }
            currentFill = CurrentValue / InitMaxValue;
        }
    }

    public float CurrentFill { get => currentFill; set => currentFill = value; }

    private void Start()
    {
        content = GetComponent<Image>();
    }

    private void Awake()
    {
        statisticsInitalizer = new StatisticsInitalizer();
    }

    public void Initialize(float currentValue, float maxValue)
    {
        InitMaxValue = maxValue;
        CurrentValue = currentValue;
    }

    public void Update()
    {
        if (currentFill != content.fillAmount)
        {
            content.fillAmount = Mathf.Lerp(content.fillAmount, currentFill, Time.deltaTime * lerpSpeed);
        }
    }
}

public class StatisticsInitalizer
{
    public void Initalize(float currentValue, float maxValue, IStatistics statistics)
    {
        if (currentValue <= maxValue)
        {
            statistics.CurrentValue = currentValue;
            statistics.InitMaxValue = maxValue;
            if (statistics.CurrentValue <= 0)
            {
                statistics.CurrentValue = 0;
            }
        }
        else
        {
            statistics.CurrentValue = maxValue;
            statistics.InitMaxValue = maxValue;
        }
    }
}