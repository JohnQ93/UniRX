using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class ReactivePropertyExample : MonoBehaviour {

	public ReactiveProperty<int> Age = new ReactiveProperty<int>();
    private int kinds = 0;
    private IDisposable disposable;

	void OnEnable () {
        //Age.Subscribe(age =>
        //{
        //	Debug.Log("age changed");
        //});
        //Age.Value = 10;

        disposable = Age.Where(age => age > 0)
           .First()
           .Subscribe(_ =>
           {
               kinds++;
               Debug.LogFormat("kinds == {0}", kinds);
           }).AddTo(this);
        

        Observable.Interval(TimeSpan.FromSeconds(2.0f))
                  .Subscribe(_ =>
                  {
                      Age.Value++;
                  });
    }

    private void OnDisable()
    {
        disposable.Dispose();
        Age.Value = 0;
        kinds = 0;
    }
}

