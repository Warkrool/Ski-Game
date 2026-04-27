using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public delegate void TimerEvent();
    private DateTime raceStart;
    private TimeSpan raceTime;
    private bool racing = false;
    private void OnEnable()
    {
        Debug.Log("enabling");
        StartGate.StartRace += StartRace;
        FinishGate.FinishRace += FinishRace;
    }

    void FinishRace()
    {
        Debug.Log("ending race");
    }
    void StartRace()
    {
        racing = true;
        raceStart = DateTime.Now;
        Debug.Log("starting race");
    }

    // Update is called once per frame
    void Update()
    {
        if(racing)
        raceTime = DateTime.Now - raceStart;
        Debug.Log("race time" + raceTime);
    }
}
