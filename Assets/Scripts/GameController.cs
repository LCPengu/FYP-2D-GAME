using System;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController instance {  get; private set; }

    Player_Info player_info;
    [SerializeField] GameObject Blue, Pink, White, Green;
    int skin;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Found mutiple Game Controllers");
        }
        instance = this;
        player_info = GetComponent<Player_Info>();
        skin = player_info.GetSkinInt();
    }

    public event Action onGoalReached;

    public void GoalReached()
    {
        if (onGoalReached != null)
        {
            onGoalReached();
        }
    }

    public event Action onRestartLevel;
    public void Reset()
    {
        if(onRestartLevel != null)
        {
            onRestartLevel();
        }
    }

    private void Start()
    {
        Debug.Log(skin);
        if (skin == 1)
        {
            Blue.SetActive(true);
        }
        else if (skin == 2)
        {
            Pink.SetActive(true);
        }
        else if (skin == 3)
        {
            White.SetActive(true);
        }
        else if (skin == 4)
        {
            Green.SetActive(true);
        }

    }

}
