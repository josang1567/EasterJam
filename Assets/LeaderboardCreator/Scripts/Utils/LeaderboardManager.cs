using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Dan.Main;

public class LeaderboardManager : MonoBehaviour
{
    [SerializeField] private List<TMP_Text> names;
    [SerializeField] private List<TMP_Text> achievement;
    [SerializeField] private List<TMP_Text> scores;
    public string publicKey;

    private void Start()
    {
        GetLeaderboard();
        publicKey = Leaderboards.EggHuntTime.PublicKey;
    }

    public void GetLeaderboard()
    {
        Leaderboards.EggHuntTime.GetEntries(entries =>
        {
            foreach (var t in names)
            {
                t.text = "";
            }

            foreach (var t in achievement)
            {
                t.text = "";
            }

            foreach (var t in scores)
            {
                t.text = "";
            }

            var lenght = Mathf.Min(names.Count, entries.Length);
            for (int i = 0; i < lenght; i++)
            {
                names[i].text = entries[i].Username;
                achievement[i].text = entries[i].Extra.ToString();
                scores[i].text = entries[i].Score.ToString();
            }
        });
    }

    public void SetLeaderboardEntry(string publicKey, string username, int score, string extra)
    {
        LeaderboardCreator.UploadNewEntry(publicKey, username, score, extra, isSuccessful =>
        {
            if (isSuccessful)
            {
                GetLeaderboard();
            }
        });
    }
}
