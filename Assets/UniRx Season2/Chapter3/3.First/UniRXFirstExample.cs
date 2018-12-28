using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class UniRXFirstExample : MonoBehaviour {
    
	void Start () {
        Observable.EveryUpdate()
                  .First(_ => Input.GetMouseButtonDown(0))
                  .Subscribe(_ =>
                  {
                      Debug.Log("mouse down");
                  }).AddTo(this);
	}
}
