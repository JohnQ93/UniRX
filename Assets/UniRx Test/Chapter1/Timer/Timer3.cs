using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UniRx;

public class Timer3 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Observable.Timer(TimeSpan.FromSeconds(5.0f))
				  .Subscribe(_ =>
				  {
					  Debug.Log("UniRx Example");
				  });

	}

	// Update is called once per frame
	void Update () {

	}
}
