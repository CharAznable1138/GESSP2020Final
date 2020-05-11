using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Globalization;

public class TotalsDisplay : MonoBehaviour
{
    private GameObject totalsTrackerObject;
    private TotalsTracker totalsTracker;
    [SerializeField] GameObject totalDamage;
    [SerializeField] GameObject totalTime;
    private Text totalDamageText;
    private Text totalTimeText;
    private string totalTimeString;
    [SerializeField] GameObject avgDamage;
    [SerializeField] GameObject avgTime;
    private Text avgDamageText;
    private Text avgTimeText;
    [SerializeField] int levelsCount = 3;
    [SerializeField] int decimalPlaces = 2;
    // Start is called before the first frame update
    void Start()
    {
        totalsTrackerObject = GameObject.FindGameObjectWithTag("TotalsTracker");
        totalsTracker = totalsTrackerObject.GetComponent<TotalsTracker>();
        totalTimeText = totalTime.GetComponent<Text>();
        totalDamageText = totalDamage.GetComponent<Text>();
        avgDamageText = avgDamage.GetComponent<Text>();
        avgTimeText = avgTime.GetComponent<Text>();
        totalTimeString = totalsTracker.TotalTime.ToString($"F{decimalPlaces}", CultureInfo.InvariantCulture);
        ShowTotals();
    }

    private void ShowTotals()
    {
        totalTimeText.text = totalTimeString;
        totalDamageText.text = totalsTracker.TotalDamage.ToString();
        CalculateAvgs();
    }

    private void CalculateAvgs()
    {
        avgDamageText.text = (totalsTracker.TotalDamage/levelsCount).ToString($"F{decimalPlaces}", CultureInfo.InvariantCulture);
        avgTimeText.text = (totalsTracker.TotalTime/levelsCount).ToString($"F{decimalPlaces}", CultureInfo.InvariantCulture);
    }
}
