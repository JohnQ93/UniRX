using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

public class UniRxThrottleExample : MonoBehaviour {

	void Start () {
        //节流阀 在指定的一段时间内没有数据输入，则输出一次subscribe
        Observable.EveryUpdate()
                  .Where(_ => Input.GetMouseButtonDown(0))
                  .Throttle(TimeSpan.FromSeconds(1.0f))
                  .Subscribe(_ => Debug.Log("clicked"));
	}
}
