using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using Dan.Main;
using TMPro;
using System.Collections.Generic;


public class FinishLine : MonoBehaviour
{
    [SerializeField] Player_Info playerInfo;
    [SerializeField] List<ItemCollector> collectors;
    [SerializeField] Timer timer;
    [SerializeField] TMP_Text score1;

    private string time, name;
    private int score;
    private string LeaderboardKey = "2c8fd7395ffba6f8cc5456023f677cab72322ed2f92d7ff629aa38aaba53b858";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            NewEntry();
            LeaderboardCreator.DeleteEntry(LeaderboardKey);
            NewEntry();
            //controller.GoalReached();
            SceneManager.LoadScene("MainMenuScene");
        }
    }

    public UnityEvent<string, int, string> submitScoreEvent;

    public void SubmitScore()
    {
        submitScoreEvent.Invoke(name, score, time);
    }

    public void SetLeaderboardNewEntry(string name, int score, string time)
    {
        LeaderboardCreator.UploadNewEntry(LeaderboardKey, name, score, time, ((msg) =>
        {
        }));

    }

    public void NewEntry()
    {
        name = playerInfo.GetPlayerName();
        Debug.Log(name);
        for (int i = 0; i < collectors.Count; i++)
        {
            if (collectors[i].enabled == true)
            {
                score = collectors[i].GetScore();
                Debug.Log(score);
            }
        }
        time = timer.GetTime();
        Debug.Log(time);
        SetLeaderboardNewEntry(name, score, time);
        SubmitScore();
    }
}
