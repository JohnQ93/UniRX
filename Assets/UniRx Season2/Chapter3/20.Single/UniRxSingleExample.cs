using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class UniRxSingleExample : MonoBehaviour {

    void Start () {
        var subjects = new Subject<int>();

        subjects.Where(number => number % 2 == 0)
                .Single()
                .Subscribe(number => Debug.Log(number));

        subjects.OnNext(1);
        subjects.OnNext(2);
        subjects.OnNext(3);
        subjects.OnCompleted();
    }
}
