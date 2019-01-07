using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class UniRxSkipWhileExample : MonoBehaviour {
    
	void Start () {
        Observable.EveryUpdate()
                  .SkipWhile((_, times) => !Input.GetMouseButtonDown(0) && times < 200)
                  .Subscribe(_ => Debug.Log("mouse click"));
	}
}
