using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class UniRxMergeExample : MonoBehaviour {

	void Start () {
        var leftStream = Observable.EveryUpdate().Where(_ => Input.GetMouseButtonDown(0)).Select(_ => "AAA");
        var rightStream = Observable.EveryUpdate().Where(_ => Input.GetMouseButtonDown(1)).Select(_ => "BBB");

        leftStream.Merge(rightStream, rightStream)
                  .Subscribe(Debug.Log);
    }
}
