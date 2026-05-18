using UnityEngine;
using System;
using System.Security.Cryptography;
using TMPro;

public class GameManager : MonoBehaviour
{
    public delegate void TimerEvent();
    private DateTime raceStart;
    private TimeSpan raceTime;
    private TimeSpan penaltyTime;
    private TimeSpan bestTime;
    private bool racing = false;
    [SerializeField] private TMP_Text timerText, bestTimeText;
    [SerializeField] private string bestTimeKey = "BestTimeLVL1";
    private void OnEnable()
    {
        StartGate.StartRace += StartRace;
        FinishGate.FinishRace += FinishRace;
        CheckFlag.TimePenalty += AddTimePenalty;
    }
    private void OnDisable()
    {
        StartGate.StartRace -= StartRace;
        FinishGate.FinishRace -= FinishRace;
        CheckFlag.TimePenalty -= AddTimePenalty;
    }
    private void Start()
    {
        int bestTimeInt = PlayerPrefs.GetInt(bestTimeKey, int.MaxValue);
        bestTime = new TimeSpan(bestTimeInt);
        bestTimeText.text = "Best Time" + raceTime.ToString("mm\\:ss");
    }
    void AddTimePenalty()
    {
        penaltyTime += new TimeSpan(0, 0, 3);
    }
    void FinishRace()
    {
        Debug.Log("ending race");
        racing= false;
        GameData.Instance.AddLevelTime((float)raceTime.TotalMilliseconds/1000f);
        if(raceTime<bestTime)
        {
            bestTimeText.text = "Best Time" + raceTime.ToString("mm\\:ss");
            PlayerPrefs.SetInt(bestTimeKey, (int)raceTime.Ticks);
            PlayerPrefs.Save();
        }
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
        if (racing)
        {
            raceTime = DateTime.Now - raceStart + penaltyTime;
            timerText.text = "Time" + raceTime.ToString("mm\\:ss");
        }
    }
}
