using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

public class UniRxRepeatExample : MonoBehaviour {

    void Start () {
        var leftStream = Observable.EveryUpdate().Where(_ => Input.GetMouseButtonDown(0));
        var rightStream = Observable.EveryUpdate().Where(_ => Input.GetMouseButtonDown(1));

        leftStream.Zip(rightStream, (left, right) => "Both Clicked")
                  .First()
                  .Repeat()
                  .Subscribe(str => Debug.Log(str));


        Observable.Timer(TimeSpan.FromSeconds(1.0f))
                  .Repeat()
                  .Subscribe(_ => Debug.Log("after 1 seconds"));
    }
}
