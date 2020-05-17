using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TotalsTracker : Singleton<MonoBehaviour>
{
    private double totalTime;
    private float totalDamage;
    private int shotsTaken;
    private int shotsHit;

    // Start is called before the first frame update
    void Start()
    {
        totalTime = 0;
        totalDamage = 0;
        shotsHit = 0;
        shotsTaken = 0;
    }

    internal double TotalTime { get { return totalTime; } set { totalTime = value; } }
    internal float TotalDamage { get { return totalDamage; } set { totalDamage = value; } }
    internal int ShotsTaken { get { return shotsTaken; } set { shotsTaken = value; } }
    internal int ShotsHit { get { return shotsHit; } set { shotsHit = value; } }
}
