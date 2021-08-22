using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GhostRecorder : MonoBehaviour
{
    private bool isRecording = true;

    private float elapsedTime = 0.0f;

    private List<Vector3> positions; // Store the positions the player goes to

    // Start is called before the first frame update
    void Start()
    {
        // Initialize empty positions list for the ghost being recorded
        positions = new List<Vector3>();
    }

    // FixedUpdate is called once per physics tick
    void FixedUpdate()
    {
        // Add a ghost position waypoint and increase our elapsed time.
        if (isRecording) 
        {
            positions.Add(gameObject.transform.position);
            elapsedTime += Time.deltaTime;
        }
    }

    private Save SaveRunData() 
    {
        Save save = new Save();
        int i = 0;
        foreach (Vector3 p in positions) 
        {
            save.positions.Add(p);
            i++;
        }
        save.time = elapsedTime;
        save.level = SceneManager.GetActiveScene().name;

        return save;
    }

    public void EndRun()
    {
        // We don't want to record any more
        isRecording = false;

        float bestTime = 999.0f;

        // TODO: Load the bestTime float

        // Only save a new ghost if the run is a new best.
        if (elapsedTime > bestTime)
        {
            SaveManager.Instance.SaveRun(SaveRunData());
        }
    }
}
