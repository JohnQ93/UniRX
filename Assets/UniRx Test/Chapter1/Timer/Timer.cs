using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour {

	float time;
	// Use this for initialization
	void Start () {
		time = Time.time;
	}

	// Update is called once per frame
	void Update () {
		if(Time.time - time > 5.0f)
		{
			Debug.Log("do something!");
            time = float.MaxValue;
		}
	}
}
