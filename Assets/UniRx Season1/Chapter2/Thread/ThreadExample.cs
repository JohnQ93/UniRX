using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;
using System.Threading;

public class ThreadExample : MonoBehaviour {

    // Use this for initialization
    void Start () {
        var threadAStream = Observable.Start(() =>
        {
            Thread.Sleep(TimeSpan.FromSeconds(1));
            return 11;
        });
        var threadBStream = Observable.Start(() =>
        {
            Thread.Sleep(TimeSpan.FromSeconds(3));
            return 12;
        });

        Observable.WhenAll(threadAStream, threadBStream)
                  .ObserveOnMainThread()
                  .Subscribe(results =>
                  {
                      Debug.LogFormat("{0}: {1}", results[0], results[1]);
                  });
    }

    // Update is called once per frame
    void Update () {

    }
}
