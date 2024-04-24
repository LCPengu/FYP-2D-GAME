using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recorder : MonoBehaviour
{
    private bool isDoingReplay = false;
    public Queue<ReplayData> recordingQueue {  get; private set; }
    [SerializeField] private GameObject playerReplayObject;
    private Recording recording;
    private void Awake()
    {
        recordingQueue = new Queue<ReplayData>();
    }

    private void Start()
    {
        //link events(game end)
        GameController.instance.onGoalReached += OnGoalReached;
        GameController.instance.onRestartLevel += OnRestartLevel;
    }

    private void OnDestroy()
    {
        GameController.instance.onGoalReached -= OnGoalReached;
        GameController.instance.onRestartLevel -= OnRestartLevel;
    }

    private void OnGoalReached()
    {
        StartReplay();
    }

    private void OnRestartLevel()
    {
        Reset();
    }

    private void Update()
    {
        if(isDoingReplay== false)
        {
            return;
        }
        bool hasFrames = recording.PlayNextFrame();
        if(hasFrames == false)
        {
            ResetReplay();
        }
    }

    public void RecordReplayFrame(ReplayData replay)
    {
        recordingQueue.Enqueue(replay);
        Debug.Log("Recorded data: " + replay.position);
    }

    private void StartReplay()
    {
        isDoingReplay=true;
        recording = new Recording(recordingQueue);

        recordingQueue.Clear();

        recording.InstantiateReplayObject(playerReplayObject);
    }

    private void ResetReplay()
    {
        isDoingReplay = true;
        recording.RestartFromBeginning();
    }

    private void Reset()
    {
        isDoingReplay = false;
        recordingQueue.Clear();
        recording.DestroyReplayObjectIfItExists();
        recording = null;
    }
}
