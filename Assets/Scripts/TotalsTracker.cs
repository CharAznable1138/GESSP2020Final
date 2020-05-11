using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TotalsTracker : Singleton<MonoBehaviour>
{
    private double totalTime;
    private float totalDamage;
    [SerializeField] double starterTime = 0;
    [SerializeField] float starterDamage = 0;

    // Start is called before the first frame update
    void Start()
    {
        totalTime = starterTime;
        totalDamage = starterDamage;
    }

    internal double TotalTime { get { return totalTime; } set { totalTime = value; } }
    internal float TotalDamage { get { return totalDamage; } set { totalDamage = value; } }
}
