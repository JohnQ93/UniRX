using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

public class UniRxTakeLastExample : MonoBehaviour {

    void Start () {
        Observable.Range(5, 5)
                  .TakeLast(3)
                  .Subscribe(num => Debug.Log(num));

        var subjects = new Subject<float>();

        subjects.TakeLast(TimeSpan.FromSeconds(2.0f))
                .Subscribe(clickTime => Debug.Log(clickTime));

        Observable.EveryUpdate()
                  .Where(_ => Input.GetMouseButtonDown(0))
                  .Subscribe(_ => subjects.OnNext(Time.time));

        Observable.Timer(TimeSpan.FromSeconds(5.0f))
                  .Subscribe(_ => subjects.OnCompleted());
    }
}
