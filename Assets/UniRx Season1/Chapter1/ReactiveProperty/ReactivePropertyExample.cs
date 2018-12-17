using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class ReactivePropertyExample : MonoBehaviour {

	public ReactiveProperty<int> Age = new ReactiveProperty<int>();
	// Use this for initialization
	void Start () {
		Age.Subscribe(age =>
		{
			Debug.Log("age changed");
		});
		Age.Value = 10;
	}

	// Update is called once per frame
	void Update () {

	}
}

