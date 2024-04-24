using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Dan.Main;
using System.Linq;

public class PlayerLeaderboard : MonoBehaviour
{
    private string LeaderboardKey = "2c8fd7395ffba6f8cc5456023f677cab72322ed2f92d7ff629aa38aaba53b858";
    [SerializeField] private List<TextMeshProUGUI> names, scores, times;

    void Start()
    {
        GetLeaderboard();
    }
    public void GetLeaderboard()
    {
        LeaderboardCreator.GetLeaderboard(LeaderboardKey, ((msg) =>
        {
            int loopLength = (msg.Length < names.Count) ? msg.Length : names.Count;
            for (int i = 0; i < loopLength; ++i)
            {
                names[i].text = msg[i].Username;
                scores[i].text = msg[i].Score.ToString();
                times[i].text = msg[i].Extra.ToString();
            }
        }));
        for (int i = 0; i < names.Count; ++i)
        {
            if (names[i].text == "Names:")
            {
                names[i].text = "";
            }
            if (scores[i].text == "Names:")
            {
                scores[i].text = "";
            }
            if (times[i].text == "Names:")
            {
                times[i].text = "";
            }
        }
    }

    public void SetLeaderboardNewEntry(string name, int score, string time)
    {
        LeaderboardCreator.UploadNewEntry(LeaderboardKey, name, score, time, ((msg) =>
        {
            GetLeaderboard();
        }));
    }
}