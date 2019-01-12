using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

public class UniRxReturnExample : MonoBehaviour {

	void Start () {
        Observable.Return(new List<int> { 1, 2, 3, 4, 5, 6 })
                  .Subscribe(list => Debug.Log(list.Count));


        Observable.Return(Unit.Default)
                  .Delay(TimeSpan.FromSeconds(1.0f))
                  .Repeat()
                  .Subscribe(_ => Debug.Log("1 seconds"));

	}
}
