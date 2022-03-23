using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GhostRecorder : MonoBehaviour
{
	public Ghost ghost;
	private float timer;
	private float timeValue;

    private void Awake()
	{
		if (ghost.bRecording)
		{
			ghost.ResetData();
			timeValue = 0;
			timer = 0;
		}
	}

    void Update()
    {
		timer += Time.unscaledDeltaTime;
        timeValue += Time.unscaledDeltaTime;

        if (ghost.bRecording & timer >= 1/ghost.recordingFrequency)
		{
			ghost.AddLocation(timeValue, this.transform.position, this.transform.eulerAngles);

			timer = 0;
		}
	}

    private Save SaveRunData() 
    {
        Save save = new Save();
        int i = 0;
        
        save.time = timeValue;
        save.level = SceneManager.GetActiveScene().name;

        return save;
    }

    public void EndRun()
    {
		Debug.Log("Done recording this run");
        // We don't want to record any more
        ghost.bRecording = false;

        float bestTime = 999.0f;

        // TODO: Load the bestTime float

        // Only save a new ghost if the run is a new best.
        if (timeValue > bestTime)
        {
            SaveManager.Instance.SaveRun(SaveRunData());
        }
    }
}
