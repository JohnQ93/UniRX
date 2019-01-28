using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

public class UniRxCombineLatestExample : MonoBehaviour {

	void Start () {
        var a = 0;
        var b = 0;
        var leftStream = Observable.EveryUpdate().Where(_ => Input.GetMouseButtonDown(0)).Select(_ => ++a);
        var rightStream = Observable.EveryUpdate().Where(_ => Input.GetMouseButtonDown(1)).Select(_ => ++b);

        leftStream.CombineLatest(rightStream, (left, right) => left.ToString() + right.ToString())
                  .Subscribe(Debug.Log);
    }
}
