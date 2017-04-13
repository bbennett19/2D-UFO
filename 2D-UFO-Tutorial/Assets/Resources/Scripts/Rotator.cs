using UnityEngine;
using System.Collections;

// Allows rotation at a constant speed
public class Rotator : MonoBehaviour
{
    public int rotationPerSecond;

	//Update is called every frame
	void Update () 
	{
		transform.Rotate (new Vector3 (0, 0, rotationPerSecond) * Time.deltaTime);
	}
}
