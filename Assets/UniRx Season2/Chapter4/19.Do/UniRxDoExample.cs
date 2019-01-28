using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

public class UniRxDoExample : MonoBehaviour {

	void Start () {
        //Do 一般用来在Subscribe前Log使用，不会产生副作用
        Observable.ReturnUnit()
                  .Delay(TimeSpan.FromSeconds(1))
                  .Do(_ => Debug.Log("after 1 seconds"))
                  .Delay(TimeSpan.FromSeconds(1))
                  .Do(_ => Debug.Log("after 2 seconds"))
                  .Delay(TimeSpan.FromSeconds(1))
                  .Do(_ => Debug.Log("after 3 seconds"))
                  .Subscribe();
	}
}
