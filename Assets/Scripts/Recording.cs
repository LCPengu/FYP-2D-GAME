using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recording
{
    public ReplayObject replayObject {  get; private set; }
    private Queue<ReplayData> mainQueue;
    private Queue<ReplayData> replayQueue;

    public Recording(Queue<ReplayData> recordingQueue)
    {
        this.mainQueue = new Queue<ReplayData>(recordingQueue);
        this.replayQueue = new Queue<ReplayData>(recordingQueue);

    }

    public void RestartFromBeginning()
    {
        this.replayQueue = new Queue<ReplayData>(mainQueue);
    }

    public bool PlayNextFrame()
    {
        bool dequeueFrames = false;
        if (replayObject == null)
        {
            Debug.LogError("Missing frame for recording");
        }

        if(replayQueue.Count != 0)
        {
            ReplayData data = replayQueue.Dequeue();
            replayObject.SetDataForFrame(data);
            return dequeueFrames = true;
        }
        return dequeueFrames;
    }

    public void InstantiateReplayObject(GameObject Player_Replay_Object)
    {
        if (replayQueue.Count != 0)
        {
            ReplayData data = replayQueue.Peek();
            this.replayObject = Object.Instantiate(Player_Replay_Object, data.position, Quaternion.identity).GetComponent<ReplayObject>();
        }
    }

    public void DestroyReplayObjectIfItExists()
    {
        if(replayObject != null)
        {
            Object.Destroy(replayObject.gameObject);
        }
    }
}
