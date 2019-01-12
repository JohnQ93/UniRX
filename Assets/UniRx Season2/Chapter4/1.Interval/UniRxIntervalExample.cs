using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

public class UniRxIntervalExample : MonoBehaviour {

	void Start () {
        Observable.Interval(TimeSpan.FromSeconds(0.5f))
                  .Where(times => times < 10)
                  .Subscribe(times => Debug.Log(times));

	}
}
