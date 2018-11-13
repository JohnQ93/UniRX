using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer2 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine(Timer(5.0f, () =>
		{
			Debug.Log("After 5 seconds,Do something");
		}));
	}

	// Update is called once per frame
	void Update () {

	}

	IEnumerator Timer(float seconds, Action callback)
	{
		yield return new WaitForSeconds(seconds);
		callback();
	}
}
