using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Save
{
  // Used to save ghost positions for best run time
  public List<Vector3> positions = new List<Vector3>();
  // We only want to create a new save if there is a lower time, so we save it
  public float time;
  // Each level must have its own save data, so it must be saved here
  public string level;
}
