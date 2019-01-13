using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class UniRxTimeIntervalExample : MonoBehaviour {

	void Start () {
        Observable.EveryUpdate()
                  .Where(_ => Input.GetMouseButtonDown(0))
                  .Select(__ => "clicked")
                  .TimeInterval()
                  .Subscribe(timeInterval => Debug.LogFormat("{0},{1}", timeInterval.Interval, timeInterval.Value));
	}
}
