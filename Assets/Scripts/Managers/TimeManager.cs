using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    private Text timeText;
    private double timePassed;
    private string timePassedString;
    [SerializeField] double starterTime = 0;
    [SerializeField] int decimalPlaces = 2;
    // Start is called before the first frame update
    void Start()
    {
        timeText = GetComponent<Text>();
        timePassed = starterTime;
    }

    // Update is called once per frame
    void Update()
    {
        timePassed += System.Math.Round(Time.deltaTime, decimalPlaces);
        timePassedString = timePassed.ToString($"F{decimalPlaces}", CultureInfo.InvariantCulture);
        timeText.text = timePassedString;
    }

    internal string TimePassedString { get { return timePassedString; } }

    internal double TimePassed { get { return timePassed; } }
}
