using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

public class UniRxToArrayExample : MonoBehaviour {
    
	void Start () {
        var subject = new Subject<float>();

        subject.ToArray()
               .Subscribe(timeArray =>
               {
                   Array.ForEach(timeArray, time => Debug.Log(time));
               });

        Observable.EveryUpdate()
                  .Where(_ => Input.GetMouseButtonDown(0))
                  .Subscribe(_ => subject.OnNext(Time.time));

        Observable.Timer(TimeSpan.FromSeconds(5.0f))
                  .Subscribe(_ => subject.OnCompleted());
	}
}
