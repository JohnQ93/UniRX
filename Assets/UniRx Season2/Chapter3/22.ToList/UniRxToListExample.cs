using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

public class UniRxToListExample : MonoBehaviour {
    
	void Start () {
        var subject = new Subject<float>();

        subject.ToList()
               .Subscribe(timeList =>
               {
                   foreach (var time in timeList)
                   {
                       Debug.Log(time);
                   }
               });

        Observable.Timer(TimeSpan.FromSeconds(1.0f))
                  .Repeat()
                  .Take(5)
                  .Subscribe(_ => subject.OnNext(Time.time), () => { subject.OnCompleted(); });
	}
}
