using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    private List<Vector3> positions;

    // Start is called before the first frame update
    void Start()
    {
        // Initialize empty list and populate it from saved data
        positions = new List<Vector3>();
        Save save = SaveManager.Instance.LoadRunData();
        for (int i = 0; i < save.positions.Count; i++)
        {
            Vector3 p = save.positions[i];
            positions.Add(p);
        }
    }

    // FixedUpdate is called once per physics tick
    void FixedUpdate()
    {
        // TODO: Update to position for this timestamp
    }
}
