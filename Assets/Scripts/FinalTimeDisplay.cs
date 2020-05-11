using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalTimeDisplay : MonoBehaviour
{
    [SerializeField] GameObject timeDisplay;
    private TimeManager timeManager;
    private Text finalTimeText;
    private GameObject totalsTrackerObject;
    private TotalsTracker totalsTracker;
    // Start is called before the first frame update
    void Start()
    {
        timeManager = timeDisplay.GetComponent<TimeManager>();
        finalTimeText = GetComponent<Text>();
        totalsTrackerObject = GameObject.FindGameObjectWithTag("TotalsTracker");
        totalsTracker = totalsTrackerObject.GetComponent<TotalsTracker>();
    }

    internal void ShowFinalTime()
    {
        finalTimeText.text = $"Mission Time: {timeManager.TimePassedString}";
        totalsTracker.TotalTime += timeManager.TimePassed;
    }
}
