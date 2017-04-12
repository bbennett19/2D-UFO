using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldSpawner : MonoBehaviour {

    public int maxCount;
    public float delay;
    public GameObject objectToSpawn;
    public float width;

    private float _timer = 0.0f;
	
	// Update is called once per frame
	void Update ()
    {
        int count = GetComponentsInChildren<Transform>().Length;

        if (count < maxCount)
        {
            _timer += Time.deltaTime;

            if (_timer >= delay)
            {
                Instantiate(objectToSpawn, new Vector3(Random.value * width * 2.0f - width, Random.value * width * 2.0f - width), Quaternion.identity, this.transform).SetActive(true);
                _timer = 0.0f;
            }
        }
	}
}
