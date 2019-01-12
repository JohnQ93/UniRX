using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

public class UniRxSampleExample : MonoBehaviour {

    int clickCounts = 0;
	void Start () {
        Observable.EveryUpdate()
                  .Where(_ => Input.GetMouseButtonDown(0))
                  .Select(_ => clickCounts++)
                  .Sample(TimeSpan.FromSeconds(3.0f))
                  .Subscribe(_ => Debug.LogFormat("第{0}次点击", clickCounts));
	}
}
