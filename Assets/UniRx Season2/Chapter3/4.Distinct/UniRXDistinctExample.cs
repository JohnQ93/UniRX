using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class UniRXDistinctExample : MonoBehaviour {
    
	void Start () {
        var leftMouseClickStream = Observable.EveryUpdate().Where(_ => Input.GetMouseButtonDown(0)).Select(_ => "leftMouseClick");
        var rightMouseClickStream = Observable.EveryUpdate().Where(_ => Input.GetMouseButtonDown(1)).Select(_ => "rightMouseClick");

        Observable.Merge(leftMouseClickStream, rightMouseClickStream)
                  .Distinct()
                  .Subscribe(eventName =>
                  {
                      Debug.Log(eventName);
                  });
	}
}
