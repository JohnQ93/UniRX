﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class WhereExample : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Observable.EveryUpdate()
				  .Where(_ => Input.GetMouseButtonDown(0))
				  .Subscribe(_ =>
				  {
					  Debug.Log("mouse clicked");
				  });
	}


}
