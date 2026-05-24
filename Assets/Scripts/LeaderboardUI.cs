using UnityEngine;
using TMPro;
using System;

public class LeaderboardUI : MonoBehaviour
{
    [SerializeField] private GameObject leaderboardScreen;
    [SerializeField] private TMP_Text[] leaderboardTimes;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        leaderboardScreen.SetActive(false);
    }

    public void LoadLeaderboard()
    {
        leaderboardScreen.SetActive(true);

        for (int i = 0; i < GameData.Instance.bestTimes.Count; i++)
        {
            leaderboardTimes[i].text =
            (i + 1) + ". " + GameData.Instance.bestTimes[i].ToString("F2") + "s\n";
        }
    }
}
