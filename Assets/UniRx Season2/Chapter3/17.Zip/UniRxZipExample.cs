using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class UniRxZipExample : MonoBehaviour {

	void Start () {
        var leftStream = Observable.EveryUpdate().Where(_ => Input.GetMouseButtonDown(0)).Select(__ => "left");
        var rightStream = Observable.EveryUpdate().Where(_ => Input.GetMouseButtonDown(1)).Select(__ => "right");

        leftStream.Zip(rightStream, (left, right) => left + " " + right)
                  .Subscribe(content =>
                  {
                      Debug.Log(content);
                  });
	}
}
