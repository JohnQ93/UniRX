using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class UniRxScanExample : MonoBehaviour {

	void Start () {
        Observable.EveryUpdate()
                  .Where(_ => Input.GetMouseButtonDown(0))
                  .Scan(0, (times, nextValue) => ++times)
                  .Subscribe(result => Debug.LogFormat("mouse click {0} times", result));
	}
}
