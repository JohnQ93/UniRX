using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class UniRxAggregateExample : MonoBehaviour {

    void Start () {
        var subject = new Subject<int>();

        subject.Aggregate((max, next) => max > next ? max : next)
               .Subscribe(result => Debug.Log(result));

        subject.Aggregate((sum, next) => sum + next)
               .Subscribe(result => Debug.Log(result));

        subject.OnNext(2);
        subject.OnNext(200);
        subject.OnNext(201);
        subject.OnNext(55);
        subject.OnNext(30);
        subject.OnCompleted();
    }
}
