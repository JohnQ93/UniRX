using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

public class TimerExample : MonoBehaviour {

	void Start () {
        Observable.Timer(TimeSpan.FromSeconds(2.0f), TimeSpan.FromSeconds(1.0f))
                  .Subscribe(_ => Debug.Log("send message"));

        //Observable.Interval(TimeSpan.FromSeconds(1.0f))
                  //.Subscribe(_ => Debug.Log("send message"));
    }
}
