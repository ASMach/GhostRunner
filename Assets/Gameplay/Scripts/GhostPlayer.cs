using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostPlayer : MonoBehaviour
{
	public Ghost ghost;

	private float timeValue = 0;
	private int index1;
	private int index2;

    // Update is called once per frame
    void Update()
    {
		timeValue += Time.unscaledTime;

        if (ghost.bReplay)
		{
			GetIndex();
			SetTransform();
		}
    }

    private void GetIndex()
	{
        for (int i = 0; i < ghost.TimeStamps.Count - 2; i++)
		{
			if (ghost.TimeStamps[i] == timeValue)
			{
				index1 = i;
				index2 = i;
				return;
			} else if (ghost.TimeStamps[i] < timeValue & timeValue < ghost.TimeStamps[i+1]) {
				index1 = i;
				index2 = i + 1;
				return;
			}
		}
        index1 = ghost.TimeStamps.Count - 1;
		index2 = ghost.TimeStamps.Count - 1;
	}

    private void SetTransform()
	{
        if (index1 == index2)
		{
			this.transform.position = ghost.Positions[index1];
			this.transform.eulerAngles = ghost.Rotations[index1];
		}
		else
		{
			float interpolationFactor = (timeValue - ghost.TimeStamps[index1])/(ghost.TimeStamps[index2] - ghost.TimeStamps[index1]);

			this.transform.position = Vector3.Lerp(ghost.Positions[index1], ghost.Positions[index2], interpolationFactor);
			this.transform.eulerAngles = Vector3.Lerp(ghost.Rotations[index1], ghost.Rotations[index2], interpolationFactor);
		}
	}
}
