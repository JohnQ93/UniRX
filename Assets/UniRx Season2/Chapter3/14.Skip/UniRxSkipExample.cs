using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

public class UniRxSkipExample : MonoBehaviour {
    
	void Start () {
        Observable.EveryUpdate()
                  .Where(_ => Input.GetMouseButtonDown(0))
                  .Skip(TimeSpan.FromSeconds(5))
                  .Subscribe(_ => Debug.Log("mouse clicked"));
	}
}
