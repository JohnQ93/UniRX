using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

public class UniRxDelayExample : MonoBehaviour {

	void Start () {
        Observable.EveryUpdate()
            .Where(_ => Input.GetMouseButtonDown(0))
            .Delay(TimeSpan.FromSeconds(1.0f))
            .Subscribe(_ => Debug.Log("after 1 seconds"));


        Observable.Timer(TimeSpan.FromSeconds(1.0f))
                  .Select(_ =>
                  {
                      Debug.Log("1 seconds");
                      return _;
                  })
                  .Delay(TimeSpan.FromSeconds(1.0f))
                  .Select(__ =>
                  {
                      Debug.Log("2 seconds");
                      return __;
                  })
                  .Delay(TimeSpan.FromSeconds(1.0f))
                  .Subscribe(___ =>
                  {
                      Debug.Log("3 seconds");
                  });
	}
}
