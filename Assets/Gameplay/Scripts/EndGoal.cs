using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGoal : MonoBehaviour
{
    void OnTriggerEnter(Collider other) {
        var ghostRecorder = other.gameObject.getComponent<GhostRecorder>();
        ghostRecorder.EndRun();
    }
}
