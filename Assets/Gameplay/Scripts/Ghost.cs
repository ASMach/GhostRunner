using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu]

public class Ghost : ScriptableObject
{
	private List<float> timeStamps;
	private List<Vector3> positions;
	private List<Vector3> rotations;

	public List<float> TimeStamps
	{
		get => this.timeStamps;
	}

	public List<Vector3> Positions
	{
		get => this.positions;
	}

	public List<Vector3> Rotations
	{
		get => this.rotations;
	}

	public bool bRecording;
	public bool bReplay;
	public float recordingFrequency;

	private Vector3 currentPosition;

    public void AddLocation(float timeStamp, Vector3 position, Vector3 rotation)
	{
		timeStamps.Add(timeStamp);
		positions.Add(position);
		rotations.Add(rotation);
	}

    public void ResetData()
	{
		timeStamps.Clear();
		positions.Clear();
		rotations.Clear();
	}
}
