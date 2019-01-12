using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

public class UniRxThrottleFirstExample : MonoBehaviour {

	void Start () {
        Observable.EveryUpdate()
                  .Where(_ => Input.GetMouseButtonDown(0))
                  .ThrottleFirst(TimeSpan.FromSeconds(2.0f))
                  .Subscribe(_ => Debug.Log("clicked"));
	}
}
